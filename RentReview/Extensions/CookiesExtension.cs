using Microsoft.AspNetCore.Mvc;

namespace RentReview.Extensions
{
    public static class CookiesExtension
    {
        public static void SetCookie(this Controller controller, string email)
        {
            var cookieOptions = CookieOptions(3);
            controller.Response.Cookies.Append("MyInfo", email, cookieOptions);
        }

        public static void DeleteCookie(this Controller controller)
        {
            var cookieOptions = CookieOptions(-3);
            controller.Response.Cookies.Delete("MyInfo", cookieOptions);
        }

        private static CookieOptions CookieOptions(int days)
        {
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Secure = true;
            cookieOptions.Expires = DateTime.Now.AddDays(days);

            return cookieOptions;
        }
    }
}
