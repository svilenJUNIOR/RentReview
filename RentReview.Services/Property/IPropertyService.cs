using RentReview.Models.DataModels;

namespace RentReview.Services.Property
{
    public interface IPropertyService
    {
        Task AddAsync(AddNewPropertyDataModel model);
        void Edit();
        void Remove();
        void ChangeStatus();
    }
}
