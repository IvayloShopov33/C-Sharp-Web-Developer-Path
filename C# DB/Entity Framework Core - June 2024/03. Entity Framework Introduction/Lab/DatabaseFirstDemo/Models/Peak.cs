using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class Peak
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string PeakName { get; set; } = null!;

    public int Elevation { get; set; }

    public int MountainId { get; set; }

    [ForeignKey("MountainId")]
    [InverseProperty("Peaks")]
    public virtual Mountain Mountain { get; set; } = null!;
}
