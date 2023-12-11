using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using KaniniTrip.Package.Domain.Entities;
#nullable disable

namespace KaniniTrip.Package.Infrastructure.DataContext
{
    public class KaniniTripDbContext:DbContext
    {
        public KaniniTripDbContext(DbContextOptions<KaniniTripDbContext> options) : base(options) { }
        public DbSet<PackageDetails> PackageDetails { get; set; }
        public DbSet<Place> Places { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("Packages");
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("KaniniTrip.Package.Application"));
            }
        }

    }
}
