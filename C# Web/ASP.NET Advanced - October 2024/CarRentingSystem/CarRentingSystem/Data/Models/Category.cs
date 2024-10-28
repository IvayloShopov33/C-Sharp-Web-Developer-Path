using System.ComponentModel.DataAnnotations;

using static CarRentingSystem.Data.ModelsValidationConstraints;

namespace CarRentingSystem.Data.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}