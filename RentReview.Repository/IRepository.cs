using Microsoft.AspNetCore.Identity;
using RentReview.Data.Models;

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

       T FindById<T>(string Id) where T : class;
        Property FindPropertyByReviewId(string ReviewId);
        Review FindReviewByPropertyId(string PropertyId);
    }
}
