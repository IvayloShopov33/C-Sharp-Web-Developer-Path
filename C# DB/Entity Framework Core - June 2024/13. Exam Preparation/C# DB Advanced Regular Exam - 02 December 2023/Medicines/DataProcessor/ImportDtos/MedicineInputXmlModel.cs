using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Medicines.Data.Models;
using static Medicines.Data.ModelsValidationConstraints;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Medicine))]
    public class MedicineInputXmlModel
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(MedicineNameMinLength)]
        [MaxLength(MedicineNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Price))]
        [Required]
        [Range(typeof(decimal), MedicinePriceMinValue, MedicinePriceMaxValue)]
        public decimal Price { get; set; }

        [XmlAttribute("category")]
        [Required]
        public string Category { get; set; } = null!;

        [XmlElement(nameof(ProductionDate))]
        [Required]
        public string ProductionDate { get; set; } = null!;

        [XmlElement(nameof(ExpiryDate))]
        [Required]
        public string ExpiryDate { get; set; } = null!;

        [XmlElement(nameof(Producer))]
        [Required]
        [MinLength(MedicineProducerMinLength)]
        [MaxLength(MedicineProducerMaxLength)]
        public string Producer { get; set; } = null!;
    }
}