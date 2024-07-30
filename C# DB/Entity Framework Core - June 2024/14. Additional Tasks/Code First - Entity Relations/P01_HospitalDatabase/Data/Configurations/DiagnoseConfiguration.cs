using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class DiagnoseConfiguration : IEntityTypeConfiguration<Diagnose>
    {
        public void Configure(EntityTypeBuilder<Diagnose> builder)
        {
            builder
                .Property(d => d.Name)
            .IsUnicode(true);

            builder
                .Property(d => d.Comments)
                .IsUnicode(true);

            builder
                .HasData(new Diagnose
                {
                    DiagnoseId = 1,
                    Name = "Arthritis",
                    PatientId = 1,
                    Comments = "Arthritis is inflammation of muscles and joints.",
                });
        }
    }
}