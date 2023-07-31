using RentReview.Models.DataModels.Property;
using RentReview.Models.DataModels.Review;
using RentReview.Models.DataModels.User;

namespace RentReview.Services
{
    public interface IValidator
    {
        ICollection<Exception> ValidateProperty(PropertyDataModel data, bool isValid);
        ICollection<Exception> ValidateReview(ReviewDataModel data, bool hasNulls);
        Task<IEnumerable<Exception>> ValidateUserRegisterAsync(RegisterUserDataModel data, bool isValid);
        Task<IEnumerable<Exception>> ValidateUserLoginAsync(LoginUserDataModel data, bool isValid);
        IEnumerable<Exception> ThrowErrors(IEnumerable<Exception> errors);
    }
}
