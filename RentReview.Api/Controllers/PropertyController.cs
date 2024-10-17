using Microsoft.AspNetCore.Mvc;
using RentReview.Api.Extensions;
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

        [HttpPost("Filtered")]
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

        [HttpGet("Edit/{Id}")]
        public IActionResult Edit([FromRoute] string Id)
        => Ok(this.propertyService.ViewPropertyForEdit(Id));

        [HttpDelete("Delete/{Id}")]
        public async Task<bool> Delete([FromRoute] string Id)
        => await this.propertyService.Remove(Id);

        [HttpPost("Add")]
        public async Task<IActionResult> Add([FromBody] AddNewPropertyDataModel data, [FromQuery] bool isModelStateValid)
        {
            if (Request.Headers.TryGetValue("UserId", out var userId))
            {
                try
                {
                    await this.propertyService.AddAsync(data, userId, isModelStateValid);
                }
                catch (AggregateException exception)
                {
                    return this.CatchErrors(exception);
                }
            }

            return Ok();
        }
    }
}
