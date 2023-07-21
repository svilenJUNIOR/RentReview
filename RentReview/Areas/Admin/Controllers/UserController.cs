using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RentReview.Services.Admin;

namespace RentReview.Areas.Admin.Controllers
{
    [Area("admin")]
    [Authorize(Roles = "admin")]
    public class UserController : Controller
    {
        private readonly IAdminService adminService;
        public UserController(IAdminService adminService)
        => this.adminService = adminService;

        public IActionResult Delete()
        => View(this.adminService.GetAllUsers(this.User.IsInRole("admin")));
        public IActionResult Promote()
       => View(this.adminService.GetAllUsers(this.User.IsInRole("admin")));

        public async Task<IActionResult> DeleteUser(string Id)
        {
            await this.adminService.DeleteUser(Id);
            return Redirect("/Admin/Home");
        }
        public async Task<IActionResult> PromoteUser(string Id)
        {
            await this.adminService.PromoteUser(Id);
            return Redirect("/Admin/Home");
        }
    }
}
