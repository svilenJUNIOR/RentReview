using Microsoft.AspNet.Identity.EntityFramework;

namespace RentReviewRepository
{
    public interface IRepository
    {
        Task SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        void Remove<T>(T Item) where T : class;

        ICollection<T> GettAll<T>() where T : class;

        Task<IdentityUser> FindUserByEmail(string email);
        Task<IdentityUser> FindUserById(string Id);
        Task<IdentityRole> FindRoleById(string Id);

        Task<T> FindByIdAsync<T>(string Id) where T : class;
    }
}
