using Microsoft.EntityFrameworkCore;

namespace Snipster.Test.Models
{
    /// <summary>
    /// Represents a test application database context used for unit testing purposes.
    /// </summary>
    public class TestAppDbContext : DbContext
    {
        public DbSet<TestObject>? TestObject { get; set; }

        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
        {

        }
    }
}
