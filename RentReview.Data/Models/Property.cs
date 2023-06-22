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
        public string Pros { get; set; }
        public string Cons { get; set; }

        [Column("Rented", TypeName = "Date")]
        public DateTime Rented { get; set; }

        [Column("Vacated", TypeName = "Date")]
        public DateTime Vacated { get; set; }
        public string? Picture { get; set; }
        public string? Url { get; set; }
    }
}
