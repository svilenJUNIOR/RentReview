using RentReview.Models.DataModels;

namespace RentReview.Services.User
{
    public interface IUserService
    {
        void UserRegister(RegisterUserDataModel data);
        void UserLogin(RegisterUserDataModel data);
    }
}
