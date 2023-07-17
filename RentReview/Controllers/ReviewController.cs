using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Review;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        public ReviewController(IReviewService reviewService)
           => this.reviewService = reviewService;

        public IActionResult ViewReview(string Id)
        => View(this.reviewService.ViewFullReview(Id));
        public IActionResult Add()
        => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewReviewDataModel data, string Id)
        {
            data.PropertyId = Id;

            try
            {
                await this.reviewService.AddAsync(data);
                return Redirect("All");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        public IActionResult All()
        => View(this.reviewService.ViewReviews());
    }
}
