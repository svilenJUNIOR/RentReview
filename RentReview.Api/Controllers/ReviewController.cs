using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Mvc;
using RentReview.Data;
using RentReview.Data.Models;
using RentReviewRepository;

namespace RentReview.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly RentDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public ReviewController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, RentDbContext context)
        {
            this.roleManager = roleManager;
            this.context = context;
            this.userManager = userManager;
        }

        // GET: api/<ReviewController>
        [HttpGet]
        public async Task<IdentityRole> Get()
        {
            throw new NotImplementedException();
        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public async Task<Review> Get(string id)
        {
            throw new NotImplementedException();
        }

        // POST api/<ReviewController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ReviewController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ReviewController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
