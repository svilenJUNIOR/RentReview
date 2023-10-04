using Newtonsoft.Json;
using RentReviewRepository;

namespace RentReview.Services.SeederService
{
    public class Seeder : ISeeder
    {
        private readonly IRepository repository;
        public Seeder(IRepository repository)
         => this.repository = repository;

        public async Task SeedProperties()
        {
            var jsonString = File.ReadAllText(SeedFilesPaths.Profiles);

            var toAdd = JsonConvert.DeserializeObject<List<Profile>>(jsonString);

            await repository.AddRangeAsync(toAdd);
        }

        public async Task SeedReviews()
        {
            throw new NotImplementedException();
        }

        public async Task SeedRoles()
        {
            throw new NotImplementedException();
        }

        public async Task SeedUserRole()
        {
            throw new NotImplementedException();
        }

        public async Task SeedUsers()
        {
            throw new NotImplementedException();
        }
    }
}
