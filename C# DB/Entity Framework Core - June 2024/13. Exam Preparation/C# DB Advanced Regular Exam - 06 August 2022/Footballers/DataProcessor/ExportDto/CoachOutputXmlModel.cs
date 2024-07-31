using System.Xml.Serialization;

using Footballers.Data.Models;

namespace Footballers.DataProcessor.ExportDto
{
    [XmlType(nameof(Coach))]
    public class CoachOutputXmlModel
    {
        [XmlElement("CoachName")]
        public string Name { get; set; } = null!;

        [XmlAttribute(nameof(FootballersCount))]
        public int FootballersCount { get; set; }

        [XmlArray(nameof(Footballers))]
        [XmlArrayItem(nameof(Footballer))]
        public FootballerOutputXmlModel[] Footballers { get; set; }
    }
}