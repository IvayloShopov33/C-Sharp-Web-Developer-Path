using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealEstates.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Size { get; set; }

        public int? YardSize { get; set; }

        public byte? Floor { get; set; }

        public byte? TotalFloors { get; set; }

        [Required]
        public int DistrictId { get; set; }

        [ForeignKey(nameof(DistrictId))]
        public virtual District District { get; set; }

        public int? Year { get; set; }

        [Required]
        public int PropertyTypeId { get; set; }

        [ForeignKey(nameof(PropertyTypeId))]
        public virtual PropertyType PropertyType { get; set; }

        [Required]
        public int BuildingTypeId { get; set; }

        [ForeignKey(nameof(BuildingTypeId))]
        public virtual BuildingType BuildingType { get; set; }

        /// <summary>
        ///  Gets or sets the property's price in EUR
        /// </summary>
        public int? Price { get; set; }

        public virtual ICollection<Tag> Tags { get; set; } = new HashSet<Tag>();
    }
}