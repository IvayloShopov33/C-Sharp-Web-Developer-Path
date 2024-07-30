using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder
                .Property(d => d.Name)
                .IsUnicode(true);

            builder
                .Property(d => d.Specialty)
                .IsUnicode(true);

            builder
                .HasData(new Doctor
                {
                    DoctorId = 1,
                    Name = "Ivan Spasov",
                    Specialty = "Rheumatologist"
                });
        }
    }
}