using Microsoft.AspNetCore.Mvc;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult ViewReview()
        {
            return View();
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
