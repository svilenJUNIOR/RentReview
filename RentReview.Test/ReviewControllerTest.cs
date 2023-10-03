using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Controllers;
using RentReview.Models.DataModels.Review;
using RentReview.Models.ViewModels.Review;
using RentReview.Services.Review;
using System.Security.Claims;

namespace RentReview.Test
{
    public class ReviewControllerTest
    {
        [Theory]
        [InlineData("07c6134c-1a84-4b89-b6bf-60ce04de0ecd")]
        public void ViewReviewReturnViewWithCorrectReview(string reviewId)
        {
            var fakeReviewService = A.Fake<IReviewService>();

            A.CallTo(() => fakeReviewService.ViewFullReview(reviewId))
                .Returns(new ViewFullReviewViewModel());

            var reviewController = new ReviewController(fakeReviewService, null);

            var result = reviewController.ViewReview(reviewId);
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<ViewFullReviewViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public void AddViewShouldReturnView()
        {
            var reviewController = new ReviewController(null, null);
            var result = reviewController.Add();

            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData("07c6134c-1a84-4b89-b6bf-60ce04de0ecd")]
        public void EditViewReturnViewWitchCorrectReview(string reviewId)
        {
            var fakeReviewService = A.Fake<IReviewService>();
            var reviewController = new ReviewController(fakeReviewService, null);

            A.CallTo(() => fakeReviewService.ViewFullReview(reviewId))
                .Returns(new ViewFullReviewViewModel());

            var result = reviewController.Edit(reviewId);
            var viewModel = Assert.IsType<ViewResult>(result);

            Assert.IsType<ViewFullReviewViewModel>(viewModel.Model);
        }

        [Theory]
        [InlineData("22db8ef9-8c04-466a-be5c-1892b970765d", "7a0569e3-094b-4d60-bffb-858377dd2261")]
        public void AddMethodShouldAdd(string userId, string propertyId)
        {
            var fakeReviewService = A.Fake<IReviewService>();
            var fakeUserManager = A.Fake<UserManager<IdentityUser>>();

            var reviewController = new ReviewController(fakeReviewService, fakeUserManager)
            {
                ControllerContext = new ControllerContext
                {
                    HttpContext = new DefaultHttpContext
                    {
                        User = new System.Security.Claims.ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
                        {
                            new Claim(ClaimTypes.Name, "Test")
                        })),
                    }
                },
            };
            var data = new ReviewDataModel
            {
                Cons = new List<string>() { "ima mishki" },
                Pros = new List<string>() { "nqma mishki" },
                LandlordReview = "stara babka vre si nosa",
                NeighbourReview = "qka kaka prostira gola",
                PropertyId = "7a0569e3-094b-4d60-bffb-858377dd2261",
                PropertyReview = "stava za kuponi s tejki narkotici",
                Rented = "12/01/2000",
                Vacated = "14/04/2020"
            };
            var testUser = new IdentityUser { Id = userId };

            A.CallTo(() => fakeReviewService.AddAsync(data, testUser, true))
                .Returns(Task.FromResult("AddAsync"));

            var result = reviewController.Add(data, propertyId);

            var actionResult = Assert.IsType<RedirectResult>(result.Result);
            Assert.Equal("/Review/All", actionResult.Url);
        }

        [Theory]
        [InlineData("07c6134c-1a84-4b89-b6bf-60ce04de0ecd")]
        public void EditMethodShouldEdit(string reviewId)
        {
            var fakeReviewService = A.Fake<IReviewService>();
            var reviewController = new ReviewController(fakeReviewService, null);

            var data = new ReviewDataModel
            {
                Cons = new List<string>() { "ima mishki" },
                Pros = new List<string>() { "nqma mishki" },
                LandlordReview = "stara babka vre si nosa",
                NeighbourReview = "qka kaka prostira gola",
                PropertyId = "7a0569e3-094b-4d60-bffb-858377dd2261",
                PropertyReview = "stava za kuponi s tejki narkotici",
                Rented = "12/01/2000",
                Vacated = "14/04/2020"
            };

            A.CallTo(() => fakeReviewService.EditAsync(data, reviewId, true))
            .Returns(Task.FromResult("EditAsync"));

            var result = reviewController.Edit(data, reviewId);

            var actionResult = Assert.IsType<RedirectResult>(result.Result);
            Assert.Equal("/User/Profile", actionResult.Url);
        }

        [Theory]
        [InlineData("07c6134c-1a84-4b89-b6bf-60ce04de0ecd")]
        public void DeleteMEthodShouldDelete(string reviewId)
        {
            var fakeReviewService = A.Fake<IReviewService>();
            var reviewController = new ReviewController(fakeReviewService, null);

            A.CallTo(() => fakeReviewService.Remove(reviewId))
                .Returns(Task.FromResult("Remove"));

            var result = reviewController.Delete(reviewId);

            var actionResult = Assert.IsType<RedirectResult>(result.Result);
            Assert.Equal("/User/Profile", actionResult.Url);
        }

        [Fact]
        public void AllMethodReturnsViewWithListOfReviews()
        {
            var fakeReviewService = A.Fake<IReviewService>();
            var reviewController = new ReviewController(fakeReviewService, null);

            A.CallTo(() => fakeReviewService.ViewReviews())
                .Returns(new List<ViewReviewViewModel>(2));

            var result = reviewController.All();
            var viewResult = Assert.IsType<ViewResult>(result);

            Assert.IsAssignableFrom<ICollection<ViewReviewViewModel>>(viewResult.ViewData.Model);
        }
    }
}
