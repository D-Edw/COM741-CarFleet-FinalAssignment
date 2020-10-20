using System;
using VMS.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace VMS.Data.Repositories
{
    public class VehicleDbContext : DbContext
    {
        // DbSets for various models
        public DbSet<Vehicle> Vehicles{get; set;}
        public DbSet<Service> Services {get; set;}

        // Configure the context to use sqlite database
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlite("Filename=VMS.db")
                /** logger to log the sql commands issued by entityframework **/
                     .UseLoggerFactory(new ServiceCollection()
                     .AddLogging(builder => builder.AddConsole())
                     .BuildServiceProvider()
                     .GetService<ILoggerFactory>()
                 );
        }

        // Method to recreate the database, ensuring the new database takes account of any 
        // changes to the Models or Context.
        public void Initialise()
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        // Sql Query console logger that can be added to context for debugging 
        private static ILoggerFactory GetConsoleLoggerFactory()
        {
            IServiceCollection serviceCollection = new ServiceCollection();
            serviceCollection.AddLogging(builder => builder.AddConsole()
                .AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information)
            );
            return serviceCollection.BuildServiceProvider()
                .GetService<ILoggerFactory>();
        }
        
    }
}