using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class CinemaConfiguration : IEntityTypeConfiguration<Cinema>
    {
        public void Configure(EntityTypeBuilder<Cinema> builder)
        {
            builder
                .HasData(new Cinema
                {
                    Id = 2,
                    Name = "Arena Mladost",
                    Address = "Sofia, Mladost 4",
                }, new Cinema
                {
                    Id = 3,
                    Name = "Kino Iskra",
                    Address = "Veliko Tarnovo, Bulgaria boulevard",
                }, new Cinema
                {
                    Id = 4,
                    Name = "Cinema City",
                    Address = "Mall of Sofia"
                });
        }
    }
}