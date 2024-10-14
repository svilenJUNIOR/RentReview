using Microsoft.AspNetCore.Mvc;
using RentReview.Services.Property;

namespace RentReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : Controller
    {
        private readonly IPropertyService propertyService;

        public PropertyController(IPropertyService propertyService) => this.propertyService = propertyService;

        [HttpGet]
        public IActionResult All()
        {
            if (propertyService.ViewProperties().Count < 1)
            {
                return View("EmptyList");
            }
            return Ok(propertyService.ViewProperties());
        }
    }
}
