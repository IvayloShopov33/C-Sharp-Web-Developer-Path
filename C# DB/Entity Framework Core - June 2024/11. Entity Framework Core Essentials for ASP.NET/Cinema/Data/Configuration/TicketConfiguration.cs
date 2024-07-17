using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class TicketConfiguration : IEntityTypeConfiguration<Ticket>
    {
        public void Configure(EntityTypeBuilder<Ticket> builder)
        {
            builder
                .HasData(new Ticket
                {
                    Id = 1,
                    CustomerId = 3,
                    BasePrice = 20,
                    SeatId = 5,
                    ScheduleId = 2,
                    TariffId = 3,
                }, new Ticket
                {
                    Id = 2,
                    CustomerId = 1,
                    BasePrice = 16,
                    SeatId = 3,
                    ScheduleId = 1,
                    TariffId = 2,
                }, new Ticket
                {
                    Id = 3,
                    CustomerId = 1,
                    BasePrice = 30,
                    SeatId = 4,
                    ScheduleId = 2,
                    TariffId = 1,
                });

            builder
                .HasOne(t => t.Seat)
                .WithMany(s => s.Tickets)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(t => t.Tariff)
                .WithMany(t => t.Tickets)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}