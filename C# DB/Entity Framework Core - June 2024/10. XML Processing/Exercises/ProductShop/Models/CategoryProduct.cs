using System.Xml.Serialization;

namespace ProductShop.Models
{
    public class CategoryProduct
    {
        public int CategoryId { get; set; }

        [XmlIgnore]
        public Category Category { get; set; } = null!;

        public int ProductId { get; set; }

        [XmlIgnore]
        public Product Product { get; set; } = null!;
    }
}