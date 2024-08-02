using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

using Medicines.Data.Models;
using static Medicines.Data.ModelsValidationConstraints;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType(nameof(Pharmacy))]
    public class PharmacyInputXmlModel
    {
        [XmlElement(nameof(Name))]
        [Required]
        [MinLength(PharmacyNameMinLength)]
        [MaxLength(PharmacyNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(PhoneNumber))]
        [Required]
        [RegularExpression(PharmacyPhoneNumberRegEx)]
        public string PhoneNumber { get; set; } = null!;

        [XmlAttribute("non-stop")]
        [Required]
        [RegularExpression(PharmacyIsNonStopRegEx)]
        public string IsNonStop { get; set; } = null!;

        [XmlArray(nameof(Medicines))]
        [XmlArrayItem(nameof(Medicine))]
        public MedicineInputXmlModel[] Medicines { get; set; }
    }
}