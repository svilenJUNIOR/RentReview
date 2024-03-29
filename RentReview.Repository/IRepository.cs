﻿using Microsoft.AspNetCore.Identity;
using RentReview.Data.Models;

namespace RentReviewRepository
{
    public interface IRepository
    {
        Task SaveChangesAsync();
        Task AddAsync<T>(T newItem) where T : class;
        Task AddRangeAsync<T>(List<T> items) where T : class;
        void Remove<T>(T Item) where T : class;
        string ReturnReviewId(string propertyId);
        ICollection<T> GettAll<T>() where T : class;
        Task<IdentityUser> FindUserByEmailAsync(string email);
        Task<IdentityUser> FindUserByPasswordAsync(string password);
        Task<IdentityUser> FindUserByUsernameAsync(string username);
        Task<IdentityUser> FindUserByIdAsync(string Id);
        Task<IdentityRole> FindRoleByIdAsync(string Id);
        T FindById<T>(string Id) where T : class;
        Property FindPropertyByReviewId(string ReviewId);
        Review FindReviewByPropertyId(string PropertyId);
        void Update<T>(T item) where T : class;
        ICollection<IdentityUserRole<string>> GetUserRole();
    }
}
