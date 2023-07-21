using RentReview.Models.DataModels;

namespace RentReview.Services
{
    public interface IValidator
    {
        ICollection<Exception> ValidateAddProperty(AddNewPropertyDataModel data, bool isValid);
        ICollection<Exception> ValidateEditProperty(EditPropertyDataModel data, bool isValid);
        ICollection<Exception> ValidateAddReview(AddNewReviewDataModel data, bool hasNulls);
        Task<IEnumerable<Exception>> ValidateUserRegisterAsync(RegisterUserDataModel data, bool isValid);
        Task<IEnumerable<Exception>> ValidateUserLoginAsync(LoginUserDataModel data, bool isValid);
        IEnumerable<Exception> ThrowErrors(IEnumerable<Exception> errors);
    }
}
