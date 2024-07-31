using System.ComponentModel.DataAnnotations;

using static Footballers.Data.ModelsValidationConstraints;

namespace Footballers.Data.Models
{
    public class Coach
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(CoachNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        public string Nationality { get; set; } = null!;

        public virtual ICollection<Footballer> Footballers { get; set; } = new HashSet<Footballer>();
    }
}