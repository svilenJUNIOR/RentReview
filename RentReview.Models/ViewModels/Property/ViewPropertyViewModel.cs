using RentReview.Common;

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
        public List<string> Cities { get; set; } = new List<string>();
        public List<string> Countries { get; set; } = new List<string>();
        public List<string> Extras { get; set; } = Lists.GetExtras().ToList();
        public List<string> MinPrices { get; set; } = Lists.GetMinPrices().ToList();
        public List<string> MaxPrices { get; set; } = Lists.GetMaxPrices().ToList();
    }
}
