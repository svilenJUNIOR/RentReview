using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.Review;
using RentReview.Models.ViewModels.Review;
using RentReviewRepository;
using System.Text;

namespace RentReview.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly IRepository repository;
        private readonly IBindService bindService;
        private readonly IValidator validator;

        private readonly UserManager<IdentityUser> userManager;
        public ReviewService(IRepository repository, IBindService bindService, IValidator validator, UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.bindService = bindService;
            this.userManager = userManager;
            this.validator = validator;
        }
        public async Task AddAsync(ReviewDataModel data, IdentityUser user, bool hasNulls)
        {
            var errors = this.validator.ValidateReview(data, hasNulls);
            if (errors.Any()) this.validator.ThrowErrors(errors);

            var property = this.repository.FindById<Data.Models.Property>(data.PropertyId);
            var userId = await this.userManager.GetUserIdAsync(user);

            var Review = new Data.Models.Review
            {
                PropertyId = property.Id,
                UserId = userId
            };

            this.BindReview(data, property);

            await this.repository.AddAsync<Data.Models.Review>(Review);
            await this.repository.SaveChangesAsync();
        }

        public ViewFullReviewViewModel ViewFullReview(string reviewId)
        => this.bindService.ViewFullReview(this.repository.FindPropertyByReviewId(reviewId));

        public ICollection<ViewReviewViewModel> ViewReviews()
        {
            var reviews = this.repository.GettAll<Data.Models.Review>();
            return this.bindService.BindReviews(reviews).ToList();
        }

        public async Task EditAsync(ReviewDataModel data, string reviewId, bool hasNulls)
        {
            var errors = this.validator.ValidateReview(data, hasNulls);
            if (errors.Any()) this.validator.ThrowErrors(errors);

            var property = this.repository.FindPropertyByReviewId(reviewId);

            StringBuilder pros = new StringBuilder();
            StringBuilder cons = new StringBuilder();

            foreach (var pro in data.Pros)
                pros.Append(pro + "*");

            foreach (var con in data.Cons)
                cons.Append(con + "*");

            property.Pros = pros.ToString();
            property.Cons = cons.ToString();
            property.ReviewOfProperty = data.PropertyReview;
            property.ReviewOfLandlord = data.LandlordReview;
            property.ReviewOfNeighbour = data.NeighbourReview;
            property.Rented = data.Rented;
            property.Vacated = data.Vacated;

            await this.repository.SaveChangesAsync();
        }

        public async Task Remove(string reviewId)
        {
            var review = this.repository.FindById<Data.Models.Review>(reviewId);
            var property = this.repository.FindPropertyByReviewId(reviewId);

            property.ReviewOfLandlord = null;
            property.ReviewOfNeighbour = null;
            property.ReviewOfProperty = null;
            property.Pros = null;
            property.Cons = null;
            property.Rented = null;
            property.Vacated = null;

            this.repository.Remove(review);

            await this.repository.SaveChangesAsync();
        }

        private Data.Models.Property BindReview(ReviewDataModel data, Data.Models.Property property)
        => this.bindService.BindReviewToProperty(property, data);
    }
}
