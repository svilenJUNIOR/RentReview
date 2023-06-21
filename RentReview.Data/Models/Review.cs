namespace RentReview.Data.Models
{
    public class Review
    {
        public string Id = Guid.NewGuid().ToString();
        public string TenantId { get; set; }
        public string PropertyId { get; set; }
    }
}
