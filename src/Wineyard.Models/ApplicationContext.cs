using System;
using Microsoft.EntityFrameworkCore;

namespace Wineyard.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Grape> Grapes { get; set; }
        public DbSet<Wine> Wines { get; set; }
        // public DbSet<WineGrape> WineGrapes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var grapeEntity = modelBuilder.Entity<Grape>();

            grapeEntity.HasKey(p => p.Name);

            grapeEntity
                .Property(p => p.Name)
                .HasMaxLength(50)
                .IsRequired();

            var wineEntity = modelBuilder.Entity<Wine>();

            wineEntity.HasKey(p => new { p.WineryName, p.Label });

            wineEntity
                .Property(p => p.WineryName)
                .HasMaxLength(50)
                .IsRequired();
            wineEntity
                .Property(p => p.Label)
                .HasMaxLength(50)
                .IsRequired();
            wineEntity
                .Property(p => p.CountryName)
                .HasMaxLength(25)
                .IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
