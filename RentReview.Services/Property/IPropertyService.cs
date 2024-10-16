using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services.Property
{
    public interface IPropertyService
    {
        Task AddAsync(AddNewPropertyDataModel model, string userId, bool check);
        ICollection<ViewPropertyViewModel> ViewProperties();
        ICollection<ViewPropertyViewModel> ViewProperties(List<Data.Models.Property> properties);
        ViewPropertyViewModel ViewPropertyForEdit(string Id);
        Task Edit(EditPropertyDataModel data, bool check);
        Task Remove(string Id);
        void ChangeStatus();
        List<Data.Models.Property> FilterProperties(FilterPropertyDataModel data);
    }
}
