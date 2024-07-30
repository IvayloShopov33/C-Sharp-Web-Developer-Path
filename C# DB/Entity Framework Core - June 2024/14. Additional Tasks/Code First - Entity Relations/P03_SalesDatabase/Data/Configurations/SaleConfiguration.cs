using System.Globalization;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Configurations
{
    public class SaleConfiguration : IEntityTypeConfiguration<Sale>
    {
        public void Configure(EntityTypeBuilder<Sale> builder)
        {
            builder
                .HasData(new Sale
                {
                    SaleId = 1,
                    Date = DateTime.UtcNow,
                    ProductId = 3,
                    StoreId = 3,
                    CustomerId = 3,
                }, new Sale
                {
                    SaleId = 2,
                    Date = DateTime.Parse("2024-05-05", CultureInfo.InvariantCulture),
                    ProductId = 2,
                    StoreId = 2,
                    CustomerId = 2,
                }, new Sale
                {
                    SaleId = 3,
                    Date = DateTime.Parse("2023-12-12", CultureInfo.InvariantCulture),
                    ProductId = 3,
                    StoreId = 3,
                    CustomerId = 3,
                });
        }
    }
}