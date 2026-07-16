using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GMCC.Pages
{
    public class ManageDormOwner : PageModel
    {
        [BindProperty]
        public string Id { get; set; } = string.Empty;

        [BindProperty]
        public string DormitoryName { get; set; } = string.Empty;

        [BindProperty]
        public List<RoomTypeRow> Rooms { get; set; } = new();

        [TempData]
        public string? ListingStatus { get; set; }

        public IActionResult OnGet(string id)
        {
            var dorm = DummyDormitories.All.FirstOrDefault(d => d.Id == id);
            if (dorm == null)
            {
                return RedirectToPage("/DashboardOwner");
            }

            Id = dorm.Id;
            DormitoryName = dorm.Name;
            Rooms = dorm.Rooms;
            return Page();
        }

        public IActionResult OnPostSaveChanges()
        {
            var dorm = DummyDormitories.All.FirstOrDefault(d => d.Id == Id);
            if (dorm != null)
            {
                // TODO: persist to the database once storage is wired up
                dorm.Rooms = Rooms.Where(r => !string.IsNullOrWhiteSpace(r.RoomType)).ToList();
            }

            ListingStatus = $"\"{DormitoryName}\" was updated.";
            return RedirectToPage("/DashboardOwner");
        }

        public IActionResult OnPostDeleteListing()
        {
            var dorm = DummyDormitories.All.FirstOrDefault(d => d.Id == Id);
            if (dorm != null)
            {
                // TODO: persist to the database once storage is wired up
                DummyDormitories.All.Remove(dorm);
            }

            ListingStatus = $"\"{DormitoryName}\" was deleted.";
            return RedirectToPage("/DashboardOwner");
        }
    }
}
