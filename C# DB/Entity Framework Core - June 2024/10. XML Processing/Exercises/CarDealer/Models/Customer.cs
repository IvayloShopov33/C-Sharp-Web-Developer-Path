using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.Models
{
    public class Customer
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlElement("name")]
        [StringLength(100)]
        public string Name { get; set; } = null!;

        [XmlElement("birthDate")]
        public DateTime BirthDate { get; set; }

        [XmlElement("isYoungDriver")]
        public bool IsYoungDriver { get; set; }

        [XmlIgnore]
        public ICollection<Sale> Sales { get; set; } = new List<Sale>(); 
    }
}