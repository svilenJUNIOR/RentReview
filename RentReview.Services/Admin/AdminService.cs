using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.User;

namespace RentReview.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> userManager;

        public AdminService(UserManager<IdentityUser> userManager)
        => this.userManager = userManager;

        public async Task DeleteUser(string Id)
        {
            var user = await this.userManager.FindByIdAsync(Id);
            await this.userManager.DeleteAsync(user);
        }
        public async Task PromoteUser(string Id)
        {
            var user = await this.userManager.FindByIdAsync(Id);
            await this.userManager.AddToRoleAsync(user, "admin");

            if (await this.userManager.IsInRoleAsync(user, "user"))
                await this.userManager.RemoveFromRoleAsync(user, "user");
        }
        public async Task DemoteUser(string Id)
        {
            var user = await this.userManager.FindByIdAsync(Id);
            await this.userManager.RemoveFromRoleAsync(user, "admin");
            await this.userManager.AddToRoleAsync(user, "user");
        }
        public async Task<ICollection<ViewUsersDataModel>> GetAllUsers()
        {
            var users = new List<ViewUsersDataModel>();
            var temp = this.userManager.Users.ToList();

            foreach (var tempUser in temp)
            {
                var user = new ViewUsersDataModel
                {
                    Id = tempUser.Id,
                    Name = tempUser.UserName,
                    IsAdmin = await this.userManager.IsInRoleAsync(tempUser, "admin")
                };

                users.Add(user);
            }

            return users.ToList();
        }
    }
}
