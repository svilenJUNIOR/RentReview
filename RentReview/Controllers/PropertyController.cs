using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Property;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService propertyService;
        private readonly IBindService bindService;
        public PropertyController(IPropertyService propertyService, IBindService bindService)
        {
            this.propertyService = propertyService;
            this.bindService = bindService;
        }

        public IActionResult All()
         => View(bindService.ViewProperties());

        public IActionResult Add()
          => View();

        [HttpPost]
        public async Task<IActionResult> Add(ViewPropertyDataModel data)
        {
            await this.propertyService.AddAsync(data);
            return Redirect("All");
        }
    }
}
