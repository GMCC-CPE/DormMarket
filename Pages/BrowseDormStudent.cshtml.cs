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
        public int MaxPrice { get; set; } = 10000;

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

        [BindProperty(SupportsGet = true)]
        public string Search { get; set; } = string.Empty;

        public List<DormListingItem> Results { get; set; } = new();

        public void OnGet()
        {
            //load all dorm from all owner
        }

        public IActionResult OnPostProfile()
        {
            return RedirectToPage("/ProfileStudent");
        }
    }

    public class DormRoomInfo
    {
        public string Price { get; set; } = "";
    }

    public class DormListingItem
    {
        public string Id { get; set; } = "";
        public string Name { get; set; } = "";
        public string Location { get; set; } = "";
        public List<DormRoomInfo> Rooms { get; set; } = new();
    }
}