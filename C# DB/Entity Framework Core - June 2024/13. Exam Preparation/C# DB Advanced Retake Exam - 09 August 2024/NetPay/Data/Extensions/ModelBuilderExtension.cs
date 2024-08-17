using Microsoft.EntityFrameworkCore;

using NetPay.Data.Configurations;

namespace NetPay.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new SupplierConfiguration());
            modelBuilder.ApplyConfiguration(new ServiceConfiguration());
            modelBuilder.ApplyConfiguration(new SupplierServiceConfiguration());
        }
    }
}