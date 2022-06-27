using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace GeneratePersons
{
    internal class Builder
    {
        public static DbContextOptions<NipigasDBContext> CreateBuild()
        {
            var builder = new ConfigurationBuilder();
            builder.SetBasePath(Directory.GetCurrentDirectory());
            builder.AddJsonFile("appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("DefaultConnection");
            var optionBuilder = new DbContextOptionsBuilder<NipigasDBContext>();
            return optionBuilder
                 .UseSqlServer(connectionString)
                 .Options;
        }
    }
}
