using RentReview.Models.DataModels.Review;
using RentReview.Models.ViewModels.Property;
using RentReview.Models.ViewModels.Review;
using RentReviewRepository;
using System.Text;

namespace RentReview.Services
{
    public class BindService : IBindService
    {
        private readonly IRepository repository;
        public BindService(IRepository repository)
         => this.repository = repository;

        public ICollection<ViewPropertyViewModel> BindProperties(ICollection<Data.Models.Property> properties)
        {
            var bindedProperties = properties.Select(x => new ViewPropertyViewModel
            {
                City = x.City,
                Country = x.Country,
                Id = x.Id,
                Picture = x.Picture,
                Price = x.Price,
                Url = x.Url,
                HasReview = this.repository.GettAll<Data.Models.Review>().Any(c => c.PropertyId == x.Id),
                ReviewId = this.repository.ReturnReviewId(x.Id),
                Cities = this.FillCities().ToHashSet(),
                Countries = this.FillCountries().ToHashSet(),
            });

            return bindedProperties.ToList();
        }
        public ICollection<ViewReviewViewModel> BindReviews(ICollection<Data.Models.Review> reviews)
        {
            var bindedReviews = reviews.Select(x => new ViewReviewViewModel
            {
                Address = this.repository.GettAll<Data.Models.Property>().Where(c => c.Id == x.PropertyId).FirstOrDefault().Country + " - " + this.repository.GettAll<Data.Models.Property>().Where(c => c.Id == x.PropertyId).FirstOrDefault().City,
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
                City = property.City,
                Country = property.Country,
                Picture = property.Picture,
                Price = property.Price,
                Rented = property.Rented,
                Vacated = property.Vacated,
                ReviewOfLandlord = property.ReviewOfLandlord,
                ReviewOfNeighbour = property.ReviewOfNeighbour,
                ReviewOfProperty = property.ReviewOfProperty,
                Url = property.Url,
                Cons = property.Cons.Split("*").ToList(),
                Pros = property.Pros.Split("*").ToList(),
            };

            return review;
        }
        public Data.Models.Property BindReviewToProperty(Data.Models.Property property, ReviewDataModel data)
        {
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

            return property;
        }

        public ICollection<string> FillCities()
        {
            var cities = new List<string>();

            foreach (var property in this.Properties())
                cities.Add(property.City);

            return cities.ToList();
        }

        public ICollection<string> FillCountries()
        {
            var cities = new List<string>();

            foreach (var property in this.Properties())
                cities.Add(property.Country);

            return cities.ToList();
        }

        private List<Data.Models.Property> Properties()
         => this.repository.GettAll<Data.Models.Property>().ToList();
    }
}
