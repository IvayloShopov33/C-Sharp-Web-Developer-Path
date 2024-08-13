using System.ComponentModel.DataAnnotations;

namespace BlogApp.Services.Models
{
    public class RegisterViewModel
    {
        [Required]
        public string UserName { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;

        [Required]
        public string Email { get; set; } = null!;

        [Required]
        public string ConfirmPassword { get; set; } = null!;
    }
}