using Microsoft.EntityFrameworkCore;

using TravelAgency.Data.Configurations;

namespace TravelAgency.Data.Extensions
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GuideConfiguration());
            modelBuilder.ApplyConfiguration(new TourPackageConfiguration());
            modelBuilder.ApplyConfiguration(new TourPackageGuideConfiguration());
        }
    }
}