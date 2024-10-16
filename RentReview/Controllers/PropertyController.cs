using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentReview.Extensions;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
using RentReview.Services;
using RentReview.Services.Property;
using System.Text;

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
            var property = await this.apiService.Edit("/Edit/" + Id);

            if (property != null) View(property);

            return View();
        }

        [Authorize]
        public async Task<IActionResult> Delete(string Id)
        {
            var result = await this.apiService.Delete("/Delete/" + Id);

            return Redirect("/User/Profile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            var user = await this.user();
            await this.apiService.Add(data, user.Id,"/Add");
            return Redirect("/User/Profile");
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Edit(EditPropertyDataModel data, string Id)
        {
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
