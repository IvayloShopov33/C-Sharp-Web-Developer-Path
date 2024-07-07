using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.Models
{
    [Index("Egn", IsUnique = true, Name = "IX_Egn")]
    public class Employee
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(10)]
        public string Egn {  get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [NotMapped]
        public string FullName => $"{this.FirstName} {this.LastName}";

        public DateTime? StartWorkDate { get; set; }

        public decimal Salary { get; set; }

        public int? ManagerId { get; set; }

        public virtual Employee Manager { get; set; }

        public ICollection<Employee> Managees { get; set; } = new HashSet<Employee>();

        [Required]
        public int DepartmentId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        [InverseProperty("Employees")]
        public virtual Department Department { get; set; }

        [Required]
        public int AddressId { get; set; }

        public virtual Address Address { get; set; }

        public ICollection<Club> Clubs { get; set; } = new HashSet<Club>();

        public int? BirthTownId { get; set; }

        [InverseProperty(nameof(Town.NativeCitizens))]
        public virtual Town BirthTown { get; set; }

        public int? WorkplaceTownId { get; set; }

        [InverseProperty(nameof(Town.Workers))]
        public virtual Town WorkplaceTown { get; set; }
    }
}