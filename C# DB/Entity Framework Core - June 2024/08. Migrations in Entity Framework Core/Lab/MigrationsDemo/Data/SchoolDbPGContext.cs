using Microsoft.EntityFrameworkCore;
using MigrationsDemo.Data.Models;

namespace MigrationsDemo.Data
{
    public class SchoolDbPGContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=SchoolDb;User Id=postgres;Password=postgres")
                    .UseSnakeCaseNamingConvention();
        }
    }
}