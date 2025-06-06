using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class Facility
    {
        [Key]
        public int Facility_Id { get; set; }

        public required string Facility_Name { get; set; }

        public ICollection<Museum>? Museums { get; set; }

        public ICollection<Museum_Facility>? MuseumFacilities { get; set; }

    }
}
