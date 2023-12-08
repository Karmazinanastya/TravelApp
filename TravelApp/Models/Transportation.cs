using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class Transportation
    {
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[a-zA-Zа-яА-Я ]+$", ErrorMessage = "Only letters are allowed.")]
        public string Mode { get; set; }

        [Required]
        [Range(1, 100)]
        public int capacity { get; set; }
    }
}
