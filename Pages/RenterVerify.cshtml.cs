using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GMCC.Pages
{
    public class RenterVerify : PageModel
    {
        [BindProperty]
        public string Dormitory { get; set; }

        [BindProperty]
        public string MoveInDate { get; set; }

        [BindProperty]
        public string MoveOutDate { get; set; }

        [BindProperty]
        public IFormFile? ProofFile { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPostNeverRented()
        {
            return RedirectToPage("/LoginStudent");
        }

        public IActionResult OnPostSubmitProof()
        {
            if (string.IsNullOrEmpty(Dormitory))
            {
                ErrorMessage = "Please select or enter your dormitory.";
                return Page();
            }

            if (ProofFile == null || ProofFile.Length == 0)
            {
                ErrorMessage = "Please upload proof of stay.";
                return Page();
            }

            if (string.IsNullOrEmpty(MoveInDate))
            {
                ErrorMessage = "Please select your move-in date.";
                return Page();
            }
            //missing verify the picture if it is true or not (i dont know how to make system handle this)

            return RedirectToPage("/LoginStudent");
        }
    }
}