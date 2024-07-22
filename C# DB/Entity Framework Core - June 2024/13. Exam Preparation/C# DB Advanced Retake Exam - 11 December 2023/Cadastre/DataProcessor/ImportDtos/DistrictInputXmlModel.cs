using Cadastre.Data.Enumerations;
using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Cadastre.DataProcessor.ImportDtos
{
    [XmlType("District")]
    public class DistrictInputXmlModel
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; }

        [XmlElement("PostalCode")]
        [Required]
        [RegularExpression(@"^[A-Z]{2}-\d{5}$")]
        public string PostalCode { get; set; }

        [XmlAttribute("Region")]
        [Required]
        [EnumDataType(typeof(Region))]
        public string Region { get; set; }

        [XmlArray("Properties")]
        [XmlArrayItem("Property")]
        public virtual PropertyInputXmlModel[] Properties { get; set; }
    }
}