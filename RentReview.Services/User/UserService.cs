﻿using Microsoft.AspNetCore.Identity;
using RentReview.Models.DataModels.User;
using RentReview.Models.ViewModels.Property;
using RentReview.Repository.Contracts;

namespace RentReview.Services.User
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        private readonly IHasher hasher;
        private readonly IValidator validator;
        private readonly SignInManager<IdentityUser> signInManager;
        private readonly UserManager<IdentityUser> userManager;
        private readonly IBindService bindService;
        private readonly IUserRepository userRepository;
        public UserService(IRepository repository, IHasher hasher, IValidator validator, SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IBindService bindService, IUserRepository userRepository)
        {
            this.repository = repository;
            this.hasher = hasher;
            this.validator = validator;
            this.signInManager = signInManager;
            this.userManager = userManager;
            this.bindService = bindService;
            this.userRepository = userRepository;
        }

        public async Task UserRegisterAsync(RegisterUserDataModel data, bool check)
        {
            var errors = await this.validator.ValidateUserRegisterAsync(data, check);
            if (errors.Any()) this.validator.ThrowErrors(errors);

            var hashedPassword = this.hasher.Hash(data.Password);

            var user = new IdentityUser
            {
                Email = data.Email,
                UserName = data.Username,
                PasswordHash = hashedPassword,
                NormalizedEmail = data.Email.ToUpper(),
                NormalizedUserName = data.Username.ToUpper()
            };

            await this.userManager.CreateAsync(user);
            await this.userManager.AddToRoleAsync(user, "user");
            await this.repository.SaveChangesAsync();
        }
        public async Task UserLoginAsync(LoginUserDataModel data, bool check)
        {
            var errors = await this.validator.ValidateUserLoginAsync(data, check);
            if (errors.Any()) this.validator.ThrowErrors(errors);

            var user = await this.userRepository.FindUserByEmailAsync(data.Email);
            await this.signInManager.SignInAsync(user, true);
        }
        public ICollection<ViewPropertyViewModel> LoadMyData(IdentityUser user)
        {
            var myProperties = this.repository.GettAll<Data.Models.Property>().Where
                (x => x.UserId == user.Id).ToList();

            var bindedProperties = this.bindService.BindProperties(myProperties);

            return bindedProperties;
        }
    }
}
