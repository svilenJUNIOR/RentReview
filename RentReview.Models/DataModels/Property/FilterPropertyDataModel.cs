using System.ComponentModel;

namespace RentReview.Models.DataModels.Property
{
    public class FilterPropertyDataModel
    {
        public int MinPrice { get; set; }
        public int MaxPrice { get; set; }

        [DefaultValue(null)]
        public string? Country { get; set; }
        [DefaultValue(null)]
        public string? City { get; set; }
        [DefaultValue(null)]
        public string? OnlyWithReview { get; set; }
        [DefaultValue(null)]
        public List<string>? Extras { get; set; } = new List<string>();
    }
}