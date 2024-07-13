using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace AcademicRecordsApp.Data.Models;

public partial class Exam
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; } = null!;

    [InverseProperty("Exam")]
    public virtual ICollection<Grade> Grades { get; set; } = new HashSet<Grade>();
}