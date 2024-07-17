using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CinemaApp.Data.Configuration
{
    public class HallConfiguration : IEntityTypeConfiguration<Hall>
    {
        public void Configure(EntityTypeBuilder<Hall> builder)
        {
            builder
                .HasData(new Hall
                {
                    Id = 1,
                    Name = "IMAX Hall 1",
                    CinemaId = 4,
                }, new Hall
                {
                    Id = 2,
                    Name = "VIP Hall",
                    CinemaId = 3
                }, new Hall
                {
                    Id = 3,
                    Name = "3D Hall",
                    CinemaId = 2,
                }, new Hall
                {
                    Id = 4,
                    Name = "2D Hall",
                    CinemaId = 1,
                }, new Hall
                {
                    Id = 5,
                    Name = "3D Ultra VIP IMAX",
                    CinemaId = 3,
                });
        }
    }
}