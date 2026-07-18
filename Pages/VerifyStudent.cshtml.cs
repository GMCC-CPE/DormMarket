using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using Tesseract;

namespace GMCC.Pages
{
    public class VerifyStudent : PageModel
    {
        private readonly IWebHostEnvironment _env;
        private readonly ILogger<VerifyStudent> _logger;
        private readonly MongoDBService _mongoService;

        private static readonly string[] AllowedExtensions = { ".jpg", ".jpeg", ".png" };
        private static readonly string[] AllowedContentTypes = { "image/jpeg", "image/png" };
        private const long MaxFileSizeBytes = 10 * 1024 * 1024;

        public VerifyStudent(IWebHostEnvironment env, ILogger<VerifyStudent> logger, MongoDBService mongoService)
        {
            _env = env;
            _logger = logger;
            _mongoService = mongoService;
        }

        // Carries the account this verification belongs to (set via the
        // hidden field, populated from the ?studentId= query param that
        // RegisterStudent redirects with).
        [BindProperty(SupportsGet = true)]
        public int StudentId { get; set; }

        [BindProperty]
        public string School { get; set; } = string.Empty;

        [BindProperty]
        public string? SchoolEmail { get; set; }

        [BindProperty]
        public IFormFile? StudentIdFile { get; set; }

        public string? ErrorMessage { get; set; }
        public string? SuccessMessage { get; set; }
        public bool IsPendingReview { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostSubmit()
        {
            if (StudentId <= 0)
            {
                ErrorMessage = "We couldn't tell which account this belongs to. Please register again.";
                return Page();
            }

            if (string.IsNullOrWhiteSpace(School))
            {
                ErrorMessage = "Please enter your school/university name.";
                return Page();
            }

            if (StudentIdFile == null || StudentIdFile.Length == 0)
            {
                ErrorMessage = "Please upload your student ID.";
                return Page();
            }

            if (StudentIdFile.Length > MaxFileSizeBytes)
            {
                ErrorMessage = "File is too large. Max size is 10 MB.";
                return Page();
            }

            var ext = Path.GetExtension(StudentIdFile.FileName).ToLowerInvariant();
            if (!AllowedExtensions.Contains(ext) || !AllowedContentTypes.Contains(StudentIdFile.ContentType))
            {
                ErrorMessage = "Invalid file type. Please upload a JPG or PNG image.";
                return Page();
            }

            // Optional email sanity check
            if (!string.IsNullOrWhiteSpace(SchoolEmail) && !SchoolEmail.Contains('@'))
            {
                ErrorMessage = "Please enter a valid school email, or leave it blank.";
                return Page();
            }

            byte[] imageBytes;
            using (var memoryStream = new MemoryStream())
            {
                await StudentIdFile.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }

            var ocrResult = RunLocalOcrScan(imageBytes, School);
            if (!ocrResult.IsSuccess)
            {
                ErrorMessage = ocrResult.Message;
                return Page();
            }

            string relativePath;
            try
            {
                var uploadsFolder = Path.Combine(_env.WebRootPath, "uploads", "student-ids");
                Directory.CreateDirectory(uploadsFolder);

                var uniqueFileName = $"{StudentId}_{DateTime.UtcNow:yyyyMMddHHmmssfff}{ext}";
                var fullPath = Path.Combine(uploadsFolder, uniqueFileName);

                await System.IO.File.WriteAllBytesAsync(fullPath, imageBytes);

                relativePath = $"/uploads/student-ids/{uniqueFileName}";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save student verification image to disk.");
                ErrorMessage = "Something went wrong saving your verification. Please try again.";
                return Page();
            }

            try
            {
                var update = Builders<studentUser>.Update
                    .Set(s => s.IdImagePath, relativePath)
                    .Set(s => s.VerificationStatus, "Approved")
                    .Set(s => s.VerifiedAtUtc, DateTime.UtcNow);

                var result = await _mongoService.Students.UpdateOneAsync(s => s.Id == StudentId, update);

                if (result.MatchedCount == 0)
                {
                    ErrorMessage = "We couldn't find your account to attach this verification to. Please register again.";
                    return Page();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to save student verification image to MongoDB.");
                ErrorMessage = "Something went wrong saving your verification. Please try again.";
                return Page();
            }

            return RedirectToPage("/RenterVerify", new { studentVerification = "approved" });
        }

        private (bool IsSuccess, string Message) RunLocalOcrScan(byte[] imageBytes, string userInputSchool)
        {
            string tessdataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "tessdata");

            if (!Directory.Exists(tessdataPath))
            {
                _logger.LogError($"Missing tessdata directory at: {tessdataPath}");
                return (false, "Verification error: Missing OCR language database assets.");
            }

            try
            {
                using var engine = new TesseractEngine(tessdataPath, "eng", EngineMode.Default);
                using var img = Pix.LoadFromMemory(imageBytes);
                using var page = engine.Process(img);

                string extractedText = page.GetText();
                float confidence = page.GetMeanConfidence();

                if (confidence < 0.55f)
                {
                    return (false, "The uploaded image is too blurry. Please try again with a clearer, brighter photo.");
                }

                string normalizedExtracted = extractedText.Replace(" ", "").ToLowerInvariant();

                string[] inputWords = userInputSchool.ToLowerInvariant()
                    .Split(new[] { ' ', '-', ',', '.' }, StringSplitOptions.RemoveEmptyEntries);

                int matchCount = inputWords.Count(word => normalizedExtracted.Contains(word));

                if (matchCount < 2)
                {
                    return (false, $"Verification failed. We couldn't match '{userInputSchool}' with the text read on this ID card.");
                }

                var idMatch = Regex.Match(extractedText, @"\b\d{2}-\d{4}-\d{3}\b");
                if (!idMatch.Success)
                {
                    return (false, "Verification failed. We could not read a valid Student ID number pattern on your card.");
                }
                string detectedIdNumber = idMatch.Value;

                string registeredName = User.Identity?.Name ?? "";
                if (!string.IsNullOrEmpty(registeredName))
                {
                    string cleanRegisteredName = registeredName.Replace(" ", "").ToLowerInvariant();
                    if (!normalizedExtracted.Contains(cleanRegisteredName))
                    {
                        return (false, $"Verification failed. The name on this ID doesn't match your profile name ({registeredName}).");
                    }
                }

                return (true, "Success");
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "OCR Engine Exception occurred.");
                return (false, "Failed to analyze ID card. Ensure you uploaded a clear, uncorrupted image.");
            }
        }

        public IActionResult OnPostSkip()
        {
            return RedirectToPage("/RenterVerify", new { studentVerification = "skipped" });
        }
    }
}
