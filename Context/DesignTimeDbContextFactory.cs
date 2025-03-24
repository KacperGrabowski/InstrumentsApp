using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace InstrumentsApp.Context {
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext> {
        public DataContext CreateDbContext(string[] args) {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();

            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = config.GetConnectionString("DefaultConnection");

            optionsBuilder.UseSqlServer(connectionString);

            return new DataContext(optionsBuilder.Options);
        }
    }
}