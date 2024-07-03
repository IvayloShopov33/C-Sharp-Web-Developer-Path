using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

[Keyless]
public partial class VHighestPeak
{
    public int Id { get; set; }

    [StringLength(50)]
    public string PeakName { get; set; } = null!;

    public int Elevation { get; set; }

    public int MountainId { get; set; }
}
