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
        public string? ListingStatus { get; set; }
        public int ActiveListingsCount { get; set; }
        public List<OwnerListingItem> Listings { get; set; } = new();

        public void OnGet()
        {
            ActiveListingsCount = Listings.Count(l => l.Status == "Vacant" || l.Status == "Occupied");
        }

        public IActionResult OnPostListing()
        {
            return RedirectToPage("/BrowseDormOwner");
        }

        public IActionResult OnPostProfile()
        {
            return RedirectToPage("/ProfileOwner");
        }
    }

    public class OwnerListingItem
    {
        public string Id { get; set; } = "";
        public string Status { get; set; } = ""; // e.g. "Vacant" / "Occupied"
    }
}
