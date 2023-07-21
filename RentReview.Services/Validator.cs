using RentReview.Models.DataModels;
using RentReviewRepository;
using RentReview.Common;

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

        public ICollection<Exception> ValidateAddProperty(AddNewPropertyDataModel data)
        {
            var errors = new List<Exception>();
            bool hasNulls = this.HasNulls(data.Url, data.Address, data.Price.ToString(), data.Picture);

            if (hasNulls)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            if (data.Address.Length < 10) errors.Add(new Exception(Messages.AddressTooShort));
            if (data.Price < 0) errors.Add(new Exception(Messages.PriceBelowZero));

            return errors;
        }
        public ICollection<Exception> ValidateAddReview(AddNewReviewDataModel data, bool isValid)
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
        public async Task<IEnumerable<Exception>> ValidateUserRegisterAsync(RegisterUserDataModel data)
        {
            var errors = new List<Exception>();
            bool hasNulls = this.HasNulls(data.Email, data.Username, data.Password);

            if (hasNulls)
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
        public async Task<IEnumerable<Exception>> ValidateUserLoginAsync(LoginUserDataModel data)
        {
            var errors = new List<Exception>();
            bool hasNulls = this.HasNulls(data.Email, data.Password);

            if (hasNulls)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            var hashedPassword = this.hasher.Hash(data.Password);

            if (await this.repository.FindUserByEmailAsync(data.Email) == null) errors.Add(new Exception(Messages.UnExistingEmail));
            if (await this.repository.FindUserByPasswordAsync(hashedPassword) == null) errors.Add(new Exception(Messages.UnExistingPassword));
            
            return errors;
        }
        public bool HasNulls(params string[] args)
        {
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            return check;
        }
        public async Task<IEnumerable<Exception>> ThrowErrorsAsync(IEnumerable<Exception> errors)
        {
            if (errors.Count() == 0) return new List<Exception>();
            throw new AggregateException(errors);
        }
    }
}
