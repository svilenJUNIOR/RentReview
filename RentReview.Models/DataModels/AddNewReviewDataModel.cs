namespace RentReview.Models.DataModels
{
    public class AddNewReviewDataModel
    {
        public string PropertyId { get; set; }
        public string Rented { get; set; }
        public string Vacated { get; set; }
        public ICollection<string> Pros { get; set; } = new List<string>();
        public ICollection<string> Cons { get; set; } = new List<string>();
        public string LandlordReview { get; set; }
        public string NeighbourReview { get; set; }
        public string PropertyReview { get; set; }
    }
}
