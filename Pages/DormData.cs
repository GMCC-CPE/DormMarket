using System.Collections.Generic;

namespace GMCC.Pages
{
    public class RoomTypeRow
    {
        public string RoomType { get; set; } = string.Empty;
        public string Price { get; set; } = string.Empty;
        public string Availability { get; set; } = "Available";
    }

    public class Dormitory
    {
        public string Id { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Status { get; set; } = "Vacant";
        public List<RoomTypeRow> Rooms { get; set; } = new();
    }

    // TODO: replace with real data from the database
    public static class DummyDormitories
    {
        public static List<Dormitory> All = new()
        {
            new Dormitory
            {
                Id = "casa-verde",
                Name = "Casa-Verde Dormitory",
                Status = "Vacant",
                Rooms = new List<RoomTypeRow>
                {
                    new RoomTypeRow { RoomType = "Shared (4 pax)", Price = "P 3,500", Availability = "Available" },
                    new RoomTypeRow { RoomType = "Solo Room", Price = "P 5,800", Availability = "Available" },
                },
            },
            new Dormitory
            {
                Id = "blue-haven",
                Name = "Blue Haven Residence",
                Status = "Vacant",
                Rooms = new List<RoomTypeRow>
                {
                    new RoomTypeRow { RoomType = "Shared (4 pax)", Price = "P 3,200", Availability = "Full" },
                    new RoomTypeRow { RoomType = "Solo Room", Price = "P 6,000", Availability = "Available" },
                },
            },
            new Dormitory
            {
                Id = "sunset-suites",
                Name = "Sunset Suites",
                Status = "Vacant",
                Rooms = new List<RoomTypeRow>
                {
                    new RoomTypeRow { RoomType = "Bedspace", Price = "P 2,000", Availability = "Available" },
                    new RoomTypeRow { RoomType = "Solo Room", Price = "P 5,500", Availability = "Full" },
                },
            },
            new Dormitory
            {
                Id = "green-court",
                Name = "Green Court Dorm",
                Status = "Vacant",
                Rooms = new List<RoomTypeRow>
                {
                    new RoomTypeRow { RoomType = "Shared (4 pax)", Price = "P 3,000", Availability = "Available" },
                    new RoomTypeRow { RoomType = "Bedspace", Price = "P 1,800", Availability = "Available" },
                },
            },
        };
    }
}
