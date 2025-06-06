using System.ComponentModel.DataAnnotations;

namespace Museum_Locator.Models
{
    public class User
    {
        [Key]
        public int User_Id { get; set; }

        public required string Name { get; set; }

        public required string Email { get; set; }

        public required string Password { get; set; }

        public ICollection<Feedback>? Feedbacks { get; set; }
    }
}
