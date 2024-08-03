using System.Xml.Serialization;

using TravelAgency.Data.Models;

namespace TravelAgency.DataProcessor.ExportDtos
{
    [XmlType(nameof(TourPackage))]
    public class TourPackageOutputXmlModel
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [XmlElement(nameof(Description))]
        public string Description { get; set; }

        [XmlElement(nameof(Price))]
        public string Price { get; set; } = null!;
    }
}