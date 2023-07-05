using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentReview.Data;

namespace RentReviewRepository
{
    public class Repository : IRepository
    {
        private readonly RentDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;

        public Repository(RoleManager<IdentityRole> roleManager, RentDbContext context)
        {
            this.roleManager = roleManager;
            this.context = context;
        }

        public async Task AddAsync<T>(T newItem) where T : class
         => await this.context.Set<T>().AddAsync(newItem);

        public async Task FindById<T>(string Id) where T : class
         => await this.context.FindAsync<T>(Id);

        public async Task<IdentityRole> FindRoleById(string Id)
         => await this.roleManager.FindByIdAsync(Id);

        public IdentityUser FindUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IdentityUser FindUserById(string Id)
        {
            throw new NotImplementedException();
        }

        public ICollection<T> GettAll<T>() where T : class
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync<T>(T Item) where T : class
        {
            throw new NotImplementedException();
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
