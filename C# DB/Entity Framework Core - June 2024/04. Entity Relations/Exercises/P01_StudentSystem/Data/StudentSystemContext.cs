using Microsoft.EntityFrameworkCore;
using P01_StudentSystem.Data.Models;

namespace P01_StudentSystem.Data
{
    public class StudentSystemContext : DbContext
    {
        public StudentSystemContext()
        {

        }

        public StudentSystemContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Resource> Resources { get; set; }

        public DbSet<Homework> Homeworks { get; set; }

        public DbSet<StudentCourse> StudentsCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=StudentSystem;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Student>()
                .Property(s => s.Name)
                .IsUnicode(true);

            modelBuilder
                .Entity<Student>()
                .Property(s => s.PhoneNumber)
                .IsRequired(false)
                .HasMaxLength(10)
                .HasColumnType("char(10)");

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Name)
                .IsUnicode(true);

            modelBuilder
                .Entity<Course>()
                .Property(c => c.Description)
                .IsRequired(false)
                .IsUnicode(true);

            modelBuilder
                .Entity<Resource>()
                .Property(r => r.Name)
                .IsUnicode(true);

            modelBuilder
                .Entity<StudentCourse>()
                .HasKey(sc => new { sc.StudentId, sc.CourseId });

            base.OnModelCreating(modelBuilder);
        }
    }
}