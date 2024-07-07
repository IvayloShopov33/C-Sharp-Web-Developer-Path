using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Town
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        public ICollection<Employee> NativeCitizens { get; set; } = new HashSet<Employee>();

        public ICollection<Employee> Workers { get; set; } = new HashSet<Employee>();
    }
}