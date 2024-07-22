using Cadastre.Data.Enumerations;
using Cadastre.Data.Models;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace Cadastre.DataProcessor.ImportDtos
{
    [JsonObject(nameof(Citizen))]
    public class CitizenInputJsonModel
    {
        [JsonProperty(nameof(FirstName))]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [JsonProperty(nameof(LastName))]
        [Required]
        [MinLength(2)]
        [MaxLength(30)]
        public string LastName { get; set; }

        [JsonProperty(nameof(BirthDate))]
        [Required]
        public string BirthDate { get; set; }

        [JsonProperty(nameof(MaritalStatus))]
        [Required]
        [RegularExpression("^Unmarried|Married|Divorced|Widowed$")]
        [EnumDataType(typeof(MaritalStatus))]
        public string MaritalStatus { get; set; }

        [JsonProperty(nameof(Properties))]
        [Required]
        public int[] Properties { get; set; }
    }
}