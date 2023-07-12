using System.Net.NetworkInformation;

namespace RentReview.Common
{
    public static class Messages
    {
        public static readonly string EmptyFields = "Form cannot contain empty fields";
        // Add property errors
        public static readonly string AddressTooShort = "Address must be at least 10 symbols long!";
        public static readonly string PriceBelowZero = "Price can not be less than zero!";
    }
}
