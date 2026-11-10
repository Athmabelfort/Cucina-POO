using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cucina_POO.Data
{
    internal class CucinaDbContextFactory : IDesignTimeDbContextFactory<CucinaDbContext>
    {
        public CucinaDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CucinaDbContext>();

            optionsBuilder.UseSqlServer(
                "Server=localhost\\SQLEXPRESS;Database=CucinaDB;Trusted_Connection=True;TrustServerCertificate=True;");

            return new CucinaDbContext(optionsBuilder.Options);
        }
    }
}