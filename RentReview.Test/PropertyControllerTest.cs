using FakeItEasy;
using Microsoft.AspNetCore.Identity;
using RentReview.Controllers;
using RentReview.Models.ViewModels.Property;
using RentReview.Services.Property;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace RentReview.Test
{
    public class PropertyControllerTest
    {
        [Fact]
        public void AllMethodShouldReturnListOfArticles()
        {
            var fakePropertyService = A.Fake<IPropertyService>();
            var fakeUserManager = A.Fake<UserManager<IdentityUser>>();

            A.CallTo(() => fakePropertyService.ViewProperties())
                .Returns(A.CollectionOfFake<ViewPropertyViewModel>(1));

            var propertyController = new PropertyController(fakePropertyService, fakeUserManager);

            var result = propertyController.All();
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<ViewPropertyViewModel>>(viewResult.Model);
            Assert.NotEmpty(model);
        }
    }
}