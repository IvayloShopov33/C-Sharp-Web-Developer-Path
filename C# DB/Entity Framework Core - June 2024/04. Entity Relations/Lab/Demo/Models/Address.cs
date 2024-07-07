using System.ComponentModel.DataAnnotations;

namespace Demo.Models
{
    public class Address
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Employee> Employees { get; set; } = new HashSet<Employee>();
    }
}
