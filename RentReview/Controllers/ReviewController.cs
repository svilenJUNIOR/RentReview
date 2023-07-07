using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Review;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IBindService bindService;

        public ReviewController(IReviewService reviewService, IBindService bindService)
        {
            this.reviewService = reviewService;
            this.bindService = bindService;
        }

        public IActionResult ViewReview()
        => View();
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
        => View(this.bindService.ViewReviews());
    }
}
