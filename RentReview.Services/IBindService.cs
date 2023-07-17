using RentReview.Models.ViewModels;

namespace RentReview.Services
{
    public interface IBindService
    {
        ICollection<ViewPropertyViewModel> BindProperties(ICollection<Data.Models.Property> properties);
        ICollection<ViewReviewViewModel> BindReviews(ICollection<Data.Models.Review> reviews);
        ViewFullReviewViewModel ViewFullReview(Data.Models.Property property);
    }
}
