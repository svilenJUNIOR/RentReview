using RentReviewRepository;
using RentReview.Common;
using RentReview.Models.DataModels.User;
using RentReview.Models.DataModels.Property;
using RentReview.Models.DataModels.Review;

namespace RentReview.Services
{
    public class Validator : IValidator
    {
        private IRepository repository;
        private IHasher hasher;

        public Validator(IRepository repository, IHasher hasher)
        {
            this.repository = repository;
            this.hasher = hasher;
        }

        public ICollection<Exception> ValidateProperty(PropertyDataModel data, bool isValid)
        {
            var errors = new List<Exception>();

            if (!isValid)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            if (data.City.Length < 3) errors.Add(new Exception(Messages.CityTooShort));
            if (data.Country.Length < 3) errors.Add(new Exception(Messages.CountryTooShort));
            if (data.Price < 0) errors.Add(new Exception(Messages.PriceBelowZero));

            return errors;
        
        }
        public ICollection<Exception> ValidateReview(ReviewDataModel data, bool isValid)
        {
            var errors = new List<Exception>();

            if (!isValid)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            if (DateTime.Parse(data.Vacated) < DateTime.Parse(data.Rented)) errors.Add(new Exception(Messages.VacatedBeforeRented));
            if (data.Cons.Count() <= 0) errors.Add(new Exception(Messages.EmptyCons));
            if (data.Pros.Count() <= 0) errors.Add(new Exception(Messages.EmptyPros));
            if (data.LandlordReview.Length < 10) errors.Add(new Exception(Messages.EmptyLandlordReview));
            if (data.NeighbourReview.Length < 10) errors.Add(new Exception(Messages.EmptyNeighbourReview));
            if (data.PropertyReview.Length < 10) errors.Add(new Exception(Messages.EmptyPropertyReview));

            return errors;
        }
        public async Task<IEnumerable<Exception>> ValidateUserRegisterAsync(RegisterUserDataModel data, bool isValid)
        {
            var errors = new List<Exception>();
                
            if (!isValid)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            if (!data.Email.EndsWith("@email.com")) errors.Add(new Exception(Messages.WrongEmailFormat));
            if (await repository.FindUserByEmailAsync(data.Email) != null) errors.Add(new Exception(Messages.EmailExists));
            if (data.Password.Length < 8) errors.Add(new Exception(Messages.ShortPassword));
            if (!data.Password.Any(char.IsUpper) || !data.Password.Any(char.IsDigit)) errors.Add(new Exception(Messages.WeakPassword));
            if (await repository.FindUserByUsernameAsync(data.Username) != null) errors.Add(new Exception(Messages.UsernameExists));
            if (data.Username.Length < 6) errors.Add(new Exception(Messages.UsernameTooShort));
            if (!data.Username.All(char.IsLetter)) errors.Add(new Exception(Messages.WrongUsernameFormat));
            return errors;
        }
        public async Task<IEnumerable<Exception>> ValidateUserLoginAsync(LoginUserDataModel data, bool isValid)
        {
            var errors = new List<Exception>();

            if (!isValid)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            var hashedPassword = this.hasher.Hash(data.Password);

            if (await this.repository.FindUserByEmailAsync(data.Email) == null) errors.Add(new Exception(Messages.UnExistingEmail));
            if (await this.repository.FindUserByPasswordAsync(hashedPassword) == null) errors.Add(new Exception(Messages.UnExistingPassword));
            
            return errors;
        }
        public  IEnumerable<Exception> ThrowErrors(IEnumerable<Exception> errors)
        {
            if (errors.Count() == 0) return new List<Exception>();
            throw new AggregateException(errors);
        }
    }
}
