using Microsoft.AspNetCore.Mvc;
using RentReview.Controllers;

namespace RentReview.Test.Controllers.Property
{
    public class ReturnViewTest
    {
        [Fact]
        public void AllActionReturnAllView()
        {
            var controller = new PropertyController();

            var action = controller.All();

            Assert.IsType<ViewResult>(action);
        }

        [Fact]
        public void AddActionReturnAllView()
        {
            var controller = new PropertyController();

            var action = controller.Add();

            Assert.IsType<ViewResult>(action);
        }
    }
}
