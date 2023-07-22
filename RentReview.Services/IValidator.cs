using RentReview.Models.DataModels;

namespace RentReview.Services
{
    public interface IValidator
    {
        ICollection<Exception> ValidateProperty(PropertyDataModel data, bool isValid);
        ICollection<Exception> ValidateAddReview(AddNewReviewDataModel data, bool hasNulls);
        Task<IEnumerable<Exception>> ValidateUserRegisterAsync(RegisterUserDataModel data, bool isValid);
        Task<IEnumerable<Exception>> ValidateUserLoginAsync(LoginUserDataModel data, bool isValid);
        IEnumerable<Exception> ThrowErrors(IEnumerable<Exception> errors);
    }
}
