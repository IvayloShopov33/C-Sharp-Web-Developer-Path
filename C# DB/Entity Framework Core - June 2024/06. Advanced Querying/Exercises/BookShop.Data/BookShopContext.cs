using System.Reflection;

namespace BookShop.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;
    using EntityConfiguration;
    using System.Collections.Generic;
    using System.Reflection.Emit;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
        : base(options) { }

        public DbSet<Book> Books { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Author> Authors { get; set; }

        public DbSet<BookCategory> BooksCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new CategoryConfiguration());

            modelBuilder
                .Entity<Author>()
                .Property(x => x.FirstName)
                .IsRequired(false)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
                .Entity<Author>()
                .Property(x => x.LastName)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
                .Entity<Book>()
                .Property(x => x.Title)
                .HasMaxLength(50)
                .IsUnicode(true);

            modelBuilder
                .Entity<Book>()
                .Property(x => x.Description)
                .HasMaxLength(1000)
                .IsUnicode(true);

            modelBuilder
                .Entity<Book>()
                .Property(x => x.ReleaseDate)
                .IsRequired(false);

            modelBuilder
                .Entity<Category>()
                .Property(x => x.Name)
                .HasMaxLength(50)
                .IsUnicode(true);
        }
    }
}