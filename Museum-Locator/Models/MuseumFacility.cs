using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Museum_Locator.Models
{
    public class MuseumFacility
    {
        [Key]
        public int MuseumFacilityId { get; set; }

        [ForeignKey("Museum")]
        public int MuseumId { get; set; }
        public Museum Museum { get; set; } = null!;

        [ForeignKey("Facility")]
        public int FacilityId { get; set; }
        public Facility Facility { get; set; } = null!;
    }
}
