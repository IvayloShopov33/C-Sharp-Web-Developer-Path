using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class Continent
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string ContinentCode { get; set; } = null!;

    [StringLength(50)]
    public string ContinentName { get; set; } = null!;

    [InverseProperty("ContinentCodeNavigation")]
    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
