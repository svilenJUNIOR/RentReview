using Microsoft.AspNetCore.Mvc;

namespace RentReview.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        => View();

        public IActionResult Login()
        => View();
    }
}
