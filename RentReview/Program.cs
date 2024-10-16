using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using RentReview.Data;
using RentReview.Repository;
using RentReview.Repository.Contracts;
using RentReview.Services;
using RentReview.Services.Admin;
using RentReview.Services.Property;
using RentReview.Services.Review;
using RentReview.Services.SeederService;
using RentReview.Services.User;

namespace RentReview
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddDefaultIdentity<IdentityUser>
                (options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<RentDbContext>();

            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            builder.Services.AddDbContext<RentDbContext>(options =>
                options.UseSqlServer(connectionString));

            builder.Services.AddControllersWithViews().AddMvcOptions(options => {});

            builder.Services.AddScoped<IPropertyService, PropertyService>();
            builder.Services.AddScoped<IApiService, ApiService>();
            builder.Services.AddScoped<IRepository, RentReview.Repository.Repository>();
            builder.Services.AddScoped<IBindService, BindService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();
            builder.Services.AddScoped<IHasher, Hasher>();
            builder.Services.AddScoped<IValidator, Validator>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<IAdminService, AdminService>();
            builder.Services.AddScoped<ISeeder, Seeder>();
            builder.Services.AddScoped<IUserRepository, UserRepository>();

            builder.Services.AddHttpClient();

            builder.Services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.HttpOnly = true;

                options.LoginPath = "/User/Login";
                options.AccessDeniedPath = "/User/Login";
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "Area",
                pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}