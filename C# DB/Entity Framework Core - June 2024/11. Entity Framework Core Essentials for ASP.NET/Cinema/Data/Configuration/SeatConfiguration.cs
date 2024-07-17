using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class SeatConfiguration : IEntityTypeConfiguration<Seat>
    {
        public void Configure(EntityTypeBuilder<Seat> builder)
        {
            builder
                .HasData(new Seat
                {
                    Id = 1,
                    HallId = 2,
                    Row = 13,
                    Number = 1,
                }, new Seat
                {
                    Id = 2,
                    HallId = 3,
                    Row = 14,
                    Number = 2,
                }, new Seat
                {
                    Id = 3,
                    HallId = 1,
                    Row = 2,
                    Number = 39,
                }, new Seat
                {
                    Id = 4,
                    HallId = 2,
                    Row = 5,
                    Number = 33,
                }, new Seat
                {
                    Id = 5,
                    HallId = 3,
                    Row = 6,
                    Number = 18,
                });
        }
    }
}