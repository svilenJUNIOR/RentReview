using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using RentReview.Controllers;
using RentReview.Models.ViewModels.Review;
using RentReview.Services.Review;

namespace RentReview.Test
{
    public class ReviewControllerTest
    {
        [Fact]
        public void ViewReviewReturnViewWithCorrectReview()
        {
            var Id = "07c6134c-1a84-4b89-b6bf-60ce04de0ecd";
            var fakeReviewService = A.Fake<IReviewService>();

            A.CallTo(() => fakeReviewService.ViewFullReview(Id))
                .Returns(new ViewFullReviewViewModel());

            var reviewController = new ReviewController(fakeReviewService, null);

            var result = reviewController.ViewReview(Id);
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<ViewFullReviewViewModel>(viewResult.ViewData.Model);
        }
    }
}
