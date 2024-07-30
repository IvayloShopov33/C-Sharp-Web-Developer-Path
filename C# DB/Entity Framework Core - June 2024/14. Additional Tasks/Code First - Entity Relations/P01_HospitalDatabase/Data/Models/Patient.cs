using System.ComponentModel.DataAnnotations;

using static P01_HospitalDatabase.Data.ModelsValidationConstraints;

namespace P01_HospitalDatabase.Data.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [Required]
        [MaxLength(PatientFirstNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(PatientLastNameMaxLength)]
        public string LastName { get; set; } = null!;

        [Required]
        [MaxLength(PatientAddressMaxLength)]
        public string Address { get; set; } = null!;

        [Required]
        [MaxLength(PatientEmailMaxLength)]
        public string Email { get; set; } = null!;

        [Required]
        public bool HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; } = new HashSet<Visitation>();

        public virtual ICollection<Diagnose> Diagnoses { get; set; } = new HashSet<Diagnose>();

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}