using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class ProfileOwner : PageModel
    {
        public string? StatusMessage { get; set; }

        [BindProperty]
        public string FullName { get; set; } = string.Empty;

        [BindProperty]
        public string Email { get; set; } = string.Empty;

        [BindProperty]
        public string ContactNumber { get; set; } = string.Empty;

        [BindProperty]
        public string Address { get; set; } = string.Empty;

        [BindProperty]
        public string MessengerLink { get; set; } = string.Empty;

        [BindProperty]
        public string OtherContactLink { get; set; } = string.Empty;

        public List<VerificationDocItem> Documents { get; set; } = new();

        public void OnGet()
        {
        //load all owner details
        }

        public IActionResult OnPostDashboard()
        {
            return RedirectToPage("/DashboardOwner");
        }

        public IActionResult OnPostListing()
        {
            return RedirectToPage("/BrowseDormOwner");
        }

        public IActionResult OnPostSaveChanges()
        {
            StatusMessage = "Profile updated.";
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            return RedirectToPage("/LoginOwner");
        }
    }
}
