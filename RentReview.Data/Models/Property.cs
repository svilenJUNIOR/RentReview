using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentReview.Data.Models
{
    public class Property
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public int Price { get; set; }
        public string? ReviewOfLandlord { get; set; }
        public string? ReviewOfProperty { get; set; }
        public string? ReviewOfNeighbour { get; set; }
        public string? Pros { get; set; }
        public string? Cons { get; set; }
        public string? Rented { get; set; }
        public string? Vacated { get; set; }
        [Required]
        public string Picture { get; set; }
        [Required]
        public string Url { get; set; }
    }
}
