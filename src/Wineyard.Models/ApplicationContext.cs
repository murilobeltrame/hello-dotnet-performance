using System;
using Microsoft.EntityFrameworkCore;

namespace Wineyard.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options) { }

        public DbSet<Grape> Grapes { get; set; }
        public DbSet<Wine> Wines { get; set; }
    }
}
