using Boardgames.Data.Models;
using System.Xml.Serialization;

namespace Boardgames.DataProcessor.ExportDto
{
    [XmlType(nameof(Creator))]
    public class CreatorOutputXmlModel
    {
        [XmlElement("CreatorName")]
        public string Name { get; set; } = null!;

        [XmlAttribute(nameof(BoardgamesCount))]
        public int BoardgamesCount { get; set; }

        [XmlArray(nameof(Boardgames))]
        [XmlArrayItem(nameof(Boardgame))]
        public BoardgameOutputXmlModel[] Boardgames { get; set; } = null!;
    }
}