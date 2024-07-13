using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using StudentSystemApp.Data.Models.Enums;

namespace StudentSystemApp.Data.Models;

[Table("Homework")]
[Index("CourseId", Name = "IX_Homework_CourseId")]
[Index("StudentId", Name = "IX_Homework_StudentId")]
public partial class Homework
{
    [Key]
    public int HomeworkId { get; set; }

    public string Content { get; set; } = null!;

    public ContentType ContentType { get; set; }

    public DateTime SubmissionTime { get; set; }

    public int StudentId { get; set; }

    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Homeworks")]
    public virtual Course Course { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Homeworks")]
    public virtual Student Student { get; set; } = null!;
}
