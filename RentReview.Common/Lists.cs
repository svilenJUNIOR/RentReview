namespace RentReview.Common
{
    public static class Lists
    {
        private static List<string> Pros  = new List<string>
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

        public static List<string>  GetPros() => Pros;
    }
}
