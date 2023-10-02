using RentReview.Models.DataModels.Review;
using RentReview.Models.ViewModels.Property;
using RentReview.Models.ViewModels.Review;

namespace RentReview.Services
{
    public interface IBindService
    {
        ICollection<ViewPropertyViewModel> BindProperties(ICollection<Data.Models.Property> properties);
        ICollection<ViewReviewViewModel> BindReviews(ICollection<Data.Models.Review> reviews);
        ViewFullReviewViewModel ViewFullReview(Data.Models.Property property);
        Data.Models.Property BindReviewToProperty(Data.Models.Property property, ReviewDataModel data);
    }
}
