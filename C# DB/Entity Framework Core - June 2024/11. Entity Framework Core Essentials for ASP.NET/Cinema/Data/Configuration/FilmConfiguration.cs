using CinemaApp.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CinemaApp.Data.Configuration
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder
                .HasData(new Film
                {
                    Id = 1,
                    Name = "Titanic",
                }, new Film
                {
                    Id = 2,
                    Name = "Gladiator",
                }, new Film
                {
                    Id = 3,
                    Name = "Nowhere",
                }, new Film
                {
                    Id = 4,
                    Name = "Pearl Harbor",
                }, new Film
                {
                    Id = 5,
                    Name = "Snatch",
                });
        }
    }
}