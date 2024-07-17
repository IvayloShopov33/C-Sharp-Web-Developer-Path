using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder
                .HasData(new Schedule
                {
                    Id = 1,
                    FilmId = 5,
                    HallId = 4,
                    Start = new DateTime(2024, 07, 17, 20, 00, 00),
                    Duration = TimeSpan.FromMinutes(120),

                }, new Schedule
                {
                    Id = 2,
                    FilmId = 4,
                    HallId = 5,
                    Start = new DateTime(2024, 08, 01, 19, 30, 00),
                    Duration = TimeSpan.FromMinutes(150),
                }, new Schedule
                {
                    Id = 3,
                    FilmId = 3,
                    HallId = 1,
                    Start = new DateTime(2024, 08, 08, 19, 00, 00),
                    Duration = TimeSpan.FromMinutes(100),
                });
        }
    }
}