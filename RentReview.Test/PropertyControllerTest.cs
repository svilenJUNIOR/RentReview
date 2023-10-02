using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Controllers;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
using RentReview.Services.Property;
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
                Address = "Varna Asparuhovo",
                Picture = "ngfx",
                Price = 400,
                Url = null
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
    }
}