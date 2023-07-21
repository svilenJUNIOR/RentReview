using Microsoft.AspNetCore.Identity;
using RentReview.Data;
using RentReview.Models.DataModels;
using RentReviewRepository;

namespace RentReview.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IRepository repository;
        public AdminService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager, IRepository repository)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
            this.repository = repository;
        }

        public async Task DeleteUser(string Id)
        {
            var user = await this.userManager.FindByIdAsync(Id);
            await this.userManager.DeleteAsync(user);
        }
        public async Task PromoteUser(string Id)
        {
            var user = await this.userManager.FindByIdAsync(Id);
            await this.userManager.AddToRoleAsync(user, "admin");
        }
        public ICollection<ViewUsersDataModel> GetAllUsers(bool isAdmin)
        {
            var users = this.userManager.Users.Select(u => new ViewUsersDataModel
            {
                Id = u.Id,
                Name = u.UserName,
                IsAdmin = isAdmin
            });

            return users.ToList();
        }
    }
}
