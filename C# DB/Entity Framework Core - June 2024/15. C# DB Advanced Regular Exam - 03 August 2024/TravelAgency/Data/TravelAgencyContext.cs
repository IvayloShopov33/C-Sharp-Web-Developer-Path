using Microsoft.EntityFrameworkCore;

using TravelAgency.Data.Extensions;
using TravelAgency.Data.Models;

namespace TravelAgency.Data
{
    public class TravelAgencyContext : DbContext
    {
        public TravelAgencyContext()
        {

        }

        public TravelAgencyContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Booking> Bookings { get; set; } = null!;

        public DbSet<Guide> Guides { get; set; } = null!;

        public DbSet<TourPackage> TourPackages { get; set; } = null!;

        public DbSet<TourPackageGuide> TourPackagesGuides { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseLazyLoadingProxies()
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TourPackageGuide>()
                .HasKey(tpg => new { tpg.TourPackageId, tpg.GuideId });

            modelBuilder.Seed();
        }
    }
}