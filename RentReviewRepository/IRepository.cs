using Microsoft.AspNet.Identity.EntityFramework;

namespace RentReviewRepository
{
    public interface IRepository
    {
        Task SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task RemoveAsync<T>(T Item) where T : class;

        ICollection<T> GettAll<T>() where T : class;

        IdentityUser FindUserByEmail(string email);
        IdentityUser FindUserById(string Id);
        IdentityRole FindRoleById(string Id);

        T FindById<T>(string Id) where T : class;
    }
}
