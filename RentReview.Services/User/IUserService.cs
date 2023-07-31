using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.User;
using RentReview.Models.ViewModels.Property;

namespace RentReview.Services.User
{
    public interface IUserService
    {
        Task UserRegisterAsync(RegisterUserDataModel data, bool check);
        Task UserLoginAsync(LoginUserDataModel data, bool check);
        ICollection<ViewPropertyViewModel> LoadMyData(IdentityUser user);
    }
}
