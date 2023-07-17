using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.Property
{
    public interface IPropertyService
    {
        Task AddAsync(AddNewPropertyDataModel model);
        ICollection<ViewPropertyViewModel> ViewProperties();
        void Edit();
        void Remove();
        void ChangeStatus();
    }
}
