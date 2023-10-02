using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentReview.Data;
using RentReview.Data.Models;

namespace RentReviewRepository
{
    public class Repository : IRepository
    {
        private readonly RentDbContext context;
        private readonly UserManager<IdentityUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public Repository(RentDbContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            this.context = context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public Property FindPropertyByReviewId(string ReviewId)
        {
            var review = this.context.Reviews.Where(x => x.Id == ReviewId).FirstOrDefault();
            var property = this.context.Properties.Where(x => x.Id == review.PropertyId).FirstOrDefault();

            return property;
        }

        public Review FindReviewByPropertyId(string PropertyId)
        => this.context.Reviews.Where(x => x.PropertyId == PropertyId).FirstOrDefault();

        public async Task AddAsync<T>(T newItem) where T : class
         => await this.context.Set<T>().AddAsync(newItem);

        public T FindById<T>(string Id) where T : class
         => this.context.Find<T>(Id);

        public async Task<IdentityRole> FindRoleByIdAsync(string Id)
         => await this.roleManager.FindByIdAsync(Id);

        public async Task<IdentityUser> FindUserByEmailAsync(string email)
        => await this.userManager.FindByEmailAsync(email);

        public async Task<IdentityUser> FindUserByPasswordAsync(string password) // password is hashed
         => await this.context.Users.Where(x => x.PasswordHash == password).FirstOrDefaultAsync();

        public async Task<IdentityUser> FindUserByIdAsync(string Id)
        => await this.userManager.FindByIdAsync(Id);

        public ICollection<T> GettAll<T>() where T : class
        => this.context.Set<T>().ToList();

        public void Remove<T>(T Item) where T : class
        => this.context.Set<T>().Remove(Item);

        public async Task SaveChangesAsync()
        => await this.context.SaveChangesAsync();

        public async Task<IdentityUser> FindUserByUsernameAsync(string username)
         => await this.context.Users.Where(x => x.UserName == username).FirstOrDefaultAsync();

        public string ReturnReviewId(string propertyId)
        {
            var review = this.FindReviewByPropertyId(propertyId);

            if (review == null)
                return "null";

            return review.Id;
        }

        public void Update<T>(T item) where T : class
        => this.context.Set<T>().Update(item);

        public ICollection<IdentityUserRole<string>> GetUserRole()
        => this.context.UserRoles.ToList();
    }
}
