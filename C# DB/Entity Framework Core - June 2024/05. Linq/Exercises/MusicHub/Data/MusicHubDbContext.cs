using Microsoft.EntityFrameworkCore;
using MusicHub.Data.Models;

namespace MusicHub.Data
{
    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
            
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
            
        }

        public DbSet<Song> Songs { get; set; }

        public DbSet<Album> Albums { get; set; }

        public DbSet<Performer> Performers { get; set; }

        public DbSet<Producer> Producers { get; set; }

        public DbSet<Writer> Writers { get; set; }

        public DbSet<SongPerformer> SongsPerformers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=MusicHub;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<SongPerformer>()
                .HasKey(x => new { x.SongId, x.PerformerId });

            modelBuilder
                .Entity<SongPerformer>()
                .HasOne(sp => sp.Performer)
                .WithMany(p => p.PerformerSongs)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder
                .Entity<SongPerformer>()
                .HasOne(sp => sp.Song)
                .WithMany(s => s.SongPerformers)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}