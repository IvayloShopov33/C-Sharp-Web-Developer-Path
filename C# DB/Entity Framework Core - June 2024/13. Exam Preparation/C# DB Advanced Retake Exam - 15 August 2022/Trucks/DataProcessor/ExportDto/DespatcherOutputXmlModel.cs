using System.Xml.Serialization;

using Trucks.Data.Models;

namespace Trucks.DataProcessor.ExportDto
{
    [XmlType(nameof(Despatcher))]
    public class DespatcherOutputXmlModel
    {
        [XmlElement("DespatcherName")]
        public string Name { get; set; } = null!;

        [XmlAttribute(nameof(TrucksCount))]
        public int TrucksCount { get; set; }

        [XmlArray(nameof(Trucks))]
        [XmlArrayItem(nameof(Truck))]
        public TruckOutputXmlModel[] Trucks { get; set; } = null!;
    }
}