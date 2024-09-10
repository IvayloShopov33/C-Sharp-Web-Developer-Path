using System.ComponentModel.DataAnnotations;

using static CarShop.Data.ModelsValidationConstraints;

namespace CarShop.Data.Models
{
    public class User
    {
        [Key]
        [MaxLength(UserIdMaxLength)]
        public string Id { get; set; } = Guid.NewGuid().ToString();

        [Required]
        [MaxLength(UserNameMaxLength)]
        public string UserName { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        public bool IsMechanic { get; set; }
    }
}