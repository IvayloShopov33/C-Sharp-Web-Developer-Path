using System.ComponentModel.DataAnnotations;

namespace AcademicRecordsApp.Data.Models
{
    public class Course
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public string Name { get; set; }

        public virtual ICollection<CourseStudent> Students { get; set; } = new HashSet<CourseStudent>();
    }
}