using RentReview.Models.DataModels;

namespace RentReview.Services.User
{
    public interface IUserService
    {
        Task UserRegisterAsync(RegisterUserDataModel data);
        Task UserLoginAsync(LoginUserDataModel data);
    }
}
