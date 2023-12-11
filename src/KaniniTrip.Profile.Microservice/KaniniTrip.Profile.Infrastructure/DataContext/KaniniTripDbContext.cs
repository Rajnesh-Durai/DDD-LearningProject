using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KaniniTrip.Profile.Domain.Entities;
using Microsoft.Extensions.Configuration;
#nullable disable

namespace KaniniTrip.Profile.Infrastructure.DataContext
{
    public class KaniniTripDbContext:DbContext
    {
        public KaniniTripDbContext(DbContextOptions<KaniniTripDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

                var connectionString = configuration.GetConnectionString("AdminSkill");
                optionsBuilder.UseSqlServer(connectionString, sqlServerOptions => sqlServerOptions.MigrationsAssembly("KaniniTrip.Profile.Application"));
            }
        }

    }
}
