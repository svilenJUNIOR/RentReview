namespace RentReview.Models.DataModels.Property
{
    public class FilterPropertyDataModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string OnlyWithReview { get; set; }
        public List<string> Extras { get; set; } = new List<string>();
    }
}