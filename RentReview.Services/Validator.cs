﻿using RentReview.Models.DataModels;
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
        public ICollection<Exception> ValidateAddReview(AddNewReviewDataModel data)
        {
            var errors = new List<Exception>();
            bool hasNulls = this.HasNulls(data.Cons.ToString(), data.Rented.ToString(), data.Vacated.ToString(), data.LandlordReview, data.PropertyReview, data.NeighbourReview, data.Pros.ToString());

            if (hasNulls)
            {
                errors.Add(new Exception(Messages.EmptyFields));
                return errors;
            }

            if (data.Vacated < data.Rented) errors.Add(new Exception(Messages.VacatedBeforeRented));
            if (data.Cons.Count() <= 0) errors.Add(new Exception(Messages.EmptyCons));
            if (data.Pros.Count() <= 0) errors.Add(new Exception(Messages.EmptyPros));
            if (data.LandlordReview.Length < 10) errors.Add(new Exception(Messages.EmptyLandlordReview));
            if (data.NeighbourReview.Length < 10) errors.Add(new Exception(Messages.EmptyNeighbourReview));
            if (data.PropertyReview.Length < 10) errors.Add(new Exception(Messages.EmptyPropertyReview));

            return errors;
        }
        public async Task<IEnumerable<Exception>> ValidateUserRegister(RegisterUserDataModel data)
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