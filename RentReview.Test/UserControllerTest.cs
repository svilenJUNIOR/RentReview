using RentReview.Controllers;
using Xunit;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;

namespace RentReview.Test
{
    public class UserControllerTest
    {
        [Fact]
        public void RegisterMethodReturnCorrectView()
        {
            var userController = new UserController(null, null, null);

            var result = userController.Register();
            Assert.IsType<ViewResult>(result);
        }
    }
}
