using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Models;
using RentReview.Services.SeederService;
using System.Diagnostics;

namespace RentReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private ISeeder seeder;

        public HomeController(RoleManager<IdentityRole> roleManager, ISeeder seeder)
        {
            this.roleManager = roleManager;
            this.seeder = seeder;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var adminRole = new IdentityRole { Name= "admin" };
        //    var userRole = new IdentityRole { Name= "user" };

        //    await this.roleManager.CreateAsync(adminRole);
        //    await this.roleManager.CreateAsync(userRole);

        //    return RedirectToAction("All", "Review");
        //}
        public async Task<IActionResult> Seed()
        {
            await this.seeder.SeedUsers();
            await this.seeder.SeedRoles();
            await this.seeder.SeedUserRole();
            await this.seeder.SeedProperties();
            await this.seeder.SeedReviews();

            return Redirect("/");
        }

        public IActionResult Index()
        {
            if (this.User.IsInRole("admin")) return Redirect("Admin/Home");
            return RedirectToAction("All", "Review");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}