using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Property;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IBindService bindService;
        private readonly IValidator validator;
        private readonly IPropertyService propertyService;
        public PropertyController(IValidator validator, IBindService bindService, IPropertyService propertyService)
        {
            this.bindService = bindService;
            this.validator = validator;
            this.propertyService = propertyService;
        }

        public IActionResult All()
         => View(bindService.ViewProperties());

        public IActionResult Add()
          => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            var errors = validator.ValidateAddProperty(data);

            if (!errors.Any())
            {
                await this.propertyService.AddAsync(data);
                return Redirect("All");
            }

            return View("./Error", errors);
        }
    }
}
