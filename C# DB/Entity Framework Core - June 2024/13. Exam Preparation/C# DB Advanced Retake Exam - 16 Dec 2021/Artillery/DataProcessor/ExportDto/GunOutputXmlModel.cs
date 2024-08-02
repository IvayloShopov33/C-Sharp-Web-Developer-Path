using System.Xml.Serialization;

using Artillery.Data.Models;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType(nameof(Gun))]
    public class GunOutputXmlModel
    {
        [XmlAttribute(nameof(Manufacturer))]
        public string Manufacturer { get; set; } = null!;

        [XmlAttribute(nameof(GunType))]
        public string GunType { get; set; } = null!;

        [XmlAttribute(nameof(GunWeight))]
        public string GunWeight { get; set; } = null!;

        [XmlAttribute(nameof(BarrelLength))]
        public string BarrelLength { get; set; } = null!;

        [XmlAttribute(nameof(Range))]
        public string Range { get; set; } = null!;

        [XmlArray(nameof(Countries))]
        [XmlArrayItem(nameof(Country))]
        public CountryOutputXmlModel[] Countries { get; set; }
    }
}