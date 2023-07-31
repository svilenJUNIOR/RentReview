using System.ComponentModel.DataAnnotations;

namespace RentReview.Models.DataModels
{
    public class AddNewReviewDataModel
    {
        public string? PropertyId { get; set; }

        [Required]
        public string Rented { get; set; }

        [Required]
        public string Vacated { get; set; }

        [Required]
        public ICollection<string> Pros { get; set; } = new List<string>();

        [Required]
        public ICollection<string> Cons { get; set; } = new List<string>();

        [Required]
        public string LandlordReview { get; set; }

        [Required]
        public string NeighbourReview { get; set; }

        [Required]
        public string PropertyReview { get; set; }
    }
}
