using Microsoft.AspNetCore.Mvc;
using RentReview.Models;
using System.Diagnostics;

namespace RentReview.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;

        public HomeController(ILogger<HomeController> logger)
        => logger = logger;

        public IActionResult Index()
        => RedirectToAction("All", "Review");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}