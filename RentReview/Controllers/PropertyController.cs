using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels;
using RentReview.Services.Property;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService propertyService;
        private readonly UserManager<IdentityUser> userManager;

        public PropertyController(IPropertyService propertyService, UserManager<IdentityUser> userManager)
        {
            this.propertyService = propertyService;
            this.userManager = userManager;
        }

        private async Task<IdentityUser> user() => await this.userManager.FindByNameAsync(this.User.Identity.Name);
        public IActionResult All()
         => View(propertyService.ViewProperties());

        [Authorize]
        public IActionResult Add()
          => View();

        [Authorize]
        public IActionResult Edit(string Id)
        => View(this.propertyService.ViewPropertyForEdit(Id));

        [Authorize]
        public async Task<IActionResult> Delete(string Id)
        {
            await this.propertyService.Remove(Id);
            return Redirect("/User/Profile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            try
            {
                await this.propertyService.AddAsync(data, await this.user());
                return Redirect("All");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditPropertyDataModel data, string Id)
        {
            data.Id = Id;
            this.propertyService.Edit(data);
            return Redirect("/User/Profile");
        }
    }
}
