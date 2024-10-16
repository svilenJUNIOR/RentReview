using RentReview.Models.DataModels.Property;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services
{
    public interface IApiService
    {
        Task<List<ViewPropertyViewModel>> GetAllPropertiesAsync();
        Task<List<ViewPropertyViewModel>> GetFilteredPropertiesAsync(FilterPropertyDataModel data, string action);
    }
}
