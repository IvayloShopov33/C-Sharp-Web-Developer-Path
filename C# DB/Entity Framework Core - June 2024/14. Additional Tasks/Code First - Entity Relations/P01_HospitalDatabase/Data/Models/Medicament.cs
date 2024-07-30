using System.ComponentModel.DataAnnotations;

using static P01_HospitalDatabase.Data.ModelsValidationConstraints;

namespace P01_HospitalDatabase.Data.Models
{
    public class Medicament
    {
        [Key]
        public int MedicamentId { get; set; }

        [Required]
        [MaxLength(MedicamentNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<PatientMedicament> Prescriptions { get; set; } = new HashSet<PatientMedicament>();
    }
}