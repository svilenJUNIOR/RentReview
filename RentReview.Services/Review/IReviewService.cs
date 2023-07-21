using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.Review
{
    public interface IReviewService
    {
        Task AddAsync(AddNewReviewDataModel data, IdentityUser user, bool check);
        ViewFullReviewViewModel ViewFullReview(string reviewId);
        ICollection<ViewReviewViewModel> ViewReviews();
        Task EditAsync(AddNewReviewDataModel data, string reviewId, bool check);
        Task Remove(string reviewId);
    }
}
