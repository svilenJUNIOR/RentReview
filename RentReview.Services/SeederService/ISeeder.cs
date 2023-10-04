namespace RentReview.Services.SeederService
{
    public interface ISeeder
    {
        Task SeedProperties();
        Task SeedReviews();
        Task SeedRoles();
        Task SeedUsers();
        Task SeedUserRole();
    }
}
