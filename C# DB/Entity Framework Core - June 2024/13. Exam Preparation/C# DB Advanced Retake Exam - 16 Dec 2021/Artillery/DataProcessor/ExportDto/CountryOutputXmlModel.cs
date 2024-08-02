using System.Xml.Serialization;

using Artillery.Data.Models;

namespace Artillery.DataProcessor.ExportDto
{
    [XmlType(nameof(Country))]
    public class CountryOutputXmlModel
    {
        [XmlAttribute(nameof(Country))]
        public string CountryName { get; set; } = null!;

        [XmlAttribute(nameof(ArmySize))]
        public string ArmySize { get; set; } = null!;
    }
}