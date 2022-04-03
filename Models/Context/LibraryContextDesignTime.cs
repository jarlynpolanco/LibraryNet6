using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Models.Context
{
    public class LibraryContextDesignTime : IDesignTimeDbContextFactory<LibraryContext>
    {
        public LibraryContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory().Replace("Models", "Library"))
           .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
           .AddJsonFile($"appsettings.Development.json", optional: true, reloadOnChange: true)
           .Build();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            var builder = new DbContextOptionsBuilder<LibraryContext>();
            builder.UseSqlServer(connectionString,
                opts => opts.CommandTimeout((int)TimeSpan.FromMinutes(20).TotalSeconds));
            return new LibraryContext(builder.Options);
        }
    }
}
