using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RentReview.Data.Models;

namespace RentReview.Data
{
    internal class DbContext : IdentityDbContext
    {
        public DbContext() { }

        public DbContext(DbContextOptions<DbContext> options) : base(options) { }

        public DbSet<Property> Properties { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                optionsBuilder.UseSqlServer("Server=;Integrated Security=true;Database=RentReview");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Review>()
           .HasKey(x => new { x.PropertyId, x.TenantId });
        }
    }
}
