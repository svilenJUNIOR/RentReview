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
        private readonly RentDbContext db = new RentDbContext();
        // GET: api/<ReviewController>
        [HttpGet]
        public ICollection<Review> Get()
        {
            var context = new Repository(null, null, db);
            var list = context.GettAll<Review>();
            return list;

        }

        // GET api/<ReviewController>/5
        [HttpGet("{id}")]
        public async Task<Review> Get(string id)
        {
            var context = new Repository(null, null, db);
            return await context.FindByIdAsync<Review>(id);
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
