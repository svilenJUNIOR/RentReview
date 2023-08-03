using FakeItEasy;
using Microsoft.AspNetCore.Identity;
using RentReview.Controllers;
using RentReview.Models.ViewModels.Property;
using RentReview.Services.Property;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using RentReview.Areas.Admin.Controllers;

namespace RentReview.Test
{
    public class PropertyControllerTest
    {
        [Fact]
        public void AllMethodShouldReturnListOfArticles()
        {
            var fakePropertyService = A.Fake<IPropertyService>();

            A.CallTo(() => fakePropertyService.ViewProperties())
                .Returns(A.CollectionOfFake<ViewPropertyViewModel>(1));

            var propertyController = new PropertyController(fakePropertyService, null);

            var result = propertyController.All();
            var viewResult = Assert.IsType<ViewResult>(result);

            var model = Assert.IsAssignableFrom<IEnumerable<ViewPropertyViewModel>>(viewResult.Model);
            Assert.NotEmpty(model);
        }

        [Fact]
        public void AddMethodShouldReturnView()
        {
            var propertyController = new PropertyController(null, null);

            var result = propertyController.Add();
            Assert.IsType<ViewResult>(result);
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

            var model = Assert.IsType<ViewPropertyViewModel>;
        }
    }
}