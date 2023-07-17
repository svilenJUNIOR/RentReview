using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels;
using RentReview.Services.Property;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService propertyService;
        public PropertyController(IPropertyService propertyService)
        => this.propertyService = propertyService;

        public IActionResult All()
         => View(propertyService.ViewProperties());

        public IActionResult Add()
          => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            try
            {
                await this.propertyService.AddAsync(data);
                return Redirect("All");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }
    }
}
