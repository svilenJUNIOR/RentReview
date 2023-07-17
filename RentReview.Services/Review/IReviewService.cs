using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.Review
{
    public interface IReviewService
    {
        Task Add(AddNewReviewDataModel data);
        ViewFullReviewViewModel ViewFullReview(string reviewId);
        ICollection<ViewReviewViewModel> ViewReviews();
    }
}
