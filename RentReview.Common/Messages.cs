namespace RentReview.Common
{
    public static class Messages
    {
        public static readonly string EmptyFields = "Form cannot contain empty fields";

        // Add property errors
        public static readonly string AddressTooShort = "Address must be at least 10 symbols long!";
        public static readonly string PriceBelowZero = "Price can not be less than zero!";

        // Add review errors
        public static readonly string VacatedBeforeRented = "Vacated date cannot possibly be before Rented date!";
        public static readonly string EmptyPros = "Select at least one element from \"Pros\"!";
        public static readonly string EmptyCons = "Select at least one element from \"Cons\"!";
        public static readonly string EmptyLandlordReview = "Landlord review must be at least 10 symbols long!";
        public static readonly string EmptyNeighbourReview = "Neighbour review must be at least 10 symbols long!";
        public static readonly string EmptyPropertyReview = "Property review must be at least 10 symbols long!";
    }
}
