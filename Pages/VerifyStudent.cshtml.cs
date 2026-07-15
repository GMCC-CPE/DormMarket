using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GMCC.Pages
{
    public class VerifyStudent : PageModel
    {
        [BindProperty]
        public string School { get; set; }

        [BindProperty]
        public string SchoolEmail { get; set; }

        [BindProperty]
        public IFormFile? StudentIdFile { get; set; }

        public string ErrorMessage { get; set; }
        public string SuccessMessage { get; set; }

        public void OnGet()
        {
        }
        public IActionResult OnPostVerify()
        {
            // check after uploading ID if it is true or fake ID of student
        }
        public IActionResult OnPostSubmit()
        {
            if (string.IsNullOrEmpty(School))
            {
                ErrorMessage = "Please select your school.";
                return Page();
            }

            if (StudentIdFile == null || StudentIdFile.Length == 0)
            {
                ErrorMessage = "Please upload your student ID or COR.";
                return Page();
            }
            //missing verify the picture function if it is true or not (i dont know how to make system handle this)
            return RedirectToPage("/RenterVerify");
        }

        public IActionResult OnPostSkip()
        {
            return RedirectToPage("/RenterVerify");
        }
    }
}