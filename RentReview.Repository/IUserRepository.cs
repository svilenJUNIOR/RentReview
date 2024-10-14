using Microsoft.AspNetCore.Identity;

namespace RentReview.Repository
{
    public interface IUserRepository
    {
        Task<IdentityUser> FindUserByEmailAsync(string email);
        Task<IdentityUser> FindUserByPasswordAsync(string password);
        Task<IdentityUser> FindUserByUsernameAsync(string username);
        Task<IdentityUser> FindUserByIdAsync(string Id);
        IQueryable<IdentityUserRole<string>> GetUserRole();
        Task<IdentityRole> FindRoleByIdAsync(string Id);

    }
}
