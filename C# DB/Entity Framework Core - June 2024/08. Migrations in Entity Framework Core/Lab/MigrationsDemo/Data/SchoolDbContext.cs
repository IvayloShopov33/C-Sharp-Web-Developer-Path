using Microsoft.EntityFrameworkCore;
using MigrationsDemo.Data.Models;

namespace MigrationsDemo.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SchoolDb;Trusted_Connection=True;");
        }
    }
}