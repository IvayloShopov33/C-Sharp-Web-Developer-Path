using System.Xml.Serialization;

namespace RealEstates.Services.Models
{
    public class TagInfoDto
    {
        [XmlAttribute("name")]
        public string Name { get; set; }
    }
}