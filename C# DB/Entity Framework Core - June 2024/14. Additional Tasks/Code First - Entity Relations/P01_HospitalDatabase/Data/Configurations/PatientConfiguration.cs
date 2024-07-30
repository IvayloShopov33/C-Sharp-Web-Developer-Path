using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class PatientConfiguration : IEntityTypeConfiguration<Patient>
    {
        public void Configure(EntityTypeBuilder<Patient> builder)
        {
            builder
                .Property(p => p.FirstName)
            .IsUnicode(true);

            builder
                .Property(p => p.LastName)
            .IsUnicode(true);

            builder
                .Property(p => p.Address)
                .IsUnicode(true);

            builder
                .HasData(new Patient
                {
                    PatientId = 1,
                    FirstName = "Мирослав",
                    LastName = "Костакараколев",
                    Address = "София, Витошка 1",
                    Email = "miro_kosta@mail.bg",
                    HasInsurance = true,
                });
        }
    }
}