using RentReview.Models.DataModels;

namespace RentReview.Services.User
{
    public interface IUserService
    {
        Task UserRegister(RegisterUserDataModel data);
        Task UserLogin(LoginUserDataModel data);
    }
}
