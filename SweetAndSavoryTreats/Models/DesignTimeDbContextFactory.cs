using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SweetAndSavoryTreats.Models
{
  public class SweetAndSavoryTreatsContextFactory : IDesignTimeDbContextFactory<SweetAndSavoryTreatsContext>
  {
    SweetAndSavoryTreatsContext IDesignTimeDbContextFactory<SweetAndSavoryTreatsContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
      .SetBasePath(Directory.GetCurrentDirectory())
      .AddJsonFile("appsettings.json")
      .Build();

      var builder = new DbContextOptionsBuilder<SweetAndSavoryTreatsContext>();

      builder.UseMySql(configuration["ConnectionStrings:DefaultConnection"], ServerVersion.AutoDetect(configuration["ConnectionStrings:DefaultConnection"]));

      return new SweetAndSavoryTreatsContext(builder.Options);
    }
  }
}
