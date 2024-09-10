namespace Git.Data
{
    using Microsoft.EntityFrameworkCore;

    using Git.Data.Models;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {
        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Repository> Repositories { get; set; } = null!;

        public DbSet<Commit> Commits { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Git;Integrated Security=true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Commit>()
                .HasOne(c => c.Repository)
                .WithMany(r => r.Commits)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Commit>()
                .HasOne(c => c.Creator)
                .WithMany(u => u.Commits)
                .OnDelete(DeleteBehavior.Restrict);

            base.OnModelCreating(modelBuilder);
        }
    }
}