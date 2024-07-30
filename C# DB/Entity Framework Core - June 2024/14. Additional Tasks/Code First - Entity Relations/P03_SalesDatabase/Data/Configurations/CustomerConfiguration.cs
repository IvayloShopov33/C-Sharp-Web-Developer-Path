using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Configurations
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder
                .Property(p => p.Name)
                .IsUnicode(true);

            builder
                .HasData(new Customer
                {
                    CustomerId = 1,
                    Name = "Ivo Ivanov",
                    Email = "ivaka@gmail.com",
                    CreditCardNumber = "00000",
                }, new Customer
                {
                    CustomerId = 2,
                    Name = "Spas Nedelev",
                    Email = "spasSpanak@abv.bg",
                    CreditCardNumber = "1234",
                }, new Customer
                {
                    CustomerId = 3,
                    Name = "Maria Marinova",
                    Email = "mariika@yahoo.com",
                    CreditCardNumber = "3333",
                });
        }
    }
}