using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

using static Medicines.Data.ModelsValidationConstraints;

namespace Medicines.DataProcessor.ImportDtos
{
    public class PatientInputJsonModel
    {
        [Required]
        [MinLength(PatientFullNameMinLength)]
        [MaxLength(PatientFullNameMaxLength)]
        public string FullName { get; set; } = null!;

        [Required]
        public string AgeGroup { get; set; } = null!;

        [Required]
        public string Gender { get; set; } = null!;

        [JsonProperty(nameof(Medicines))]
        [Required]
        public int[] MedicineIds { get; set; }
    }
}