using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GMCC.Pages
{
    public class LoginStudent : PageModel
    {
        [BindProperty]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [BindProperty]
        [Required]
        public string Password { get; set; }

        public string ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            bool loginOk = true; // placeholder for Database check

            if (!loginOk)
            {
                ErrorMessage = "Invalid email or password.";
                return Page();
            }

            return RedirectToPage("/BrowseDormStudent", new { fullName = Email });
        }

        public IActionResult ForgotPassword()
        {
            // forgot password function can be implemented here
            return Page();
        }

        public IActionResult CreateAccount()
        {
            return RedirectToPage("/RegisterStudent");
        }
    }
}
