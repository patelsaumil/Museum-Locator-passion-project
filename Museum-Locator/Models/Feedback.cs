using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class Feedback
    {
        [Key]
        public int Feedback_Id { get; set; }

        public required string Comment { get; set; }

        public int User_Id { get; set; }

        public required virtual User User { get; set; }

        public int Museum_Id { get; set; }

        public required virtual Museum Museum { get; set; }
    }
}
