using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Artillery.Data.Models;
using static Artillery.Data.ModelsValidationConstraints;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType(nameof(Shell))]
    public class ShellInputXmlModel
    {
        [XmlElement(nameof(ShellWeight))]
        [Required]
        [Range(ShellWeightMinValue, ShellWeightMaxValue)]
        public double ShellWeight { get; set; }

        [XmlElement(nameof(Caliber))]
        [Required]
        [MinLength(ShellCaliberMinLength)]
        [MaxLength(ShellCaliberMaxLength)]
        public string Caliber { get; set; } = null!;
    }
}