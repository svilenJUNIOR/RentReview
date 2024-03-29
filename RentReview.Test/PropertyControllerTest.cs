using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Controllers;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
using RentReview.Services.Property;
using System.Diagnostics.Metrics;
using System.Security.Claims;

namespace RentReview.Test
{
    public class PropertyControllerTest
    {
        [Fact]
        public void AllMethodShouldReturnListOfProperties()
        {
            var fakePropertyService = A.Fake<IPropertyService>();

            A.CallTo(() => fakePropertyService.ViewProperties())
                .Returns(A.CollectionOfFake<ViewPropertyViewModel>(1));

            var propertyController = new PropertyController(fakePropertyService, null);

            var result = propertyController.All();
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<ViewPropertyViewModel>>(viewResult.Model);
            Assert.Equal(1, model.Count());
        }

        [Fact]
        public void AddMethodShouldReturnView()
        {
            var propertyController = new PropertyController(null, null);

            var result = propertyController.Add();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void AddMethodShouldAdd()
        {
            var fakePropertyService = A.Fake<IPropertyService>();
            var fakeUserManager = A.Fake<UserManager<IdentityUser>>();

            var dataToAdd = new AddNewPropertyDataModel()
            {
                Country = "Bulgaria",
                City = "Varna",
                Picture = "ngfx",
                Price = 400,
                Url = "herhe"
            };

            var testUser = new Microsoft.AspNetCore.Identity.IdentityUser
            {
                Id = "2b07b5a9-6603-4043-bbd5-ba9cf48c92ee"
            };

            A.CallTo(() => fakePropertyService.AddAsync(dataToAdd, testUser, true))
                .Returns(Task.FromResult("AddAsync"));

            var propertyController = new PropertyController(fakePropertyService, fakeUserManager)
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

            var result = propertyController.Add(dataToAdd);
            Assert.IsType<RedirectResult>(result.Result);
        }

        [Fact]
        public void EditShouldReturnViewWithModel()
        {
            var fakePropertyService = A.Fake<IPropertyService>();

            A.CallTo(() => fakePropertyService.ViewPropertyForEdit("f3eac4de-5348-4555-9108-f5f465824005"))
                .Returns(new ViewPropertyViewModel());

            var propertyController = new PropertyController(fakePropertyService, null);

            var result = propertyController.Edit("f3eac4de-5348-4555-9108-f5f465824005");
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<ViewPropertyViewModel>(viewResult.ViewData.Model);
        }

        [Fact]
        public async void DeleteShouldDelete()
        {
            var fakePropertyService = A.Fake<IPropertyService>();
            A.CallTo(() => fakePropertyService.Remove("13ab86b4-09b5-48de-b7cb-4ea50d68e990"))
                .Returns(Task.FromResult("Remove"));

            var propertyController = new PropertyController(fakePropertyService, null);

            var result = propertyController.Delete("13ab86b4-09b5-48de-b7cb-4ea50d68e990");
            var actionResult = Assert.IsType<RedirectResult>(result.Result);

            Assert.Equal("/User/Profile", actionResult.Url);
        }

        [Theory]
        [InlineData("7a0569e3-094b-4d60-bffb-858377dd2261")]
        public async void EditChangesInfoSuccessfully(string Id)
        {
            var fakePropertyService = A.Fake<IPropertyService>();

            var newData = new EditPropertyDataModel
            {
                Country = "Bulgaria",
                City = "Varna",
                Id = Id,
                PictureUrl = "data:image/jpeg;base64,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",
                Price = 600
            };

            A.CallTo(() => fakePropertyService.Edit(newData, true))
                .Returns(Task.FromResult("Edit"));

            var propertyController = new PropertyController(fakePropertyService, null);
            var result = propertyController.Edit(newData, Id);

            var actionResult = Assert.IsType<RedirectResult>(result.Result);

            Assert.Equal("/User/Profile", actionResult.Url);
        }
    }
}