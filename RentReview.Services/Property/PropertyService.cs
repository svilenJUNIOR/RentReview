using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;
using RentReviewRepository;
using System.Collections.Generic;
using System.Text;

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

            char.ToUpper(data.City[0]);
            char.ToUpper(data.Country[0]);

            var prop = new Data.Models.Property
            {
                City = data.City,
                Country = data.Country,
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

        public ICollection<ViewPropertyViewModel> ViewProperties(List<Data.Models.Property> properties)
        => bindService.BindProperties(properties).ToList();

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

            property.City = data.City;
            property.Country = data.Country;
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

        public List<Data.Models.Property> FilterProperties(FilterPropertyDataModel data)
        {
            var properties = this.repository.GettAll<Data.Models.Property>().ToList();

            if (data.MinPrice > 0 || data.MaxPrice > 0)
                properties = this.FilterByPrice(properties, data);

            StringBuilder stringBuilder = new StringBuilder();

            for (int i = 0; i < data.Extras.Count(); i++)
                stringBuilder.Append(data.Extras[i] + "*");

            if (data.Extras.Count() > 0)
                properties = properties.Where(x => x.Pros == stringBuilder.ToString()).ToList();

            if (data.OnlyWithReview == "on")
                properties = properties.Where(x => x.ReviewOfLandlord != null && x.ReviewOfNeighbour != null && x.ReviewOfProperty != null).ToList();

            return properties.ToList();
        }

        private List<Data.Models.Property> FilterByPrice(List<Data.Models.Property> properties, FilterPropertyDataModel data)
        {
            if (data.MaxPrice > 0)
                properties = properties.Where(x => x.Price <= data.MaxPrice).ToList();

            else if (data.MinPrice < 0)
                properties = properties.Where(x => x.Price <= data.MinPrice).ToList();

            return properties.ToList();
        }
    }
}
