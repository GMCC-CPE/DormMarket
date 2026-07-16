using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
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

        public List<Dormitory> Results { get; set; } = new();

        public void OnGet()
        {
            // TODO: replace with a real search/filter query once dorm listings are stored in a database
            Results = DummyDormitories.All;
        }

        public IActionResult OnPostProfile()
        {
            return RedirectToPage("/ProfileStudent");
        }
    }
}