using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static CarShop.Data.ModelsValidationConstraints;

namespace CarShop.Data.Models
{
    public class Issue
    {
        [Key]
        [MaxLength(IssueIdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        public string Description { get; set; } = null!;

        [Required]
        public bool IsFixed { get; set; }

        [Required]
        [ForeignKey(nameof(Car))]
        public string CarId { get; set; }

        public virtual Car Car { get; set; }
    }
}