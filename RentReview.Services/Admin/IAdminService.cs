namespace RentReview.Services.Admin
{
    public interface IAdminService
    {
        Task DeleteUser(string Id);
        Task PromoteUser(string Id);
    }
}
