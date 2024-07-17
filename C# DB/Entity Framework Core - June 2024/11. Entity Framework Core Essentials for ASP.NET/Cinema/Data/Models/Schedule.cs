using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Schedule
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FilmId { get; set; }

        [ForeignKey(nameof(FilmId))]
        public Film Film { get; set; } = null!;

        [Required]
        public int HallId { get; set; }

        [ForeignKey(nameof(HallId))]
        public Hall Hall { get; set; } = null!;

        [Required]
        public DateTime Start { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}