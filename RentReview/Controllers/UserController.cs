using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels;
using RentReview.Services.User;

namespace RentReview.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
         => this.userService = userService;

        public IActionResult Register()
        => View();

        public IActionResult Login()
        => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDataModel data)
        {
            try
            {
                await this.userService.UserRegister(data);
                return Redirect("Login");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }
    }
}
