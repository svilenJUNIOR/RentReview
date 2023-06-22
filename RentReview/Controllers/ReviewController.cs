using Microsoft.AspNetCore.Mvc;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult ViewReview()
        {
            return View();
        }
    }
}
