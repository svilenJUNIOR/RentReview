using Microsoft.AspNetCore.Mvc;

namespace RentReview.Extensions
{
    public static class CookiesEstension
    {
        public static void SetCookie(this Controller controller, string email)
        {
            CookieOptions cookieOptions = new CookieOptions();

            cookieOptions.Secure = true;
            cookieOptions.Expires = DateTime.Now.AddDays(3);

            controller.Response.Cookies.Append("MyInfo", email, cookieOptions);
        }
    }
}
