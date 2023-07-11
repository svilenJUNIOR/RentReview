using System.ComponentModel.DataAnnotations;

namespace RentReview.Data.Models
{
    public class Tenant
    {
        [Key]
        public string Id { get; set; } = Guid.NewGuid().ToString();
        [Required]
        [MinLength(2)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(2)]
        public string LastName { get; set; }
        public string FullName { get { return this.FirstName + " " + this.LastName; } }
        [Required]
        [Range(18, 100)]
        public int Age { get; set; }
    }
}
