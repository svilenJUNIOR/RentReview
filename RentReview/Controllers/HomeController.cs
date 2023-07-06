using Microsoft.AspNetCore.Mvc;
using RentReview.Models;
using System.Diagnostics;

namespace RentReview.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        => RedirectToAction("All", "Review");

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        => View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}