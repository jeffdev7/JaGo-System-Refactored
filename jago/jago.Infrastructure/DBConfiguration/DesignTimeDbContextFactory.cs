using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace jago.Infrastructure.DBConfiguration
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationContext>
    {
        public ApplicationContext CreateDbContext(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json")
               .Build();
            var builder = new DbContextOptionsBuilder<ApplicationContext>();
            var conn = config.GetConnectionString("DefaultConnection");
            builder.UseMySql(conn, new MySqlServerVersion(new Version(8, 0, 29)));
            return new ApplicationContext(builder.Options);
        }
    }
}
