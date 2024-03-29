﻿using RentReview.Common;

namespace RentReview.Models.ViewModels.Property
{
    public class ViewPropertyViewModel
    {
        public string Id { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public int Price { get; set; }
        public string Picture { get; set; }
        public string Url { get; set; }
        public bool HasReview { get; set; }
        public string? ReviewId { get; set; }
        public HashSet<string> Cities { get; set; } = new HashSet<string>();
        public HashSet<string> Countries { get; set; } = new HashSet<string>();
        public List<string> Extras { get; set; } = Lists.GetExtras().ToList();
        public List<string> MinPrices { get; set; } = Lists.GetMinPrices().ToList();
        public List<string> MaxPrices { get; set; } = Lists.GetMaxPrices().ToList();
    }
}
