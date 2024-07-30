using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class PatientMedicamentConfiguration : IEntityTypeConfiguration<PatientMedicament>
    {
        public void Configure(EntityTypeBuilder<PatientMedicament> builder)
        {
            builder
                .HasKey(pm => new { pm.PatientId, pm.MedicamentId });

            builder
                .HasData(new PatientMedicament
                {
                    PatientId = 1,
                    MedicamentId = 1,
                });
        }
    }
}