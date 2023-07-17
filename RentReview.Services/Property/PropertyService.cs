using RentReview.Models.DataModels;
using RentReviewRepository;

namespace RentReview.Services.Property
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository repository;
        private readonly IValidator validator;

        public PropertyService(IRepository repository, IValidator validator)
        {
            this.repository = repository;
            this.validator = validator;
        }

        public async Task AddAsync(AddNewPropertyDataModel data)
        {
            var errors = this.validator.ValidateAddProperty(data);
            if (errors.Any()) await this.validator.ThrowErrorsAsync(errors);

            var prop = new Data.Models.Property
            {
                Address = data.Address,
                Url = data.Url,
                Price = data.Price,
                Picture = data.Picture
            };

            await this.repository.AddAsync<Data.Models.Property>(prop);
            await this.repository.SaveChangesAsync();
        }

        public string ReturnReviewId(string propertyId)
        {
            var review = this.repository.FindReviewByPropertyId(propertyId);

            if (review == null)
                return "null";

            return review.Id;
        }

        public void Edit()
        {
            throw new NotImplementedException();
        }

        public void Remove()
        {
            throw new NotImplementedException();
        }

        // when the time comes
        public void ChangeStatus()
        {
            throw new NotImplementedException();
        }
    }
}
