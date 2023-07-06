using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReviewRepository;

namespace RentReview.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;
        private readonly UserManager<IdentityUser> userManager;
        public ReviewService(IRepository repository, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.userManager = userManager;
        }
        public async Task Add(AddNewReviewDataModel data)
        {
            // get id of property
            // find correct property
            //var property = await this.repository.FindByIdAsync<Data.Models.Property>(data.PropertyId);
            //var userId = this.userManager.Users.First().Id;

            //var Review = new Data.Models.Review(
            //    {
            //    PropertyId = this.property.Id,
            //    TenantId = userId,
            //}
            //);
        }
    }
}
