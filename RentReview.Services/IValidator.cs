using RentReview.Models.DataModels;

namespace RentReview.Services
{
    public interface IValidator
    {
        ICollection<Exception> ValidateAddProperty(AddNewPropertyDataModel data);
        ICollection<Exception> ValidateAddReview(AddNewReviewDataModel data);
        Task<IEnumerable<Exception>> ValidateUserRegisterAsync(RegisterUserDataModel data);
        Task<IEnumerable<Exception>> ValidateUserLoginAsync(LoginUserDataModel data);
        bool HasNulls(params string[] args);
        Task<IEnumerable<Exception>> ThrowErrorsAsync(IEnumerable<Exception> errors);
    }
}
