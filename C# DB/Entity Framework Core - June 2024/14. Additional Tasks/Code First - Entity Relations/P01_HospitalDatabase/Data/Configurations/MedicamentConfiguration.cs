using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class MedicamentConfiguration : IEntityTypeConfiguration<Medicament>
    {
        public void Configure(EntityTypeBuilder<Medicament> builder)
        {
            builder
                .Property(d => d.Name)
                .IsUnicode(true);

            builder
                .HasData(new Medicament
                {
                    MedicamentId = 1,
                    Name = "Nonsteroidal anti-inflammatory drug",
                });
        }
    }
}