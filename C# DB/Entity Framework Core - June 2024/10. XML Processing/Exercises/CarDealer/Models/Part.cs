using System.ComponentModel.DataAnnotations;
using System.Xml.Serialization;

namespace CarDealer.Models
{
    public class Part
    {
        [XmlIgnore]
        public int Id { get; set; }

        [XmlElement("name")]
        [StringLength(60)]
        public string Name { get; set; } = null!;

        [XmlElement("price")]
        public decimal Price { get; set; }

        [XmlElement("quantity")]
        public int Quantity { get; set; }

        [XmlElement("supplierId")]
        public int SupplierId { get; set; }

        [XmlIgnore]
        public Supplier Supplier { get; set; } = null!;

        [XmlIgnore]
        public ICollection<PartCar> PartsCars { get; set; } = new List<PartCar>();
    }
}