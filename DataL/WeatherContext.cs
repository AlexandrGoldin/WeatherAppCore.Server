using DataL.Entityes;
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DataL
{
    public class WeatherContext : DbContext
    {
        public DbSet<PushMessage> PushMessages { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<JsResponse> JsResponses { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Wind> Winds { get; set; }
        public DbSet<Clouds> Clouds { get; set; }
        public DbSet<Weather> Weathers { get; set; }
        public DbSet<Main> Main { get; set; }
        public DbSet<Sys> Sys { get; set; }
        public DbSet<WeatherResponse> WeatherResponses { get; set; }
        public WeatherContext(DbContextOptions<WeatherContext> options)
            : base(options)
        { }  
    }

    /// For Migrations
    public class WeatherContextFactory : IDesignTimeDbContextFactory<WeatherContext>
    {
        public WeatherContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WeatherContext>();
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=weatherAppCoreServerDb;Trusted_Connection=True;MultipleActiveResultSets=true", b => b.MigrationsAssembly("DataL"));

            return new WeatherContext(optionsBuilder.Options);
        }
    }
}
