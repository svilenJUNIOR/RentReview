using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services
{
    public interface IApiService
    {
        Task<List<ViewPropertyViewModel>> GetAllPropertiesAsync();
        Task<List<ViewPropertyViewModel>> GetFilteredPropertiesAsync(FilterPropertyDataModel data, string action);
        Task<bool> AddProperty(AddNewPropertyDataModel data, string userId,string action);
        Task<ViewPropertyViewModel> EditProperty(string action);
        Task<bool> DeleteProperty(string action);
    }
}
