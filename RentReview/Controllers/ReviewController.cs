using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services.Review;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;

        public ReviewController(IReviewService reviewService)
          => this.reviewService = reviewService;

        public IActionResult ViewReview()
        {
            return View();
        }
        public IActionResult Add()
        => View();

        [HttpPost]
        public IActionResult Add(AddNewReviewDataModel data, string Id)
        {
            data.PropertyId = Id;
            this.reviewService.Add(data);
            return View();
        }

        public IActionResult All()
        {
            return View();
        }
    }
}
