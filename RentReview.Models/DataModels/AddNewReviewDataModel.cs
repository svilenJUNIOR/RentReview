namespace RentReview.Models.DataModels
{
    public class AddNewReviewDataModel
    {
        public string PropertyId { get; set; }
        public DateTime Rented { get; set; }
        public DateTime Vacated { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string LandlordReview { get; set; }
        public string NeighbourReview { get; set; }
        public string PropertyReview { get; set; }
    }
}
