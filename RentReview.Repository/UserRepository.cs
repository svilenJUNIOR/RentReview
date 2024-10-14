using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentReview.Data;

namespace RentReview.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly RentDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UserRepository(RentDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public async Task<IdentityUser> FindUserByEmailAsync(string email)
       => await this.userManager.FindByEmailAsync(email);

        public async Task<IdentityUser> FindUserByPasswordAsync(string password) // password is hashed
         => await this.context.Users.Where(x => x.PasswordHash == password).FirstOrDefaultAsync();

        public async Task<IdentityUser> FindUserByIdAsync(string Id)
        => await this.userManager.FindByIdAsync(Id);

        public async Task<IdentityUser> FindUserByUsernameAsync(string username)
        => await this.context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

        public async Task<IdentityRole> FindRoleByIdAsync(string Id)
        => await this.roleManager.FindByIdAsync(Id);

        public IQueryable<IdentityUserRole<string>> GetUserRole()
        => this.context.UserRoles;
    }
}
