using System.Xml.Serialization;

using Footballers.Data.Models;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType(nameof(Footballer))]
    public class FootballerOutputXmlModel
    {
        [XmlElement(nameof(Name))]
        public string Name { get; set; } = null!;

        [XmlElement("Position")]
        public string PositionType { get; set; } = null!;
    }
}