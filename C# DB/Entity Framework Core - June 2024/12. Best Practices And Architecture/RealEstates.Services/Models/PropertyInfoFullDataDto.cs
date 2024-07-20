using System.Xml.Serialization;

namespace RealEstates.Services.Models
{
    [XmlType("Property")]
    public class PropertyInfoFullDataDto
    {
        [XmlAttribute("id")]
        public int Id { get; set; }

        [XmlElement("districtName")]
        public string DistrictName { get; set; }

        [XmlElement("size")]
        public int Size { get; set; }

        [XmlElement("price")]
        public int Price { get; set; }

        [XmlElement("propertyType")]
        public string PropertyType { get; set; }

        [XmlElement("year")]
        public int? Year { get; set; }

        [XmlElement("floor")]
        public byte? Floor { get; set; }

        [XmlElement("buildingType")]
        public string BuildingType { get; set; }

        [XmlArray("Tags")]
        [XmlArrayItem("Tag")]
        public List<TagInfoDto> Tags { get; set; } = new List<TagInfoDto>();
    }
}