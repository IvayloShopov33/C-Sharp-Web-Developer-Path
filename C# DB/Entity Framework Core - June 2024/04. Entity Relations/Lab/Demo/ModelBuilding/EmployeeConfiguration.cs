using Demo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Demo.ModelBuilding
{
    public class EmployeeConfiguration
        : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> modelBuilder)
        {
            modelBuilder
                .ToTable("Employees", "company");

            modelBuilder
                .HasKey(e => new { e.Id, e.Egn });

            modelBuilder
                .Property(e => e.StartWorkDate)
                .HasColumnName("StartedOn");

            modelBuilder
                .Property(e => e.Salary)
                .HasPrecision(10, 2);

            modelBuilder
                .Ignore(e => e.FullName);

            modelBuilder
                .HasOne(e => e.Department)
                .WithMany(d => d.Employees)
                .HasForeignKey(e => e.DepartmentId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .HasOne(e => e.Manager)
                .WithMany(e => e.Managees)
                .HasForeignKey(e => new { e.ManagerId, e.Egn })
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}