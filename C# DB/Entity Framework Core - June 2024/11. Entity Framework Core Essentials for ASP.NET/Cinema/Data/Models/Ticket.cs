using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CinemaApp.Data.Models
{
    public class Ticket
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }

        [Required]
        [Column(TypeName = "decimal(10, 2)")]
        public decimal BasePrice { get; set; }

        [ForeignKey(nameof(CustomerId))]
        public Customer Customer { get; set; } = null!;

        [Required]
        public int SeatId { get; set; }

        [ForeignKey(nameof(SeatId))]
        public Seat Seat { get; set; } = null!;

        [Required]
        public int ScheduleId { get; set; }

        [ForeignKey(nameof(ScheduleId))] 
        public Schedule Schedule { get; set; } = null!;

        [Required]
        public int TariffId { get; set; }

        [ForeignKey(nameof(TariffId))]
        public Tariff Tariff { get; set; } = null!;
    }
}