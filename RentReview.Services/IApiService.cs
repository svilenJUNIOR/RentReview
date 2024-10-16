using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services
{
    public interface IApiService
    {
        Task<List<ViewPropertyViewModel>> GetAllPropertiesAsync();
        Task<List<ViewPropertyViewModel>> GetFilteredPropertiesAsync(FilterPropertyDataModel data, string action);
        Task<bool> Add(AddNewPropertyDataModel data, string userId,string action);
        Task<ViewPropertyViewModel> Edit(string action);
        Task<bool> Delete(string action);
    }
}
