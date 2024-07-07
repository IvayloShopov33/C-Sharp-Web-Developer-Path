using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class EmployeeInClub
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EmployeeId { get; set; }

        public virtual Employee Employee { get; set; }

        [Required]
        public int ClubId { get; set; }

        public virtual Club Club { get; set; }

        [Required]
        public DateTime JoinedDate { get; set; }
    }
}