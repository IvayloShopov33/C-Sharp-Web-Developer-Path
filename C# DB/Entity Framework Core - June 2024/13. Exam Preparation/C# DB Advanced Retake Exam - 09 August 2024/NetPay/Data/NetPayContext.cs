using Microsoft.EntityFrameworkCore;

using NetPay.Data.Extensions;
using NetPay.Data.Models;

namespace NetPay.Data
{
    public class NetPayContext : DbContext
    {
        public NetPayContext()
        {
            
        }

        public NetPayContext(DbContextOptions options)
            : base(options)
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Household> Households { get; set; } = null!;

        public DbSet<Expense> Expenses { get; set; } = null!;

        public DbSet<Service> Services { get; set; } = null!;

        public DbSet<Supplier> Suppliers { get; set; } = null!;

        public DbSet<SupplierService> SuppliersServices { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SupplierService>()
                .HasKey(ss => new { ss.SupplierId, ss.ServiceId });

            modelBuilder.Seed();
        }
    }
}