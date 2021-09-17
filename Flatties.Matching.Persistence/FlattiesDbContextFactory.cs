using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Flatties.Matching.Persistence
{
    public class FlattiesDbContextFactory : IDesignTimeDbContextFactory<FlattiesDbContext>
    {
        public FlattiesDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile($"appsettings.Local.json", optional: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            var connectionString = configuration.GetConnectionString("Default");

            Console.WriteLine(connectionString);

            var optionsBuilder = new DbContextOptionsBuilder<FlattiesDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            return new FlattiesDbContext(optionsBuilder.Options);
        }
    }
}
