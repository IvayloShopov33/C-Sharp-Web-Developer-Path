using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data.Configurations
{
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder
                .Property(p => p.Name)
                .IsUnicode(true);

            builder
                .HasData(new Store
                {
                    StoreId = 1,
                    Name = "Nike",
                }, new Store
                {
                    StoreId = 2,
                    Name = "Adidas",
                }, new Store
                {
                    StoreId = 3,
                    Name = "Puma",
                });
        }
    }
}