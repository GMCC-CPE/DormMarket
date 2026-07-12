using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GMCC.Pages
{
    public class RoleModel : PageModel
    {
        public void OnGet()
        {

        }

        public IActionResult OnPostStudentContinue()
        {
            return RedirectToPage("/LoginStudent");
        }

        public IActionResult OnPostOwnerContinue()
        {
            return RedirectToPage("/LoginOwner");
        }
    }
}