using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels;
using RentReview.Services.Review;

namespace RentReview.Controllers
{
    public class ReviewController : Controller
    {

        private readonly IReviewService reviewService;
        private readonly UserManager<IdentityUser> userManager;

        public ReviewController(IReviewService reviewService, UserManager<IdentityUser> userManager)
        {
            this.reviewService = reviewService;
            this.userManager = userManager;
        }

        private async Task<IdentityUser> user() => await this.userManager.FindByNameAsync(this.User.Identity.Name);

        public IActionResult ViewReview(string Id)
        => View(this.reviewService.ViewFullReview(Id));

        [Authorize]
        public IActionResult Add()
        => View();


        [Authorize]
        public IActionResult Edit(string Id)
        => View(this.reviewService.ViewFullReview(Id));

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewReviewDataModel data, string Id)
        {
            data.PropertyId = Id;

            try
            {
                await this.reviewService.AddAsync(data, await this.user());
                return Redirect("All");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(AddNewReviewDataModel data, string Id)
        {
            this.reviewService.Edit(data, Id);
            return Redirect("/User/Profile");
        }

        public IActionResult All()
        => View(this.reviewService.ViewReviews());
    }
}
