using RentReview.Models.DataModels;
using RentReviewRepository;
using RentReview.Common;

namespace RentReview.Services
{
    public class Validator
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

        //public IEnumerable<Exception> ValidateUserRegister(RegisterUserFormModel model, ModelStateDictionary modelState)
        //{
        //    var nullErrors = this.AgainstNull(model.Username, model.Password, model.Email, model.ConfirmPassword);
        //    if (nullErrors.Count() > 0) return nullErrors;

        //    var errors = new List<Exception>();
        //    var users = sqlRepository.GettAll<IdentityUser>();

        //    if (users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.ExistingEmail));
        //    if (users.Any(x => x.UserName == model.Username)) errors.Add(new ArgumentException(Messages.ExistingUsername));
        //    if (!model.Email.EndsWith("@email.com")) errors.Add(new ArgumentException(string.Format(Messages.WrongEmailFormat, Values.EndOfAnEmail)));
        //    if (model.Username.Length < Values.MinUsernameLength && model.Username.Length > Values.MaxUsernameLength)
        //        errors.Add(new ArgumentException(string.Format(Messages.WrongUsernameFormat, Values.MinUsernameLength, Values.MaxUsernameLength)));

        //    var modelStateErrors = this.CheckModelState(modelState);

        //    if (modelStateErrors.Count() > 0) errors.AddRange(modelStateErrors);

        //    return this.ThrowErrors(errors);
        //}
        //public IEnumerable<Exception> ValidateUserLogin(LoginUserFormModel model)
        //{
        //    var nullErrors = this.AgainstNull(model.Password, model.Email);
        //    if (nullErrors.Count() > 0) return nullErrors;

        //    var errors = new List<Exception>();
        //    var users = sqlRepository.GettAll<IdentityUser>();

        //    if (!users.Any(x => x.Email == model.Email)) errors.Add(new ArgumentException(Messages.UnExistingEmail));
        //    if (!users.Any(x => x.PasswordHash == hasher.Hash(model.Password))) errors.Add(new ArgumentException(Messages.UnExistingPassword));

        //    return this.ThrowErrors(errors);
        //}

        public bool HasNulls(params string[] args)
        {
            bool check = false;

            foreach (var arg in args)
                if (string.IsNullOrEmpty(arg) || string.IsNullOrWhiteSpace(arg))
                    check = true;

            return check;
        }
    }
}
