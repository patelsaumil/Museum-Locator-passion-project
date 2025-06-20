using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }

        [Required]
        public string FacilityName { get; set; } = string.Empty;

        public ICollection<MuseumFacility> MuseumFacilities { get; set; } = new List<MuseumFacility>();
    }
}
