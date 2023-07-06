using RentReview.Models.ViewModels;

namespace RentReview.Services
{
    public interface IBindService
    {
        ICollection<ViewPropertyViewModel> ViewProperties();
    }
}
