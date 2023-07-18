using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;
using RentReviewRepository;

namespace RentReview.Services.Property
{
    public class PropertyService : IPropertyService
    {
        private readonly IRepository repository;
        private readonly IValidator validator;
        private readonly IBindService bindService;

        public PropertyService(IRepository repository, IValidator validator, IBindService bindService)
        {
            this.repository = repository;
            this.validator = validator;
            this.bindService = bindService;
        }

        public async Task AddAsync(AddNewPropertyDataModel data, IdentityUser user)
        {
            var errors = this.validator.ValidateAddProperty(data);
            if (errors.Any()) await this.validator.ThrowErrorsAsync(errors);

            var prop = new Data.Models.Property
            {
                Address = data.Address,
                Url = data.Url,
                Price = data.Price,
                Picture = data.Picture,
                UserId = user.Id,
            };

            await this.repository.AddAsync<Data.Models.Property>(prop);
            await this.repository.SaveChangesAsync();
        }
        public ICollection<ViewPropertyViewModel> ViewProperties()
        {
            var properties = this.repository.GettAll<Data.Models.Property>();
          
            return bindService.BindProperties(properties).ToList();
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
