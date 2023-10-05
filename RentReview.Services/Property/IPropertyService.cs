using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services.Property
{
    public interface IPropertyService
    {
        Task AddAsync(AddNewPropertyDataModel model, IdentityUser user, bool check);
        ICollection<ViewPropertyViewModel> ViewProperties();
        ViewPropertyViewModel ViewPropertyForEdit(string Id);
        Task Edit(EditPropertyDataModel data, bool check);
        Task Remove(string Id);
        void ChangeStatus();
        ICollection<ViewPropertyViewModel> FilterProperties(FilterPropertyDataModel data);
    }
}
