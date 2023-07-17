using RentReview.Models.DataModels;

namespace RentReview.Services
{
    public interface IValidator
    {
        ICollection<Exception> ValidateAddProperty(AddNewPropertyDataModel data);
        ICollection<Exception> ValidateAddReview(AddNewReviewDataModel data);
        Task<IEnumerable<Exception>> ValidateUserRegister(RegisterUserDataModel data);
        bool HasNulls(params string[] args);
        Task<IEnumerable<Exception>> ThrowErrors(IEnumerable<Exception> errors);
    }
}
