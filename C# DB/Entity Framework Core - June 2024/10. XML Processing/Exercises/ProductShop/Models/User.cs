namespace ProductShop.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    [XmlType("User")]
    public class User
    {
        public User()
        {
            this.ProductsSold = new List<Product>();
            this.ProductsBought = new List<Product>();
        }

        [XmlIgnore]
        public int Id { get; set; }

        [XmlElement("firstName")]
        [StringLength(50)]
        public string FirstName { get; set; } = null!;

        [XmlElement("lastName")]
        [StringLength(50)]
        public string LastName { get; set; } = null!;

        [XmlElement("age")]
        public int? Age { get; set; }

        [XmlIgnore]
        public ICollection<Product> ProductsSold { get; set; } = null!;

        [XmlIgnore]
        public ICollection<Product> ProductsBought { get; set; } = null!;
    }
}