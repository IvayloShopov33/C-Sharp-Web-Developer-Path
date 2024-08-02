using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Artillery.Data.Models;
using static Artillery.Data.ModelsValidationConstraints;

namespace Artillery.DataProcessor.ImportDto
{
    [XmlType(nameof(Country))]
    public class CountryInputXmlModel
    {
        [XmlElement(nameof(CountryName))]
        [Required]
        [MinLength(CountryNameMinLength)]
        [MaxLength(CountryNameMaxLength)]
        public string CountryName { get; set; } = null!;

        [XmlElement(nameof(ArmySize))]
        [Required]
        [Range(CountryArmySizeMinValue, CountryArmySizeMaxValue)]
        public int ArmySize { get; set; }
    }
}