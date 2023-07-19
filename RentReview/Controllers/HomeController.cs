using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Models;
using System.Diagnostics;

namespace RentReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        public HomeController(RoleManager<IdentityRole> roleManager)
        => this.roleManager = roleManager;

        public async Task<IActionResult> Index()
        {
            var adminRole = new IdentityRole { Name= "admin" };
            var userRole = new IdentityRole { Name= "user" };

            await this.roleManager.CreateAsync(adminRole);
            await this.roleManager.CreateAsync(userRole);

            return RedirectToAction("All", "Review");
        }

        //public IActionResult Index()
        //=> RedirectToAction("All", "Review");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}