using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class VerificationDocument
    {
        public string Title { get; set; } = string.Empty;
        public string FileName { get; set; } = string.Empty;
        public bool Verified { get; set; }
    }

    public class ProfileOwner : PageModel
    {
        [BindProperty]
        public string FullName { get; set; } = "Juan Dela Cruz";

        [BindProperty]
        public string Email { get; set; } = "juan.delacruz@email.com";

        [BindProperty]
        public string ContactNumber { get; set; } = "0917 123 4567";

        [BindProperty]
        public string Address { get; set; } = "Cebu City, Philippines";

        [BindProperty]
        public string MessengerLink { get; set; } = string.Empty;

        [BindProperty]
        public string OtherContactLink { get; set; } = string.Empty;

        [TempData]
        public string? StatusMessage { get; set; }

        public List<VerificationDocument> Documents { get; set; } = new();

        public void OnGet()
        {
            // TODO: replace with real owner data from the database
            Documents = new List<VerificationDocument>
            {
                new VerificationDocument { Title = "Business / Mayor's Permit", FileName = "business_permit.pdf", Verified = true },
                new VerificationDocument { Title = "Government ID", FileName = "gov_title.pdf", Verified = true },
                new VerificationDocument { Title = "Certificate of Property Ownership", FileName = "land_title.pdf", Verified = false },
            };
        }

        public IActionResult OnPostSaveChanges()
        {
            // TODO: persist to the database once storage is wired up
            StatusMessage = "Profile changes saved.";
            return RedirectToPage();
        }

        public IActionResult OnPostLogout()
        {
            return RedirectToPage("/LoginOwner");
        }

        public IActionResult OnPostDashboard()
        {
            return RedirectToPage("/DashboardOwner");
        }
    }
}