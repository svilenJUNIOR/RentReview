using RentReview.Controllers;
using Xunit;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using RentReview.Services.User;
using Microsoft.AspNetCore.Identity;
using RentReview.Models.ViewModels.Property;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;
using RentReview.Models.DataModels.User;

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

        [Fact]
        public void LoginMethodReturnCorrectView()
        {
            var userController = new UserController(null, null, null);

            var result = userController.Login();
            Assert.IsType<ViewResult>(result);
        }

        [Theory]
        [InlineData("22db8ef9-8c04-466a-be5c-1892b970765d")]
        public void ProfileMethodReturnListOfUsersProperties(string userId)
        {
            var fakeUserService = A.Fake<IUserService>();
            var fakeUserManager = A.Fake<UserManager<IdentityUser>>();

            var userController = new UserController(fakeUserService, null, fakeUserManager)
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

            var testUser = new IdentityUser() { Id = userId };

            A.CallTo(() => fakeUserService.LoadMyData(testUser))
                .Returns(new List<ViewPropertyViewModel>(1));

            var result = userController.Profile();
            var viewResult = Assert.IsType<ViewResult>(result.Result);

            Assert.IsAssignableFrom<ICollection<ViewPropertyViewModel>>(viewResult.ViewData.Model);
        }

        [Fact]
        public void RegisterMethodRegistersUser()
        {
            var fakeUserService = A.Fake<IUserService>();
            var userController = new UserController(fakeUserService, null, null);

            var data = new RegisterUserDataModel
            {
                Email = "test_email@email.com",
                Password = "test_password",
                Username = "Seksi_mladej"
            };

            A.CallTo(() => fakeUserService.UserRegisterAsync(data, true))
                .Returns(Task.FromResult("UserRegisterAsync"));

            var result = userController.Register(data);
            var viewResult = Assert.IsType<RedirectResult>(result.Result);
        }

        [Fact]
        
    }
}
