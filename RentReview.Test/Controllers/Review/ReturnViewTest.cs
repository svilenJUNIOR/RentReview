using Microsoft.AspNetCore.Mvc;
using RentReview.Controllers;

namespace RentReview.Test.Controllers.Review
{
    public class ReturnViewTest
    {
        [Fact]
        public void AllActionReturnAllView()
        {
            var controller = new ReviewController();

            var action = controller.All();

            Assert.IsType<ViewResult>(action);
        }

        [Fact]
        public void AddActionReturnAllView()
        {
            var controller = new ReviewController();

            var action = controller.Add();

            Assert.IsType<ViewResult>(action);
        }

        [Fact]
        public void ViewReviewActionReturnAllView()
        {
            var controller = new ReviewController();

            var action = controller.ViewReview();

            Assert.IsType<ViewResult>(action);
        }
    }
}
