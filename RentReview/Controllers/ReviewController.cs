using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Review;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IValidator validator;
        public ReviewController(IReviewService reviewService, IValidator validator)
        {
            this.reviewService = reviewService;
            this.validator = validator;
        }

        public IActionResult ViewReview(string Id)
        => View(this.reviewService.ViewFullReview(Id));
        public IActionResult Add()
        => View();

        [HttpPost]
        public IActionResult Add(AddNewReviewDataModel data, string Id)
        {
            data.PropertyId = Id;
            var errors = this.validator.ValidateAddReview(data);

            if (!errors.Any())
            {
                this.reviewService.Add(data);
                return Redirect("All");
            }

            return View("./Error", errors);
        }

        public IActionResult All()
        => View(this.reviewService.ViewReviews());
    }
}
