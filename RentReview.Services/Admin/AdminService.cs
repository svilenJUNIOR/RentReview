using Microsoft.AspNetCore.Identity;

namespace RentReview.Services.Admin
{
    public class AdminService : IAdminService
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;
        public AdminService(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.userManager = userManager;
            this.roleManager = roleManager;
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
    }
}
