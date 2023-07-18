using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;
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
        public ReviewService(IRepository repository, IBindService bindService, IValidator validator,UserManager<IdentityUser> userManager)
        {
            this.repository = repository;
            this.bindService = bindService;
            this.userManager = userManager;
            this.validator = validator;
        }
        public async Task AddAsync(AddNewReviewDataModel data, IdentityUser user)
        {
            var errors = this.validator.ValidateAddReview(data);
            if (errors.Any()) await this.validator.ThrowErrorsAsync(errors);

            var property = this.repository.FindById<Data.Models.Property>(data.PropertyId);
            var userId = await this.userManager.GetUserIdAsync(user);

            var Review = new Data.Models.Review
            {
                PropertyId = property.Id,
                UserId = userId
            };

            StringBuilder pros = new StringBuilder();
            StringBuilder cons = new StringBuilder();

            foreach (var pro in data.Pros)
                pros.Append(pro + "*");

            foreach (var con in data.Cons)
                cons.Append(con + "*");

            property.ReviewOfProperty = data.PropertyReview;
            property.ReviewOfLandlord = data.LandlordReview;
            property.ReviewOfNeighbour = data.NeighbourReview;
            property.Rented = data.Rented;
            property.Vacated = data.Vacated;
            property.Pros = pros.ToString();
            property.Cons = cons.ToString();

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

        public void Edit(AddNewReviewDataModel data, string reviewId)
        {
            var property = this.repository.FindPropertyByReviewId(reviewId);
        }
    }
}
