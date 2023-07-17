using RentReview.Models.ViewModels;

namespace RentReview.Services
{
    public interface IBindService
    {
        ICollection<ViewPropertyViewModel> BindProperties(ICollection<Data.Models.Property> properties);
        ICollection<ViewReviewViewModel> ViewReviews();
        ViewFullReviewViewModel ViewFullReview(Data.Models.Property property);
    }
}
