using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels.Property;
using RentReview.Services;
using RentReview.Services.Property;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService propertyService;
        private readonly IApiService apiService;
        private readonly UserManager<IdentityUser> userManager;
        public PropertyController(IPropertyService propertyService, UserManager<IdentityUser> userManager, IApiService apiService)
        {
            this.propertyService = propertyService;
            this.userManager = userManager;
            this.apiService = apiService;
        }

        private async Task<IdentityUser> user() => await this.userManager.FindByNameAsync(this.User.Identity.Name);

        public async Task<IActionResult> All()
        => View(await this.apiService.GetAllPropertiesAsync());


        [HttpPost]
        public async Task<IActionResult> All(FilterPropertyDataModel data) // RETURNS FILTERED PROPERTIES
        {
            var properties = await this.apiService.GetFilteredPropertiesAsync(data, "/Filtered");

            if (properties.Any()) return View(properties);

            return View("EmptyFiltered");
        }

        [Authorize]
        public IActionResult Add() => View();

        [Authorize]
        public async Task<IActionResult> Edit(string Id)
        {
            var property = await this.apiService.EditProperty("/Edit/" + Id);

            if (property != null) View(property);

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await this.apiService.DeleteProperty("/Delete/" + Id);

            return Redirect("/User/Profile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            try
            {
                bool check = this.ModelState.IsValid;

                var user = await this.user();
                await this.apiService.AddProperty(data, user.Id, $"/Add?isModelStateValid={check}");
            }

            catch (AggregateException exeption)
            {
                return this.CatchErrors(exeption);
            }
           

            return Redirect("/User/Profile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditPropertyDataModel data, string Id)
        {
            // data.id is property Id

            data.Id = Id;

            try
            {
                var check = this.ModelState.IsValid;
                this.propertyService.Edit(data, check);
                return Redirect("/User/Profile");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }

        }
    }
}
