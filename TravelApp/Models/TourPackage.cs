using System.ComponentModel.DataAnnotations;

namespace TravelApp.Models
{
    public class TourPackage
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [RegularExpression(@"^[a-zA-Zа-яА-Я- ]+$", ErrorMessage = "Only letters and the symbol '-' are allowed.")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(500)]
        public string Description { get; set; }

        [Required]
        [Range(1, 1000000)]
        public decimal Price { get; set; }

        [Required]
        public int Duration { get; set; }

        [Required]
        [Range(1, 500)]
        public int Capacity { get; set; }
    }
}
