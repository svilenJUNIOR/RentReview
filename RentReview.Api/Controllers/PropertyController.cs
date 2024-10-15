using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels.Property;
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
            if (propertyService.ViewProperties().Count <= 0)
                return NotFound();


            return Ok(propertyService.ViewProperties());
        }

        [HttpPost("filter")]
        public IActionResult All(FilterPropertyDataModel data)
        {
            if (data != null)
            {
                var properties = propertyService.FilterProperties(data);

                if (properties.Count() > 0)
                    return Ok(properties);

                else
                    return NotFound();
            }

            return BadRequest();
        }
    }
}
