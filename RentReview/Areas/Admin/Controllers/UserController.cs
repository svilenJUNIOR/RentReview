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

        public async Task<IActionResult> Manage()
        => View(await this.adminService.GetAllUsers());

        public async Task<IActionResult> DeleteUser(string Id)
        {
            await this.adminService.DeleteUser(Id);
            return Redirect("Manage");
        }
        public async Task<IActionResult> PromoteUser(string Id)
        {
            await this.adminService.PromoteUser(Id);
            return Redirect("Manage");
        }
        public async Task<IActionResult> DemoteUser(string Id)
        {
            await this.adminService.DemoteUser(Id);
            return Redirect("Manage");
        }
    }
}
