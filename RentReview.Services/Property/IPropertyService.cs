﻿using RentReview.Models.DataModels;

namespace RentReview.Services.Property
{
    public interface IPropertyService
    {
        Task AddAsync(ViewPropertyDataModel model);
        string ReturnReviewId(string propertyId);
        void Edit();
        void Remove();
        void ChangeStatus();
    }
}
