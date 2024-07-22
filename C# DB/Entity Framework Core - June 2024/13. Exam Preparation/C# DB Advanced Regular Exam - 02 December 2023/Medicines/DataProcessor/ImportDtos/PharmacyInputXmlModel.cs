using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Medicines.DataProcessor.ImportDtos
{
    [XmlType("Pharmacy")]
    public class PharmacyInputXmlModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }

        [XmlElement("PhoneNumber")]
        [Required]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$")]
        public string PhoneNumber { get; set; }

        [Required]
        [XmlAttribute("non-stop")]
        [RegularExpression("^(true|false)$")]
        public string IsNonStop { get; set; }

        [XmlArray("Medicines")]
        [XmlArrayItem("Medicine")]
        public virtual MedicineInputXmlModel[] Medicines { get; set; }
    }
}