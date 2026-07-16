using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class DashboardListing
    {
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "Vacant";
    }

    public class DashboardOwner : PageModel
    {
        public List<DashboardListing> Listings { get; set; } = new();

        public int ActiveListingsCount => Listings.Count;

        public void OnGet()
        {
            // TODO: replace with real data from the database
            Listings = new List<DashboardListing>
            {
                new DashboardListing { Name = "Dormitory 1", Status = "Vacant" },
                new DashboardListing { Name = "Dormitory 2", Status = "Vacant" },
                new DashboardListing { Name = "Dormitory 3", Status = "Vacant" },
                new DashboardListing { Name = "Dormitory 4", Status = "Vacant" },
            };
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
}