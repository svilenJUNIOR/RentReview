using RentReview.Models.ViewModels.Property;

namespace RentReview.Services
{
    public interface IApiService
    {
        Task<List<ViewPropertyViewModel>> GetAllPropertiesAsync(string action);
    }
}
