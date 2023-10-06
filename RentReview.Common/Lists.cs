using System.Diagnostics;

namespace RentReview.Common
{
    public static class Lists
    {
        private static List<string> Pros = new List<string>
        {
            {"Near School / kindergarden"},
            {"Near 24/7 pharmacy"},
            {"Near hospital / clinic"},
            {"Near 24/7 supermarket"},
            {"Near a bus stop"},
            {"Quiet street"},
            {"Clean street"},
            {"Has garage"},
            {"Has elevetor"},
            {"Easy to warm up"},
            {"Easy to cool down"},
            {"Has a private pool for ten"},
            {"Has a private gym for tena"},
            {"Has a private park for ten"},
            {"Employeed cleaning crew fo"},
            {"Has security"},
            {"Low crime"},
            {"Allows pets"},
            {"Good neighbours"},
            {"Good landlord "}
        };

        private static List<string> Cons = new List<string>
        {
            {"Noisy"},
            {"Dirty"},
            {"Poor district"},
            {"Crime"},
            {"No elevator"},
            {"It's not close by bus stop"},
            {"It's not close by hospital / clinic"},
            {"It's not close by pharmacy"},
            {"It's not close by school / kindergarden"},
            {"Doesnt allow pets"},
            {"Hard to find a parking space"},
            {"Bad neighbours"},
            {"Bad landlord"}
        };

        private static List<string> MinPrices = new List<string>
        {
            { "500"},
            { "1000" },
            { "1500" }
        };

        private static List<string> MaxPrices = new List<string>
        {
             { "1000" },
            {  "1500" },
            {  "2000" }
        };
        public static List<string> GetPros() => Pros;
        public static List<string> GetCons() => Cons;
        public static List<string> GetExtras() => Pros;
        public static List<string> GetMinPrices() => MinPrices;
        public static List<string> GetMaxPrices() => MaxPrices;
    }
}
