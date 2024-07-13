using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp.Data.Models;

public partial class Grade
{
    [Key]
    public int Id { get; set; }

    [Column(TypeName = "decimal(3, 2)")]
    public decimal Value { get; set; }

    public int ExamId { get; set; }

    public int StudentId { get; set; }

    [ForeignKey("ExamId")]
    [InverseProperty("Grades")]
    public virtual Exam Exam { get; set; } = null!;

    [ForeignKey("StudentId")]
    [InverseProperty("Grades")]
    public virtual Student Student { get; set; } = null!;
}