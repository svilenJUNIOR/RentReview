using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReview.Models.ViewModels;

namespace RentReview.Services.User
{
    public interface IUserService
    {
        Task UserRegisterAsync(RegisterUserDataModel data);
        Task UserLoginAsync(LoginUserDataModel data);
        ICollection<ViewPropertyViewModel> LoadMyData(IdentityUser user);
    }
}
