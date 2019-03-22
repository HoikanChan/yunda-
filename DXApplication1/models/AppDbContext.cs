using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DXApplication1.models
{
    class AppDbContext:DbContext
    {
        public DbSet<Car> Cars { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<PackageGridMapping> PackageGridMappings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseMySql(ConfigurationManager.ConnectionStrings["mysql"].ConnectionString);
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
