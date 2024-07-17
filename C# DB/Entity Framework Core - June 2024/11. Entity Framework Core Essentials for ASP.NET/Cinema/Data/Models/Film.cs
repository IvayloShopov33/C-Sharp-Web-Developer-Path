using CinemaApp.Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Models
{
    public class Film
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; } = null!;

        [StringLength(500)]
        public string? Description { get; set; }

        public Genre Genre { get; set; }

        public ICollection<Schedule> Schedules { get; set; } = new HashSet<Schedule>();
    }
}