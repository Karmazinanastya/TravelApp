using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class Сlient
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я- ]+$", ErrorMessage = "Only letters and the symbol '-' are allowed.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я- ]+$", ErrorMessage = "Only letters and the symbol '-' are allowed.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression(@"^[0-9+]+$")]
        public string Phone { get; set; }
    }
}
