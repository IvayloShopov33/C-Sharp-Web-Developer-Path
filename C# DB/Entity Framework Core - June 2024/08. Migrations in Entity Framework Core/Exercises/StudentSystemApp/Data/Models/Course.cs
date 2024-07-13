using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentSystemApp.Data.Models;

[Table("Course")]
public partial class Course
{
    [Key]
    public int CourseId { get; set; }

    [StringLength(80)]
    public string Name { get; set; } = null!;

    [StringLength(500)]
    public string? Description { get; set; }

    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    [InverseProperty("Course")]
    public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    [InverseProperty("Course")]
    public virtual ICollection<Resource> Resources { get; set; } = new List<Resource>();

    [ForeignKey("CourseId")]
    [InverseProperty("Courses")]
    public virtual ICollection<Student> Students { get; set; } = new List<Student>();
}
