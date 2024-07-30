using Microsoft.EntityFrameworkCore;

using P03_SalesDatabase.Data.Configurations;

namespace P03_SalesDatabase.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new StoreConfiguration());
            modelBuilder.ApplyConfiguration(new SaleConfiguration());
        }
    }
}