using System.ComponentModel.DataAnnotations;

using static P01_HospitalDatabase.Data.ModelsValidationConstraints;

namespace P01_HospitalDatabase.Data.Models
{
    public class Doctor
    {
        [Key]
        public int DoctorId { get; set; }

        [Required]
        [MaxLength(DoctorNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DoctorSpecialtyMaxLength)]
        public string Specialty { get; set; } = null!;

        public virtual ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();
    }
}