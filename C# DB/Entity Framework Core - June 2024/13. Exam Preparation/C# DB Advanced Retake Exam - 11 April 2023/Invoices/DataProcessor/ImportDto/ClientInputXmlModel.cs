using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace Invoices.DataProcessor.ImportDto
{
    [XmlType("Client")]
    public class ClientInputXmlModel
    {
        [Required]
        [MinLength(10)]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MinLength(10)]
        [MaxLength(15)]
        public string NumberVat { get; set; }

        [XmlArray("Addresses")]
        [XmlArrayItem("Address")]
        [Required]
        public AddressInputXmlModel[] Addresses { get; set; }
    }
}