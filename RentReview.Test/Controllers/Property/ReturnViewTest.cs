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
    }
}
