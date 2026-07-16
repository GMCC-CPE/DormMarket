using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class ReviewDormStudent : PageModel
    {
        [BindProperty]
        public string Id { get; set; } = string.Empty;

        [BindProperty]
        public int Rating { get; set; }

        [BindProperty]
        public string ReviewText { get; set; } = string.Empty;

        public Dormitory Dorm { get; private set; } = new();

        // TODO: replace with the signed-in student's verification status once auth/session exists
        public bool IsVerifiedRenter { get; private set; } = true;

        public string? ErrorMessage { get; set; }

        public IActionResult OnGet(string id)
        {
            var dorm = DummyDormitories.All.FirstOrDefault(d => d.Id == id);
            if (dorm == null)
            {
                return RedirectToPage("/BrowseDormStudent");
            }

            Id = dorm.Id;
            Dorm = dorm;
            return Page();
        }

        public IActionResult OnPostSubmit()
        {
            var dorm = DummyDormitories.All.FirstOrDefault(d => d.Id == Id);
            if (dorm == null)
            {
                return RedirectToPage("/BrowseDormStudent");
            }

            if (Rating < 1 || string.IsNullOrWhiteSpace(ReviewText))
            {
                Dorm = dorm;
                ErrorMessage = "Please select a rating and write a short review.";
                return Page();
            }

            // TODO: persist to the database and attach the signed-in student once auth/session exists
            dorm.Reviews.Insert(0, new DormReview
            {
                ReviewerName = "You",
                Rating = Rating,
                Text = ReviewText,
                VerifiedRenter = IsVerifiedRenter,
                DatePosted = "Just now",
            });

            return RedirectToPage("/DormDetailsStudent", new { id = dorm.Id });
        }
    }
}
