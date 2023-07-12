using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels;
using RentReview.Services;

namespace RentReview.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IBindService bindService;
        private readonly IValidator validator;
        public PropertyController(IValidator validator, IBindService bindService)
        {
            this.bindService = bindService;
            this.validator = validator;
        }

        public IActionResult All()
         => View(bindService.ViewProperties());

        public IActionResult Add()
          => View();

        [HttpPost]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            var errors = validator.ValidateAddProperty(data);

            if (!errors.Any()) return Redirect("All");

            return View("./Error", errors);
        }
    }
}
