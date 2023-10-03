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

        [Fact]
        public void AddViewShouldReturnView()
        {
            var reviewController = new ReviewController(null, null);
            var result = reviewController.Add();

            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void EditViewReturnViewWitchCorrectReview()
        {
            var Id = "07c6134c-1a84-4b89-b6bf-60ce04de0ecd";

            var fakeReviewService = A.Fake<IReviewService>();
            var reviewController = new ReviewController(fakeReviewService, null);

            A.CallTo(() => fakeReviewService.ViewFullReview(Id))
                .Returns(new ViewFullReviewViewModel());

            var result = reviewController.Edit(Id);
            var viewModel = Assert.IsType<ViewResult>(result);

            Assert.IsType<ViewFullReviewViewModel>(viewModel.Model);
        }

        [Fact]
        public void AddMethodShouldAdd()
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
            var testUser = new IdentityUser { Id = "22db8ef9-8c04-466a-be5c-1892b970765d" };

            A.CallTo(() => fakeReviewService.AddAsync(data, testUser, true))
                .Returns(Task.FromResult("AddAsync"));

            var result = reviewController.Add(data, "7a0569e3-094b-4d60-bffb-858377dd2261");

            var actionResult = Assert.IsType<RedirectResult>(result.Result);
            Assert.Equal("/Review/All", actionResult.Url);
        }
    }
}
