using System.ComponentModel.DataAnnotations;

namespace RentReview.Data.Models
{
    public class Review
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public string UserId { get; set; }
        public string PropertyId { get; set; }
    }
}
