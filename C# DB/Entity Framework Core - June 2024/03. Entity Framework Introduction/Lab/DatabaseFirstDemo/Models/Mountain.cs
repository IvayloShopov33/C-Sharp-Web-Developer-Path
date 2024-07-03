using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class Mountain
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string MountainRange { get; set; } = null!;

    [InverseProperty("Mountain")]
    public virtual ICollection<Peak> Peaks { get; set; } = new List<Peak>();

    [ForeignKey("MountainId")]
    [InverseProperty("Mountains")]
    public virtual ICollection<Country> CountryCodes { get; set; } = new List<Country>();
}
