using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Medicines.DataProcessor.ImportDtos
{
    public class PatientInputJsonModel
    {
        [JsonProperty("FullName")]
        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        public string FullName { get; set; }

        [JsonProperty("AgeGroup")]
        [Required]
        [Range(0, 2)]
        public int AgeGroup { get; set; }

        [JsonProperty("Gender")]
        [Required]
        [Range(0, 1)]
        public int Gender { get; set; }

        [JsonProperty("Medicines")]
        [Required]
        public virtual int[] Medicines { get; set; }
    }
}