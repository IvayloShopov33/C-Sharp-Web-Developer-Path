using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace StudentSystemApp.Data.Models;

[Table("Student")]
public partial class Student
{
    [Key]
    public int StudentId { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [StringLength(10)]
    [Unicode(false)]
    public string? PhoneNumber { get; set; }

    public DateTime RegisteredOn { get; set; }

    public DateTime Birthday { get; set; }

    [InverseProperty("Student")]
    public virtual ICollection<Homework> Homeworks { get; set; } = new List<Homework>();

    [ForeignKey("StudentId")]
    [InverseProperty("Students")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}
