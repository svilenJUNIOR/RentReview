using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;
using RentReview.Services.Property;
using System;
using System.ComponentModel;

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
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            var validator = new Validator(null, null);

            var errors = validator.ValidateAddProperty(data);

            if (!errors.Any()) return Redirect("All");

            return View("./Error", errors);
        }
    }
}
