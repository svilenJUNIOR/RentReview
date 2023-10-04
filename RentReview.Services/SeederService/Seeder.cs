using Microsoft.AspNetCore.Identity;
using Newtonsoft.Json;
using RentReview.Common;
using RentReviewRepository;

namespace RentReview.Services.SeederService
{
    public class Seeder : ISeeder
    {
        private readonly IRepository repository;
        public Seeder(IRepository repository)
         => this.repository = repository;

        public async Task SeedProperties()
        => await this.FileSeed<Data.Models.Property>(SeedFilesPaths.Properties);

        public async Task SeedReviews()
        => await this.FileSeed<Data.Models.Review>(SeedFilesPaths.Reviews);

        public async Task SeedRoles()
        => await this.FileSeed<IdentityRole>(SeedFilesPaths.Roles);

        public async Task SeedUserRole()
        => await this.FileSeed<IdentityUserRole<string>>(SeedFilesPaths.UserRoles);

        public async Task SeedUsers()
        => await this.FileSeed<IdentityUser>(SeedFilesPaths.Users);

        private async Task FileSeed<T>(string path) where T : class
        {
            var jsonString = File.ReadAllText(path);
            var toAdd = JsonConvert.DeserializeObject<List<T>>(jsonString);
            await repository.AddRangeAsync(toAdd);
            await repository.SaveChangesAsync();
        }
    }
}
