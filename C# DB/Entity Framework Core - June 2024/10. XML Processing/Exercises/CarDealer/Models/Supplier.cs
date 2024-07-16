using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.Models
{
    public class Supplier
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlElement("name")]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [XmlElement("isImporter")]
        public bool IsImporter { get; set; }

        [XmlIgnore]
        public ICollection<Part> Parts { get; set; } = new List<Part>();
    }
}