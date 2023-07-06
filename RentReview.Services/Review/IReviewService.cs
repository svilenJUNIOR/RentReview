using RentReview.Models.DataModels;

namespace RentReview.Services.Review
{
    public interface IReviewService
    {
        Task Add(AddNewReviewDataModel data);
    }
}
