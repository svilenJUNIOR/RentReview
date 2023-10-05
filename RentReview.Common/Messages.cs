namespace RentReview.Common
{
    public static class Messages
    {
        public static readonly string EmptyFields = "Form cannot contain empty fields";

        // Add property errors
        public static readonly string CityTooShort = "City name must be at least 3 symbols long!";
        public static readonly string CountryTooShort = "Country name must be at least 3 symbols long!";
        public static readonly string PriceBelowZero = "Price can not be less than zero!";

        // Add review errors
        public static readonly string VacatedBeforeRented = "Vacated date cannot possibly be before Rented date!";
        public static readonly string EmptyPros = "Select at least one element from \"Pros\"!";
        public static readonly string EmptyCons = "Select at least one element from \"Cons\"!";
        public static readonly string EmptyLandlordReview = "Landlord review must be at least 10 symbols long!";
        public static readonly string EmptyNeighbourReview = "Neighbour review must be at least 10 symbols long!";
        public static readonly string EmptyPropertyReview = "Property review must be at least 10 symbols long!";

        // User register errors
        public static readonly string WrongEmailFormat = "Email must end with @email.com!";
        public static readonly string EmailExists = "There is an account corresponding to that email!";
        public static readonly string ShortPassword = "Password must be at least 8 symbols long!";
        public static readonly string WeakPassword = "Password must contain number and an uppercase letter!";
        public static readonly string UsernameExists = "Someone is using that username! Sorry!";
        public static readonly string UsernameTooShort = "Username must be at least 6 symbols long!";
        public static readonly string WrongUsernameFormat = "Username must contain only symbols from a-z/A-Z!";

        // User login errors
        public static readonly string UnExistingEmail = "User with that email does not exist!";
        public static readonly string UnExistingPassword = "User with that password does not exist!";
    }
}
