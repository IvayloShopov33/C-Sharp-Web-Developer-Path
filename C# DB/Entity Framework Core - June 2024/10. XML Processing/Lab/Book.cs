using System.Xml.Serialization;

namespace XmlDemo
{
    [XmlType("book")]
    public class Book
    {
        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("isbn")]
        public string Isbn { get; set; }

        [XmlElement("price")]
        public double Price { get; set; }
    }
}