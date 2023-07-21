using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.User
{
    public interface IUserService
    {
        Task UserRegisterAsync(RegisterUserDataModel data, bool check);
        Task UserLoginAsync(LoginUserDataModel data, bool check);
        ICollection<ViewPropertyViewModel> LoadMyData(IdentityUser user);
    }
}
