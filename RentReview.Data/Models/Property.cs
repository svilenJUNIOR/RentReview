using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentReview.Data.Models
{
    public class Property
    {
        [Key]
        public string Id { get; set; }  = Guid.NewGuid().ToString();
        public string Address { get; set; }
        public int Price { get; set; }
        public string ReviewOfLandlord { get; set; }
        public string ReviewOfProperty { get; set; }
        public string ReviewOfNeighbour { get; set; }

        [NotMapped]
        public ICollection<string> Pros { get; set; } = new List<string>();

        [NotMapped]
        public ICollection<string> Cons { get; set; } = new List<string>();
        public DateTime Rented { get; set; }
        public DateTime Vacated { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
    }
}
