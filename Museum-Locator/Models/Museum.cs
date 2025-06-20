using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class Museum
    {
        [Key]
        public int MuseumId { get; set; }

        [Required]
        public string MuseumName { get; set; } = string.Empty;

        [Required]
        public string MuseumLocation { get; set; } = string.Empty;

        [Required]
        public string MuseumCategory { get; set; } = string.Empty;

        [Required]
        public string MuseumDetails { get; set; } = string.Empty;

        public ICollection<MuseumFacility> MuseumFacilities { get; set; } = new List<MuseumFacility>();
        public ICollection<Feedback> Feedbacks { get; set; } = new List<Feedback>();
    }
}
