using Microsoft.EntityFrameworkCore;

using CarShop.Data.Models;

namespace CarShop.Data
{
    public class CarShopDbContext : DbContext
    {
        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Car> Cars { get; set; } = null!;

        public DbSet<Issue> Issues { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=CarShop;TrustServerCertificate=true;");
            }
        }
    }
}