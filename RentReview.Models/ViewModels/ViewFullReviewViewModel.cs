namespace RentReview.Models.ViewModels
{
    public class ViewFullReviewViewModel
    {
        public string Address { get; set; }
        public int Price { get; set; }
        public string ReviewOfLandlord { get; set; }
        public string ReviewOfProperty { get; set; }
        public string ReviewOfNeighbour { get; set; }
        public ICollection<string> Pros { get; set; } = new List<string>();
        public ICollection<string> Cons { get; set; } = new List<string>();
        public DateTime? Rented { get; set; }
        public DateTime? Vacated { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
    }
}
