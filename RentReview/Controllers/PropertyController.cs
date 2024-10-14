using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RentReview.Extensions;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
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

        public async Task<IActionResult> All()
        {
            var client = new HttpClient();
            var result = await client.GetAsync("https://localhost:44315/api/Property");

            var jsonString = await result.Content.ReadAsStringAsync();

            // Deserialize the JSON string to a list of ViewPropertyViewModel
            var toAdd = JsonConvert.DeserializeObject<List<ViewPropertyViewModel>>(jsonString);

            return View(toAdd);
        }

        [HttpPost]
        public IActionResult All(FilterPropertyDataModel data)
        {
            if (data != null)
            {
                var properties = propertyService.FilterProperties(data);

                if (properties.Count() > 0)
                    return View(propertyService.ViewProperties(properties));
                else
                    return View("EmptyFiltered");
            }

            return View(propertyService.ViewProperties());
        }

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
                bool check = this.ModelState.IsValid;
                await this.propertyService.AddAsync(data, await this.user(), check);
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
