using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class AddDormOwner : PageModel
    {
        [BindProperty]
        public string DormitoryName { get; set; } = string.Empty;

        [BindProperty]
        public string AddressLocation { get; set; } = string.Empty;

        [BindProperty]
        public string Description { get; set; } = string.Empty;

        [BindProperty]
        public string MonthlyRent { get; set; } = string.Empty;

        [BindProperty]
        public string? Curfew { get; set; }

        [BindProperty]
        public string? ComfortRoom { get; set; }

        [BindProperty]
        public string? RoomType { get; set; }

        [BindProperty]
        public List<string> NearSchools { get; set; } = new();

        [BindProperty]
        public List<string> Amenities { get; set; } = new();

        public void OnGet()
        {
        }

        public IActionResult OnPostPublish()
        {
            // TODO: persist the listing once storage is wired up
            TempData["ListingStatus"] = $"\"{DormitoryName}\" was published.";
            return RedirectToPage("/DashboardOwner");
        }

        public IActionResult OnPostDraft()
        {
            // TODO: persist the draft once storage is wired up
            TempData["ListingStatus"] = $"\"{DormitoryName}\" was saved as a draft.";
            return RedirectToPage("/DashboardOwner");
        }
    }
}