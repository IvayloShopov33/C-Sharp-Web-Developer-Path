using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder
                .Property(p => p.Name)
                .IsUnicode(true);

            builder
                .HasData(new Product
                {
                    ProductId = 1,
                    Name = "Gloves",
                    Quantity = 6,
                    Price = 18,
                }, new Product
                {
                    ProductId = 2,
                    Name = "Hat",
                    Quantity = 1,
                    Price = 8,
                }, new Product
                {
                    ProductId = 3,
                    Name = "Socks",
                    Quantity = 2,
                    Price = 5,
                });
        }
    }
}