using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class TariffConfiguration : IEntityTypeConfiguration<Tariff>
    {
        public void Configure(EntityTypeBuilder<Tariff> builder)
        {
            builder
                .HasData(new Tariff
                {
                    Id = 1,
                    Name = "Adult",
                    DiscountFactor = 1,
                }, new Tariff
                {
                    Id = 2,
                    Name = "Student",
                    DiscountFactor = 0.8m,
                }, new Tariff
                {
                    Id = 3,
                    Name = "Senior",
                    DiscountFactor = 0.7m
                });
        }
    }
}