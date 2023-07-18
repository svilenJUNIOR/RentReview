using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentReview.Data.Models;

namespace RentReview.Data
{
    public class RentDbContext : IdentityDbContext
    {
        public RentDbContext() { }

        public RentDbContext(DbContextOptions<RentDbContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Review> Reviews { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=; Database=RentReview; Trusted_Connection = SSPI; Encrypt = false; TrustServerCertificate = true");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
