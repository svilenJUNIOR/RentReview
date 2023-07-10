using RentReview.Models.ViewModels;
using RentReviewRepository;

namespace RentReview.Services
{
    public class BindService : IBindService
    {
        private readonly IRepository repository;
        public BindService(IRepository repository) { this.repository = repository; }
        public ICollection<ViewPropertyViewModel> ViewProperties()
        {
            var properties = this.repository.GettAll<Data.Models.Property>();

            var bindedProperties = properties.Select(x => new ViewPropertyViewModel
            {
                Address = x.Address,
                Id = x.Id,
                Picture = x.Picture,
                Price = x.Price,
                Url = x.Url,
            });

            return bindedProperties.ToList();
        }

        public ICollection<ViewReviewViewModel> ViewReviews()
        {
            var reviews = this.repository.GettAll<Data.Models.Review>();

            var bindedReviews = reviews.Select(x => new ViewReviewViewModel
            {
                Address = this.repository.GettAll<Data.Models.Property>().Where(c => c.Id == x.PropertyId).FirstOrDefault().Address,
                PictureUrl = this.repository.GettAll<Data.Models.Property>().Where(c => c.Id == x.PropertyId).FirstOrDefault().Picture,
                PropertyReview = this.repository.GettAll<Data.Models.Property>().Where(c => c.Id == x.PropertyId).FirstOrDefault().ReviewOfProperty,
                PropertyId = this.repository.GettAll<Data.Models.Property>().Where(c => c.Id == x.PropertyId).FirstOrDefault().Id,
                ReviewId = x.Id
            });

            return bindedReviews.ToList();
        }

        public ViewFullReviewViewModel ViewFullReview(Data.Models.Property property)
        {
            var review = new ViewFullReviewViewModel
            {
                Address = property.Address,
                Picture = property.Picture,
                Price = property.Price,
                Rented = property.Rented,
                Vacated = property.Vacated,
                ReviewOfLandlord = property.ReviewOfLandlord,
                ReviewOfNeighbour = property.ReviewOfNeighbour,
                ReviewOfProperty = property.ReviewOfProperty,
                Url = property.Url,
                Cons = property.Cons.Split("/").ToList(),
                Pros = property.Pros.Split("/").ToList(),
            };

            return review;
        }
    }
}
