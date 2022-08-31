using EndPoints.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace EndPoints.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; } = null!;
    }
}
