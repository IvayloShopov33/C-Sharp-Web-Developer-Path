using Microsoft.EntityFrameworkCore;

namespace CodeFirstDemo.Models
{
    public class ForumDbContext : DbContext
    {
        public ForumDbContext()
        {

        }

        public ForumDbContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Integrated Security=true;Database=Forum;TrustServerCertificate=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Question>().Property(x => x.Content).IsUnicode(false);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Question> Questions { get; set; }

        public DbSet<Comment> Comments { get; set; }
    }
}
