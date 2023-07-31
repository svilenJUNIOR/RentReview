namespace RentReview.Models.ViewModels.Property
{
    public class ViewPropertyViewModel
    {
        public string Id { get; set; }
        public string Address { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
        public bool HasReview { get; set; }
        public string? ReviewId { get; set; }
    }
}
