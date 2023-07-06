using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        public IActionResult ViewReview()
        {
            return View();
        }
        public IActionResult Add()
        => View();

        [HttpPost]
        public IActionResult Add(AddNewReviewDataModel data)
        {
            return View();
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
