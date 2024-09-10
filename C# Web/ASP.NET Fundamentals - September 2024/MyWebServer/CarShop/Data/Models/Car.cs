using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static CarShop.Data.ModelsValidationConstraints;

namespace CarShop.Data.Models
{
    public class Car
    {
        [Key]
        [MaxLength(CarIdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(CarModelMaxLength)]
        public string Model { get; set; } = null!;

        [Required]
        public int Year { get; set; }

        [Required]
        public string PictureUrl { get; set; } = null!;

        [Required]
        [MaxLength(CarPlateNumberMaxLength)]
        public string PlateNumber { get; set; } = null!;

        [Required]
        [MaxLength(CarOwnerIdMaxLength)]
        [ForeignKey(nameof(Owner))]
        public string OwnerId { get; set; } = null!;

        public virtual User Owner { get; set; }

        public virtual ICollection<Issue> Issues { get; set; } = new HashSet<Issue>();
    }
}