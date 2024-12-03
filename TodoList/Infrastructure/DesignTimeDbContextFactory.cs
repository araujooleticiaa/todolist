using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseNpgsql(
                "User ID =postgres;Password=postgres;Server=localhost;Port=5432;Database=ToDoDev;Pooling=true;");

            return new DataContext(optionsBuilder.Options);
        }
    }
}
