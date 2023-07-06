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
            var property =  this.repository.FindById<Data.Models.Property>(data.PropertyId);
            //var userId = this.userManager.Users.First().Id;

            var Review = new Data.Models.Review
            {
                PropertyId = property.Id, 
                TenantId = "1b379a1d-cce3-4c66-be74-763079abe28e"
            };

            property.ReviewOfProperty = data.PropertyReview;
            property.ReviewOfLandlord = data.LandlordReview;
            property.ReviewOfNeighbour = data.NeighbourReview;
            property.Rented = data.Rented;
            property.Vacated= data.Vacated;
            property.Pros = data.Pros;
            property.Cons = data.Cons;

            await this.repository.AddAsync<Data.Models.Review>(Review);

            await this.repository.SaveChangesAsync();
        }
    }
}
