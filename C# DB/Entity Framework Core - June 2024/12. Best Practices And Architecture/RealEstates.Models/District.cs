using System.ComponentModel.DataAnnotations;

namespace RealEstates.Models
{
    public class District
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Property> Properties { get; set; } = new HashSet<Property>();
    }
}