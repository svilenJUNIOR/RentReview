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

        public void UserRegister(RegisterUserDataModel data)
        {
            this.validator.ValidateUserRegister(data);
            var hashedPassword = this.hasher.Hash(data.Password);

            this.repository.
        }

        public void UserLogin(RegisterUserDataModel data)
        {
            throw new NotImplementedException();
        }
    }
}
