using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
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

        public async Task AddAsync(AddNewPropertyDataModel data, IdentityUser user, bool check)
        {
            var errors = this.validator.ValidateProperty(data, check);
            if (errors.Any()) this.validator.ThrowErrors(errors);

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
        public ViewPropertyViewModel ViewPropertyForEdit(string Id)
        {
            var property = this.repository.FindById<Data.Models.Property>(Id);
            var temp = this.bindService.BindProperties(new List<Data.Models.Property> { property });

            var bindedProperty = temp.FirstOrDefault();

            return bindedProperty;
        }
        public async Task Edit(EditPropertyDataModel data, bool check)
        {
            var errors = this.validator.ValidateProperty(data, check);
            if (errors.Any()) this.validator.ThrowErrors(errors);

            var property = this.repository.FindById<Data.Models.Property>(data.Id);

            property.Address = data.Address;
            property.Price = data.Price;
            property.Picture = data.PictureUrl;

            await this.repository.SaveChangesAsync();
        }
        public async Task Remove(string Id)
        {
            var property = this.repository.FindById<Data.Models.Property>(Id);
            var review = this.repository.FindReviewByPropertyId(property.Id);

            this.repository.Remove<Data.Models.Property>(property);

            if (review != null)
                this.repository.Remove<Data.Models.Review>(review);

            await this.repository.SaveChangesAsync();
        }

        // when the time comes
        public void ChangeStatus()
        {
            throw new NotImplementedException();
        }

        public ICollection<ViewPropertyViewModel> FilterProperties(FilterPropertyDataModel data)
        {
            throw new NotImplementedException();
        }
    }
}
