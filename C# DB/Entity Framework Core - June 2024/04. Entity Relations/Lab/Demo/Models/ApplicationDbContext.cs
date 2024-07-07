using Demo.ModelBuilding;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        public ApplicationDbContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Department> Departments { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<Club> Clubs { get; set; }

        public DbSet<EmployeeInClub> EmployeesInClubs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=EfCoreDemo;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Department>()
                .ToTable("Departments", "company");

            modelBuilder.ApplyConfiguration(new EmployeeConfiguration());

            modelBuilder
                .Entity<EmployeeInClub>()
                .HasKey(ec => new { ec.EmployeeId, ec.ClubId });

            base.OnModelCreating(modelBuilder);
        }
    }
}