using Microsoft.EntityFrameworkCore;

namespace Snipster.Test.Models
{
    /// <summary>
    /// Represents a test application database context used for unit testing purposes.
    /// </summary>
    public class TestAppDbContext : DbContext
    {
        /// <summary>
        /// Gets or sets the test object set.
        /// </summary>
        public DbSet<TestObject>? TestObject { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="TestAppDbContext"/> class.
        /// </summary>
        /// <param name="options">The context configuration options.</param>
        public TestAppDbContext(DbContextOptions<TestAppDbContext> options) : base(options)
        {

        }
    }
}
