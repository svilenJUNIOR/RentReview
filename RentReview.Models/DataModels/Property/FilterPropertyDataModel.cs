namespace RentReview.Models.DataModels.Property
{
    public class FilterPropertyDataModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }
        public ICollection<string> Filters { get; set; } = new HashSet<string>();
    }
}
