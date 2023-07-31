using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels.Review;
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
        public async Task<IActionResult> Add(ReviewDataModel data, string Id)
        {
            data.PropertyId = Id;

            try
            {
                var check = this.ModelState.IsValid;
                await this.reviewService.AddAsync(data, await this.user(), check);
                return Redirect("All");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(ReviewDataModel data, string Id)
        {
            try
            {
                var check = this.ModelState.IsValid;
                await this.reviewService.EditAsync(data, Id, check);
                return Redirect("/User/Profile");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        [Authorize]
        public async Task<IActionResult> Delete(string Id)
        {
            await this.reviewService.Remove(Id);
            return Redirect("/User/Profile");
        }

        public IActionResult All()
        => View(this.reviewService.ViewReviews());
    }
}
