using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RentReview.Models.DataModels.Property;
using RentReview.Services.Property;
using RentReview.Api.Extensions;
using System;

namespace RentReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task Delete([FromRoute] string Id)
        => await this.propertyService.Remove(Id);

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddNewPropertyDataModel data)
        {
            bool check = this.ModelState.IsValid;

            if (check)
            {
                try
                {
                    var user = await this.user();
                    await this.propertyService.AddAsync(data, user, check);
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
