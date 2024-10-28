using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using static CarRentingSystem.Data.ModelsValidationConstraints;

namespace CarRentingSystem.Data.Models
{
    public class Dealer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(DealerNameMaxLength)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(DealerPhoneNumberMaxLength)]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(User))]
        public string UserId { get; set; } = null!;

        public virtual User User { get; set; }

        public virtual ICollection<Car> Cars { get; set; } = new HashSet<Car>();
    }
}