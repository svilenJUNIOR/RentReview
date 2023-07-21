using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.Property
{
    public interface IPropertyService
    {
        Task AddAsync(AddNewPropertyDataModel model, IdentityUser user, bool check);
        ICollection<ViewPropertyViewModel> ViewProperties();
        ViewPropertyViewModel ViewPropertyForEdit(string Id);
        void Edit(EditPropertyDataModel data, bool check);
        Task Remove(string Id);
        void ChangeStatus();
    }
}
