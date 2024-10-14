using Microsoft.AspNetCore.Identity;
using RentReview.Data.Models;

namespace RentReview.Repository
{
    public interface IRepository
    {
        Task SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> items) where T : class;
        void Remove<T>(T Item) where T : class;
        string ReturnReviewId(string propertyId);
        IQueryable<T> GettAll<T>() where T : class;
       
        T FindById<T>(string Id) where T : class;
        Property FindPropertyByReviewId(string ReviewId);
        Review FindReviewByPropertyId(string PropertyId);
        void Update<T>(T item) where T : class;
    }
}
