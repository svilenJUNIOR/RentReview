using Microsoft.AspNetCore.Mvc;
using RentReview.Extensions;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Property;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IBindService bindService;
        private readonly IPropertyService propertyService;
        public PropertyController(IBindService bindService, IPropertyService propertyService)
        {
            this.bindService = bindService;
            this.propertyService = propertyService;
        }

        public IActionResult All()
         => View(bindService.ViewProperties());

        public IActionResult Add()
          => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            try
            {
                await this.propertyService.AddAsync(data);
                return Redirect("Login");
            }
            catch (AggregateException exception)
            {
                return this.CatchErrors(exception);
            }
        }
    }
}
