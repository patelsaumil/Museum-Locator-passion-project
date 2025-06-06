using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class Museum_Facility
    {
        [Key]
        public int Museumfacility_Id { get; set; }

        public int Museum_Id { get; set; }

        public int Facility_Id { get; set; }

        
        public required Museum Museum { get; set; }

        public required Facility Facility { get; set; }
    }
}
