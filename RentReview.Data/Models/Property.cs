namespace RentReview.Data.Models
{
    public class Property
    {
        public string Id = Guid.NewGuid().ToString();
        public string Address { get; set; }
        public int Price { get; set; }
        public string ReviewOfLandlord { get; set; }
        public string ReviewOfProperty { get; set; }
        public string ReviewOfNeighbour { get; set; }
        public ICollection<string> Pros { get; set; }
        public ICollection<string> Cons { get; set; }
        public DateTime Rented { get; set; }
        public DateTime Vacated { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
    }
}
