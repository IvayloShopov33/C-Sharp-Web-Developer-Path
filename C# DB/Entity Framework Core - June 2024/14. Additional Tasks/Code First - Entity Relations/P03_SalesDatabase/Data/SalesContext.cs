﻿using Microsoft.EntityFrameworkCore;

using P03_SalesDatabase.Data.Extensions;
using P03_SalesDatabase.Data.Models;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {
            
        }

        public SalesContext(DbContextOptions options)
            : base(options) 
        {
            
        }

        public DbSet<Product> Products { get; set; } = null!;

        public DbSet<Customer> Customers { get; set; } = null!;

        public DbSet<Store> Stores { get; set; } = null!;

        public DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=Sales;Integrated Security=true;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();

            base.OnModelCreating(modelBuilder);
        }
    }
}