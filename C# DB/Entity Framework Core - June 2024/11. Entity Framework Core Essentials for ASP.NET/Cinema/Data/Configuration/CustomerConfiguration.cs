using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CinemaApp.Data.Configuration
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .HasData(new Customer
                {
                    Id = 1,
                    FirstName = "Spas",
                    LastName = "Nedelev",
                    Username = "GoalscorerBG",
                }, new Customer
                {
                    Id = 2,
                    FirstName = "Ivo",
                    LastName = "Ivanov",
                    Username = "ii123",
                }, new Customer
                {
                    Id = 3,
                    FirstName = "Petar",
                    LastName = "Petrov",
                    Username = "pepe",
                }, new Customer
                {
                    Id = 4,
                    FirstName = "Ivan",
                    LastName = "Ivov",
                    Username = "viviandi",
                });

            builder
                .HasIndex(c => c.Username)
                .IsUnique();
        }
    }
}