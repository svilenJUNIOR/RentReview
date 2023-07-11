using Microsoft.AspNetCore.Mvc;
using RentReview.Data.Models;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Review;
using RentReviewRepository;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService reviewService;
        private readonly IBindService bindService;
        private readonly IRepository repository;

        public ReviewController(IReviewService reviewService, IBindService bindService, IRepository repository)
        {
            this.reviewService = reviewService;
            this.bindService = bindService;
            this.repository = repository;
        }

        public IActionResult ViewReview(string Id)
        => View(this.bindService.ViewFullReview(this.repository.FindPropertyByReviewId(Id)));
        public IActionResult Add()
        => View();

        [HttpPost]
        public IActionResult Add(AddNewReviewDataModel data, string Id)
        {
            data.PropertyId = Id;
            this.reviewService.Add(data);
            return Redirect("All");
        }

        public IActionResult All()
        => View(this.bindService.ViewReviews());
    }
}
