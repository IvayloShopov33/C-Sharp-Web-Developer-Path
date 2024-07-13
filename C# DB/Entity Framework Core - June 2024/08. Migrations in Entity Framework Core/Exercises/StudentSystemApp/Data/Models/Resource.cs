using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using StudentSystemApp.Data.Models.Enums;

namespace StudentSystemApp.Data.Models;

[Table("Resource")]
[Index("CourseId", Name = "IX_Resource_CourseId")]
public partial class Resource
{
    [Key]
    public int ResourceId { get; set; }

    [StringLength(50)]
    public string Name { get; set; } = null!;

    [StringLength(200)]
    public string Url { get; set; } = null!;

    public ResourceType ResourceType { get; set; }

    public int CourseId { get; set; }

    [ForeignKey("CourseId")]
    [InverseProperty("Resources")]
    public virtual Course Course { get; set; } = null!;
}
