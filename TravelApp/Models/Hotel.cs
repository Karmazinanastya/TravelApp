using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class Hotel
    {
           
        
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я- ]+$", ErrorMessage = "Only letters and the symbol '-' are allowed.")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я0-9\s\.,!?@#\$%\^&\*()_+-=\[\]{}|;:'""<>\?\/\\]*$")]
        public string Location { get; set; }

        [Required]
        [Range (1, 500)]
        public int Capacity { get; set; }

        [Required]
        [Range(1, 5)]
        public int Stardom { get; set;}
    }
}
