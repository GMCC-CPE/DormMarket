using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class ProfileStudent : PageModel
    {
        [BindProperty]
        public string FullName { get; set; } = "Maria Santos";

        [BindProperty]
        public string Email { get; set; } = "maria.santos@email.com";

        [BindProperty]
        public string ContactNumber { get; set; } = "0921 567 8901";

        [BindProperty]
        public string Address { get; set; } = "Cebu City, Philippines";

        [TempData]
        public string? StatusMessage { get; set; }

        public string VerifiedSchool { get; set; } = "CIT";

        public string VerifiedRentalDorm { get; set; } = "Casa Verde Dormitory";

        public List<VerificationDocument> StudentVerification { get; set; } = new();

        public List<VerificationDocument> RentalVerification { get; set; } = new();

        public void OnGet()
        {
            // TODO: replace with real student data from the database
            StudentVerification = new List<VerificationDocument>
            {
                new VerificationDocument { Title = "CEBU INSTITUTE OF TECHNOLOGY-UNIVERSITY", FileName = "Student ID / COR - Jul 10, 2026", Verified = true },
            };

            RentalVerification = new List<VerificationDocument>
            {
                new VerificationDocument { Title = "Casa Verde Dormitory", FileName = "Proof of stay uploaded - Jul 12, 2026", Verified = true },
                new VerificationDocument { Title = "Add another dorm you've rented", FileName = "e.g. moved to a new place this semester", Verified = false },
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
            return RedirectToPage("/LoginStudent");
        }

        public IActionResult OnPostBrowse()
        {
            return RedirectToPage("/BrowseDormStudent");
        }
    }
}