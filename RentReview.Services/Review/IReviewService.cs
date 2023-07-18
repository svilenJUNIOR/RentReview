using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.Review
{
    public interface IReviewService
    {
        Task AddAsync(AddNewReviewDataModel data, IdentityUser user);
        ViewFullReviewViewModel ViewFullReview(string reviewId);
        ICollection<ViewReviewViewModel> ViewReviews();
        void Edit(AddNewReviewDataModel data, string reviewId);
    }
}
