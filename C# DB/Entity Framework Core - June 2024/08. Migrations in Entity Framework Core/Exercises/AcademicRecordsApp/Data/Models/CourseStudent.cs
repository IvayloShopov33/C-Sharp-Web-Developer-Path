using System.ComponentModel.DataAnnotations;

namespace AcademicRecordsApp.Data.Models
{
    public class CourseStudent
    {
        [Required]
        public int CourseId { get; set; }

        public Course Course { get; set; }

        [Required]
        public int StudentId { get; set; }

        public Student Student { get; set; }
    }
}