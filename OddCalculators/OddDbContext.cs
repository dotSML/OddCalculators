using Microsoft.EntityFrameworkCore;

namespace OddCalculators
{
    public class OddDbContext : DbContext
    {
        public OddDbContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<Customer> Customers { get; set; }
    }
}