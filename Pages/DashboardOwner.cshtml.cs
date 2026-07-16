using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class DashboardOwner : PageModel
    {
        [TempData]
        public string? ListingStatus { get; set; }

        public List<Dormitory> Listings { get; set; } = new();

        public int ActiveListingsCount => Listings.Count;

        public void OnGet()
        {
            Listings = DummyDormitories.All;
        }

        public IActionResult OnPostProfile()
        {
            return RedirectToPage("/ProfileOwner");
        }
    }
}