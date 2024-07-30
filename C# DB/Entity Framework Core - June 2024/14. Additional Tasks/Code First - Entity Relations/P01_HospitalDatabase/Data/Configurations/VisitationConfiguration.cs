using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using P01_HospitalDatabase.Data.Models;

namespace P01_HospitalDatabase.Data.Configurations
{
    public class VisitationConfiguration : IEntityTypeConfiguration<Visitation>
    {
        public void Configure(EntityTypeBuilder<Visitation> builder)
        {
            builder
                .Property(v => v.Comments)
                .IsUnicode(true);

            builder
                .HasData(new Visitation
                {
                    VisitationId = 1,
                    Date = DateTime.UtcNow,
                    PatientId = 1,
                    DoctorId = 1,
                    Comments = "The situation is stable, but there is room for improvement",
                });
        }
    }
}
