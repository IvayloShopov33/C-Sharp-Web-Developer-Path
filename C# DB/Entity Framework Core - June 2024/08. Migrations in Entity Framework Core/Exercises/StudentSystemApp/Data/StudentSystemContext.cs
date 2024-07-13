using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using StudentSystemApp.Data.Models;

namespace StudentSystemApp.Data;

public partial class StudentSystemContext : DbContext
{
    public StudentSystemContext()
    {
    }

    public StudentSystemContext(DbContextOptions<StudentSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Homework> Homeworks { get; set; }

    public virtual DbSet<Resource> Resources { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=StudentSystem;Integrated Security=true;TrustServerCertificate=true;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.PhoneNumber).IsFixedLength();

            entity.HasMany(d => d.Courses).WithMany(p => p.Students)
                .UsingEntity<Dictionary<string, object>>(
                    "StudentCourse",
                    r => r.HasOne<Course>().WithMany().HasForeignKey("CourseId"),
                    l => l.HasOne<Student>().WithMany().HasForeignKey("StudentId"),
                    j =>
                    {
                        j.HasKey("StudentId", "CourseId");
                        j.ToTable("StudentCourse");
                        j.HasIndex(new[] { "CourseId" }, "IX_StudentCourse_CourseId");
                    });
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
