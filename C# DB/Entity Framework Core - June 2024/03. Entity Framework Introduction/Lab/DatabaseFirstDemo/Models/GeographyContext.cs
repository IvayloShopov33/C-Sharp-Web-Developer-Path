using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Demo.Models;

public partial class GeographyContext : DbContext
{
    public GeographyContext()
    {
    }

    public GeographyContext(DbContextOptions<GeographyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Currency> Currencies { get; set; }

    public virtual DbSet<Mountain> Mountains { get; set; }

    public virtual DbSet<Peak> Peaks { get; set; }

    public virtual DbSet<River> Rivers { get; set; }

    public virtual DbSet<VHighestPeak> VHighestPeaks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=Geography;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Continent>(entity =>
        {
            entity.Property(e => e.ContinentCode).IsFixedLength();
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.Property(e => e.CountryCode).IsFixedLength();
            entity.Property(e => e.ContinentCode).IsFixedLength();
            entity.Property(e => e.CurrencyCode).IsFixedLength();
            entity.Property(e => e.IsoCode).IsFixedLength();

            entity.HasOne(d => d.ContinentCodeNavigation).WithMany(p => p.Countries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Countries_Continents");

            entity.HasOne(d => d.CurrencyCodeNavigation).WithMany(p => p.Countries).HasConstraintName("FK_Countries_Currencies");

            entity.HasMany(d => d.Rivers).WithMany(p => p.CountryCodes)
                .UsingEntity<Dictionary<string, object>>(
                    "CountriesRiver",
                    r => r.HasOne<River>().WithMany()
                        .HasForeignKey("RiverId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CountriesRivers_Rivers"),
                    l => l.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_CountriesRivers_Countries"),
                    j =>
                    {
                        j.HasKey("CountryCode", "RiverId");
                        j.ToTable("CountriesRivers");
                        j.IndexerProperty<string>("CountryCode")
                            .HasMaxLength(2)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });

        modelBuilder.Entity<Currency>(entity =>
        {
            entity.Property(e => e.CurrencyCode).IsFixedLength();
        });

        modelBuilder.Entity<Mountain>(entity =>
        {
            entity.HasMany(d => d.CountryCodes).WithMany(p => p.Mountains)
                .UsingEntity<Dictionary<string, object>>(
                    "MountainsCountry",
                    r => r.HasOne<Country>().WithMany()
                        .HasForeignKey("CountryCode")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MountainsCountries_Countries"),
                    l => l.HasOne<Mountain>().WithMany()
                        .HasForeignKey("MountainId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_MountainsCountries_Mountains"),
                    j =>
                    {
                        j.HasKey("MountainId", "CountryCode").HasName("PK_MountainsContinents");
                        j.ToTable("MountainsCountries");
                        j.IndexerProperty<string>("CountryCode")
                            .HasMaxLength(2)
                            .IsUnicode(false)
                            .IsFixedLength();
                    });
        });

        modelBuilder.Entity<Peak>(entity =>
        {
            entity.HasOne(d => d.Mountain).WithMany(p => p.Peaks)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Peaks_Mountains");
        });

        modelBuilder.Entity<VHighestPeak>(entity =>
        {
            entity.ToView("v_HighestPeak");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
