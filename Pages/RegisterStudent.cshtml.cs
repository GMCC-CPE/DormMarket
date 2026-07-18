using System;
using System.Linq;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MongoDB.Driver;

namespace GMCC.Pages
{
    public class RegisterStudent : PageModel
    {
        private readonly MongoDBService _mongoService;

        public RegisterStudent(MongoDBService mongoService)
        {
            _mongoService = mongoService;
        }

        [BindProperty]
        public string FullName { get; set; }

        [BindProperty]
        public string Email { get; set; }

        [BindProperty]
        public string ContactNumber { get; set; }

        [BindProperty]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostCreateAccount()
        {
            if (string.IsNullOrEmpty(FullName) || string.IsNullOrEmpty(Email) ||
                string.IsNullOrEmpty(ContactNumber) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "Please fill in all fields.";
                return Page();
            }

            if (!IsValidEmail(Email))
            {
                ErrorMessage = "Please enter a valid email address.";
                return Page();
            }

            var existing = _mongoService.Students
                .Find(s => s.Email == Email)
                .FirstOrDefault();

            if (existing != null)
            {
                ErrorMessage = "An account with this email already exists.";
                return Page();
            }

            var nameParts = FullName.Trim().Split(' ', 2);
            var firstName = nameParts[0];
            var lastName = nameParts.Length > 1 ? nameParts[1] : "";

            var maxId = _mongoService.Students
                .Find(FilterDefinition<studentUser>.Empty)
                .SortByDescending(s => s.Id)
                .Limit(1)
                .FirstOrDefault();
            var nextId = (maxId?.Id ?? 0) + 1;

            var newStudent = new studentUser
            {
                Id = nextId,
                FirstName = firstName,
                LastName = lastName,
                Email = Email,
                Password = Password,
                Phone = ContactNumber,
                DateJoined = DateTime.UtcNow
            };

            _mongoService.Students.InsertOne(newStudent);

            SuccessMessage = "Account created successfully.";
            return RedirectToPage("/VerifyStudent", new { studentId = nextId });
        }

        public IActionResult OnPostLogin()
        {
            return RedirectToPage("/LoginStudent");
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
                return Regex.IsMatch(email, pattern);
            }
            catch
            {
                return false;
            }
        }
    }
}
