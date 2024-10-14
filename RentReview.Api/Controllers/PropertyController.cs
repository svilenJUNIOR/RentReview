using Microsoft.AspNetCore.Mvc;

namespace RentReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return Ok("rabotq");
        }
    }
}
