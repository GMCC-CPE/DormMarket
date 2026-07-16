using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class BrowseDormCard
    {
        public string Name { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
    }

    public class BrowseDormStudent : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string? Search { get; set; }

        [BindProperty(SupportsGet = true)]
        public int MaxPrice { get; set; } = 5000;

        [BindProperty(SupportsGet = true)]
        public List<string> NearSchools { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public List<string> RoomTypes { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public List<string> Curfew { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public List<string> ComfortRoom { get; set; } = new();

        [BindProperty(SupportsGet = true)]
        public List<string> Wifi { get; set; } = new();

        public List<BrowseDormCard> Results { get; set; } = new();

        public void OnGet()
        {
            // TODO: replace with a real search/filter query once dorm listings are stored in a database
            Results = new List<BrowseDormCard>
            {
                new BrowseDormCard { Name = "Casa-Verde Dormitory", Location = "Cebu City" },
                new BrowseDormCard { Name = "Blue Haven Residence", Location = "Cebu City" },
                new BrowseDormCard { Name = "Sunset Suites", Location = "Cebu City" },
                new BrowseDormCard { Name = "Green Court Dorm", Location = "Cebu City" },
                new BrowseDormCard { Name = "Maple Student Homes", Location = "Cebu City" },
                new BrowseDormCard { Name = "Riverside Dormitel", Location = "Cebu City" },
                new BrowseDormCard { Name = "Northgate Residences", Location = "Cebu City" },
                new BrowseDormCard { Name = "Harbor View Dorm", Location = "Cebu City" },
            };
        }

        public IActionResult OnPostProfile()
        {
            return RedirectToPage("/ProfileStudent");
        }
    }
}