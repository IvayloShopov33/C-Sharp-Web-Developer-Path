using System.ComponentModel.DataAnnotations;

namespace MigrationsDemo.Data.Models
{
    public class Student
    {
        public int Id { get; set; }

        [StringLength(150)]
        public string FullName { get; set; } = null!;

        public int Age { get; set; }

        [StringLength(200)]
        public string? Address { get; set; }

        [StringLength(50)]
        public string Email { get; set; } = null!;
    }
}