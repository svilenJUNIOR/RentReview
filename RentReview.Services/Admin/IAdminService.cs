﻿using RentReview.Models.DataModels.User;

namespace RentReview.Services.Admin
{
    public interface IAdminService
    {
        Task DeleteUser(string Id);
        Task PromoteUser(string Id);
        Task DemoteUser(string Id);
        Task<ICollection<ViewUsersDataModel>> GetAllUsers();
    }
}
