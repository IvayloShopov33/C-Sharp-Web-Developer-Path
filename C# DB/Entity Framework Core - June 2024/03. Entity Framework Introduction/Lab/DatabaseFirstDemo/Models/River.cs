using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class River
{
    [Key]
    public int Id { get; set; }

    [StringLength(50)]
    public string RiverName { get; set; } = null!;

    public int Length { get; set; }

    public int DrainageArea { get; set; }

    public int AverageDischarge { get; set; }

    [StringLength(50)]
    public string Outflow { get; set; } = null!;

    [ForeignKey("RiverId")]
    [InverseProperty("Rivers")]
    public virtual ICollection<Country> CountryCodes { get; set; } = new List<Country>();
}
