using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class Country
{
    [Key]
    [StringLength(2)]
    [Unicode(false)]
    public string CountryCode { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string IsoCode { get; set; } = null!;

    [StringLength(45)]
    [Unicode(false)]
    public string CountryName { get; set; } = null!;

    [StringLength(3)]
    [Unicode(false)]
    public string? CurrencyCode { get; set; }

    [StringLength(2)]
    [Unicode(false)]
    public string ContinentCode { get; set; } = null!;

    public int Population { get; set; }

    public int AreaInSqKm { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string Capital { get; set; } = null!;

    [ForeignKey("ContinentCode")]
    [InverseProperty("Countries")]
    public virtual Continent ContinentCodeNavigation { get; set; } = null!;

    [ForeignKey("CurrencyCode")]
    [InverseProperty("Countries")]
    public virtual Currency? CurrencyCodeNavigation { get; set; }

    [ForeignKey("CountryCode")]
    [InverseProperty("CountryCodes")]
    public virtual ICollection<Mountain> Mountains { get; set; } = new List<Mountain>();

    [ForeignKey("CountryCode")]
    [InverseProperty("CountryCodes")]
    public virtual ICollection<River> Rivers { get; set; } = new List<River>();
}
