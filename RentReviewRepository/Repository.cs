using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using RentReview.Data;

namespace RentReviewRepository
{
    public class Repository : IRepository
    {
        private readonly RentDbContext context;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<IdentityUser> userManager;

        public Repository(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, RentDbContext context)
        {
            this.roleManager = roleManager;
            this.context = context;
            this.userManager = userManager;
        }

        public async Task AddAsync<T>(T newItem) where T : class
         => await this.context.Set<T>().AddAsync(newItem);

        public async Task FindById<T>(string Id) where T : class
         => await this.context.FindAsync<T>(Id);

        public async Task<IdentityRole> FindRoleById(string Id)
         => await this.roleManager.FindByIdAsync(Id);

        public async Task<IdentityUser> FindUserByEmail(string email)
         => await this.userManager.FindByEmailAsync(email);

        public async Task<IdentityUser> FindUserById(string Id)
        => await this.userManager.FindByIdAsync(Id);

        public ICollection<T> GettAll<T>() where T : class
        => this.context.Set<T>().ToList();

        public void Remove<T>(T Item) where T : class
        => this.context.Set<T>().Remove(Item);

        public async Task SaveChangesAsync()
        => await this.context.SaveChangesAsync();
    }
}
