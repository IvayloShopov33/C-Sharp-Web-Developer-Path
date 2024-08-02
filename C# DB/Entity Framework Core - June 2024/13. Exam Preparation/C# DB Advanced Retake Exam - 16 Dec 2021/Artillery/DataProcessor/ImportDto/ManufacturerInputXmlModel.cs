using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Artillery.Data.Models;
using static Artillery.Data.ModelsValidationConstraints;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType(nameof(Manufacturer))]
    public class ManufacturerInputXmlModel
    {
        [XmlElement(nameof(ManufacturerName))]
        [Required]
        [MinLength(ManufacturerNameMinLength)]
        [MaxLength(ManufacturerNameMaxLength)]
        public string ManufacturerName { get; set; } = null!;

        [XmlElement(nameof(Founded))]
        [Required]
        [MinLength(ManufacturerFoundedMinLength)]
        [MaxLength(ManufacturerFoundedMaxLength)]
        public string Founded { get; set; } = null!;
    }
}