using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class Museum
    {
        [Key]
        public int Museum_Id { get; set; }

        public required string Museum_Name { get; set; }

        public required string Location { get; set; }

        public required string Category { get; set; }

        public required string Details { get; set; }

        public ICollection<Facility>? Facilities { get; set; }

        public ICollection<Museum_Facility>? MuseumFacilities { get; set; }




    }
}
