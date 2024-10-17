using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using RentReview.Data;
using RentReview.Repository.Contracts;
using RentReview.Repository;
using RentReview.Services.Admin;
using RentReview.Services;
using RentReview.Services.Property;
using RentReview.Services.Review;
using RentReview.Services.SeederService;
using RentReview.Services.User;
using Microsoft.AspNetCore.Identity;

namespace RentReview.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<RentDbContext>(options => options.UseSqlServer(connectionString));

            // Add Identity services
            builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<RentDbContext>()
                .AddDefaultTokenProviders();


            // Add services to the container.
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IRepository, RentReview.Repository.Repository>();
            builder.Services.AddScoped<IBindService, BindService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IHasher, Hasher>();
            builder.Services.AddScoped<IValidator, Validator>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddControllers(options =>
            {
                // Configure options to allow nulls (if needed)
                options.SuppressImplicitRequiredAttributeForNonNullableReferenceTypes = true;
            });
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
