using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels;
using RentReviewRepository;

namespace RentReview.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IHasher hasher;
        private readonly IValidator validator;

        public UserService(IRepository repository, IHasher hasher, IValidator validator)
        {
            this.repository = repository;
            this.hasher = hasher;
            this.validator = validator;
        }

        public async Task UserRegister(RegisterUserDataModel data)
        {
            var hashedPassword = this.hasher.Hash(data.Password);

            var user = new IdentityUser
            {
                Email = data.Email,
                UserName = data.Username,
                PasswordHash = hashedPassword
            };

            await this.repository.AddAsync<IdentityUser>(user);
        }

        public async Task UserLogin(LoginUserDataModel data)
        {
            throw new NotImplementedException();
        }
    }
}
