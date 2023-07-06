using RentReview.Models.DataModels;
using RentReviewRepository;

namespace RentReview.Services.Property
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository repository;
        public PropertyService(IRepository repository) { this.repository = repository; }
        public async Task AddAsync(ViewPropertyDataModel model)
        {
            var prop = new Data.Models.Property 
            { 
                Address = model.Address, 
                Url= model.Url,
                Price= model.Price,
                Picture = model.Picture
            };

            await this.repository.AddAsync<Data.Models.Property>(prop);
            await this.repository.SaveChangesAsync();
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
