using System.ComponentModel.DataAnnotations;

namespace CinemaApp.Data.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(60)]
        public string FirstName { get; set; } = null!;

        [Required]
        [StringLength(60)]
        public string LastName { get; set; } = null!;

        [Required]
        [StringLength(60)]
        public string Username { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = new HashSet<Ticket>();
    }
}