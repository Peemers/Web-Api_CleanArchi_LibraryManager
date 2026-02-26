using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

//refaire la factory sans ia

namespace LibraryManager.Infrastructure.DataBase;

public class LibraryManagerContextFactory
  : IDesignTimeDbContextFactory<LibraryManagerContext>
{
  
  public LibraryManagerContext CreateDbContext(string[] args)
  {
    var apiPath = Path.Combine(Directory.GetCurrentDirectory(), "../LibraryManager.Api");
    
    IConfiguration configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .AddJsonFile("appsettings.Development.json", optional: true)
      .Build();

    
    var connectionString = configuration.GetConnectionString("Default");

    
    var optionsBuilder = new DbContextOptionsBuilder<LibraryManagerContext>();
    optionsBuilder.UseSqlServer(connectionString);

    
    return new LibraryManagerContext(optionsBuilder.Options); 
  }
}
