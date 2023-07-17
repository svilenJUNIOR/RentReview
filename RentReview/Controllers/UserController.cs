using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;

namespace RentReview.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Register()
        => View();

        public IActionResult Login()
        => View();

        [HttpPost]
        public IActionResult Register(RegisterUserDataModel data)
        {
            return Redirect("Login");
        }
    }
}
