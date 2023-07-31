using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.Review;
using RentReview.Models.ViewModels.Review;

namespace RentReview.Services.Review
{
    public interface IReviewService
    {
        Task AddAsync(ReviewDataModel data, IdentityUser user, bool check);
        ViewFullReviewViewModel ViewFullReview(string reviewId);
        ICollection<ViewReviewViewModel> ViewReviews();
        Task EditAsync(ReviewDataModel data, string reviewId, bool check);
        Task Remove(string reviewId);
    }
}
