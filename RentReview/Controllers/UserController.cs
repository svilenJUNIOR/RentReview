using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels.User;
using RentReview.Services.User;

namespace RentReview.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        public UserController(IUserService userService, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
            this.userManager = userManager;
        }
        private async Task<IdentityUser> user() => await this.userManager.FindByNameAsync(this.User.Identity.Name);

        public IActionResult Register()
        => View();
        public IActionResult Login()
        => View();

        [Authorize]
        public async Task<IActionResult> Profile()
        => View(this.userService.LoadMyData(await this.user()));

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUserDataModel data)
        {
            try
            {
                var check = this.ModelState.IsValid;
                await this.userService.UserRegisterAsync(data, check);
                return Redirect("Login");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserDataModel data)
        {
            try
            {
                var check = this.ModelState.IsValid;
                await this.userService.UserLoginAsync(data, check);
                this.SetCookie(data.Email);
                return Redirect("/");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        public async Task<IActionResult> Logout()
        {
            this.DeleteCookie();
            await this.signInManager.SignOutAsync();
            return Redirect("/");
        }
    }
}
