using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.User;

namespace RentReview.Controllers
{
    public class UserController : Controller
    {
        private readonly IValidator validator;
        private readonly IUserService userService;

        public UserController(IValidator validator, IUserService userService)
        {
            this.validator = validator;
            this.userService = userService;
        }

        public IActionResult Register()
        => View();

        public IActionResult Login()
        => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDataModel data)
        {
            var errors = await validator.ValidateUserRegister(data);

            if (!errors.Any())
            {
                await this.userService.UserRegister(data);
                return Redirect("Login");
            }

            return View("./Error", errors);
        }
    }
}
