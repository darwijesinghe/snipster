using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Snipster.Library.UOW;
using Snipster.Test.Models;

namespace Snipster.Test.UOW
{
#nullable disable

    /// <summary>
    /// Tests for the UnitOfWork class.
    /// </summary>
    [TestClass]
    public class UnitOfWorkTest
    {
        private TestAppDbContext _context;
        private IUnitOfWork      _unitOfWork;
        private SqliteConnection _connection;

        [TestInitialize]
        public void Setup()
        {
            // in-memory SQLite connection (supports transactions)
            _connection = new SqliteConnection("DataSource=:memory:");
            _connection.Open();

            // configure the SQLite in-memory database for testing
            var options = new DbContextOptionsBuilder<TestAppDbContext>()
            .UseSqlite(_connection)
            .Options;

            // create the db
            using var context = new TestAppDbContext(options);
            context.Database.EnsureCreated();

            // create a new instance of the test application database context
            _context = new TestAppDbContext(options);

            // create a new instance of the uow using the test application database context
            _unitOfWork = new UnitOfWork(_context);
        }

        [TestCleanup]
        public void Cleanup()
        {
            _connection.Close();
        }

        /// <summary>
        /// Verifies that the <see cref="Library.Repository.IGenericRepository{TEntity}.AddAsync"/> method
        /// correctly adds a new entity to the repository and that the changes are persisted
        /// when the <see cref="IUnitOfWork.SaveChangesAsync"/> method is called.
        /// </summary>
        [TestMethod]
        public async Task UnitOfWork_ShouldAddEntityAndSave()
        {
            // Arrange
            var repo   = _unitOfWork.Repository<TestObject>();
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };

            // Act
            await repo.AddAsync(entity);
            var result = await _unitOfWork.SaveChangesAsync();

            // Assert
            Assert.IsTrue(result);

            var all = await repo.GetAllAsync();
            Assert.AreEqual(1, all.Count());
            Assert.AreEqual("Test", all.First().Name);
        }

        /// <summary>
        /// Verifies that the <see cref="UnitOfWork"/> can provide multiple repository instances 
        /// for different/same entity types and that each repository is functional and independent.
        /// </summary>
        [TestMethod]
        public async Task UnitOfWork_ShouldSupportMultipleRepositories()
        {
            // Arrange
            var repo1 = _unitOfWork.Repository<TestObject>();
            var repo2 = _unitOfWork.Repository<TestObject>();

            // Act
            await repo1.AddAsync(new TestObject { Id = 1, Name = "RepoTest", Value = 42 });
            await _unitOfWork.SaveChangesAsync();

            var all = await repo2.GetAllAsync();

            // Assert
            Assert.AreEqual(1, all.Count());
            Assert.AreEqual("RepoTest", all.First().Name);
        }

        /// <summary>
        /// Verifies that changes made within a transaction are not persisted 
        /// when the <see cref="IUnitOfWork.RollbackAsync"/> method is called.
        /// Ensures that the repository state remains unchanged after rollback.
        /// </summary>
        [TestMethod]
        public async Task UnitOfWork_ShouldRollbackTransaction()
        {
            // Arrange
            var repo = _unitOfWork.Repository<TestObject>();

            // begin transaction
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                // adding entity
                await repo.AddAsync(new TestObject { Id = 1, Name = "RollbackTest", Value = 0 });

                // simulate error
                throw new Exception("Force rollback");

                // commit (won’t reach here)
#pragma warning disable CS0162 // Unreachable code detected
                await _unitOfWork.CommitAsync();
#pragma warning restore CS0162 // Unreachable code detected
            }
            catch
            {
                // rollback
                await _unitOfWork.RollbackAsync();
            }

            // Assert
            // verify rollback: entity should NOT exist
            var allEntities = await repo.GetAllAsync();
            Assert.AreEqual(0, allEntities.Count());
        }
    }
}
