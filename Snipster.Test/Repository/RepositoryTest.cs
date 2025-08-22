using Microsoft.EntityFrameworkCore;
using Snipster.Library.Repository;
using Snipster.Test.Models;

namespace Snipster.Test.Repository
{
#nullable disable

    /// <summary>
    /// Tests for the Repository class.
    /// </summary>
    [TestClass]
    public class RepositoryTest
    {
        private TestAppDbContext               _context;
        private IGenericRepository<TestObject> _repository;

        [TestInitialize]
        public void Setup()
        {
            // configure the in-memory database for testing
            var options = new DbContextOptionsBuilder<TestAppDbContext>()
                .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
                .Options;

            // create a new instance of the test application database context
            _context = new TestAppDbContext(options);

            // create a new instance of the repository using the test application database context
            _repository = new GenericRepository<TestObject>(_context);
        }

        /// <summary>
        /// Tests the AddAsync method of the repository to ensure it adds an entity correctly.
        /// </summary>
        [TestMethod]
        public async Task AddAsync_ShouldAddEntity()
        {
            // Arrange
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };

            // Act
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();
            var result = await _context!.TestObject!.FirstOrDefaultAsync(x => x.Name == "Test");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(42, result.Value);
        }

        /// <summary>
        /// Tests the AddRangeAsync method of the repository to ensure it adds multiple entities correctly.
        /// </summary>
        [TestMethod]
        public async Task AddRangeAsync_ShouldAddEntities()
        {
            // Arrange
            var entities = new List<TestObject>
            {
                new TestObject { Id = 1, Name = "Test", Value = 42 },
                new TestObject { Id = 2, Name = "Test2", Value = 84 }
            };

            // Act
            await _repository.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            var result = await _context.TestObject.ToListAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
        }

        /// <summary>
        /// Tests the UpdateAsync method of the repository to ensure it updates an entity correctly.
        /// </summary>
        [TestMethod]
        public async Task UpdateAsync_ShouldUpdateEntity()
        {
            // Arrange
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            entity.Value = 100;
            _repository.Update(entity);
            await _context.SaveChangesAsync();
            var updatedEntity = await _context.TestObject.FirstOrDefaultAsync(x => x.Id == 1);

            // Assert
            Assert.IsNotNull(updatedEntity);
            Assert.AreEqual(100, updatedEntity.Value);
        }

        /// <summary>
        /// Tests the UpdateRangeAsync method of the repository to ensure it updates multiple entities correctly.
        /// </summary>
        [TestMethod]
        public async Task UpdateRangeAsync_ShouldUpdateMultipleEntities()
        {
            // Arrange
            var entities = new List<TestObject>
            {
                new TestObject { Id = 1, Name = "Test", Value = 42 },
                new TestObject { Id = 2, Name = "Test2", Value = 84 }
            };
            await _repository.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            // Act
            entities[0].Value = 100;
            entities[1].Value = 200;
            _repository.UpdateRange(entities);
            await _context.SaveChangesAsync();
            var updatedEntities = await _context.TestObject.ToListAsync();

            // Assert
            Assert.IsNotNull(updatedEntities);
            Assert.AreEqual(100, updatedEntities[0].Value);
        }

        /// <summary>
        /// Tests the Remove method of the repository to ensure it removes an entity correctly.
        /// </summary>
        [TestMethod]
        public async Task Remove_ShouldRemoveEntity()
        {
            // Arrange
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            _repository.Remove(entity);
            await _context.SaveChangesAsync();
            var result = await _context.TestObject.FirstOrDefaultAsync(x => x.Id == 1);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests the RemoveAsync method of the repository to ensure it removes an entity by its identifier correctly.
        /// </summary>
        [TestMethod]
        public async Task RemoveAsync_ShouldRemoveEntity()
        {
            // Arrange
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            await _repository.RemoveAsync(1);
            await _context.SaveChangesAsync();
            var result = await _context.TestObject.FirstOrDefaultAsync(x => x.Id == 1);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests the GetAllAsync method of the repository to ensure it retrieves all entities correctly.
        /// </summary>
        [TestMethod]
        public async Task GetAllAsync_ShouldReturnAllEntities()
        {
            // Arrange
            var entities = new List<TestObject>
            {
                new TestObject { Id = 1, Name = "Test", Value = 42 },
                new TestObject { Id = 2, Name = "Test2", Value = 84 }
            };
            await _repository.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllAsync();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        /// <summary>
        /// Tests the GetByConditionAsync method of the repository to ensure it retrieves an entity by a specific condition correctly.
        /// </summary>
        [TestMethod]
        public async Task GetAllByConditionAsync_ShouldReturnFilteredEntities()
        {
            // Arrange
            var entities = new List<TestObject>
            {
                new TestObject { Id = 1, Name = "Test", Value = 42 },
                new TestObject { Id = 2, Name = "Test2", Value = 84 }
            };
            await _repository.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetAllByConditionAsync(x => x.Value > 50);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("Test2", result.First().Name);
        }

        /// <summary>
        /// Tests the GetByConditionAsync method of the repository to ensure it retrieves a single entity by a specific condition correctly.
        /// </summary>
        [TestMethod]
        public async Task GetByConditionAsync_ShouldReturnSingleEntity()
        {
            // Arrange
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetByConditionAsync(x => x.Name == "Test");

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(42, result.Value);
        }

        /// <summary>
        /// Tests the GetSelectedColumnsAsync method of the repository to ensure it retrieves selected columns correctly.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task GetSelectedColumnsAsync_ShouldReturnSelectedColumns()
        {
            // Arrange
            var entities = new List<TestObject>
            {
                new TestObject { Id = 1, Name = "Test", Value = 42 },
                new TestObject { Id = 2, Name = "Test2", Value = 84 }
            };
            await _repository.AddRangeAsync(entities);
            await _context.SaveChangesAsync();

            // Act
            var result = await _repository.GetSelectedColumnsAsync(x => new { x.Name, x.Value });

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Any(x => x.Name == "Test" && x.Value == 42));
            Assert.IsTrue(result.Any(x => x.Name == "Test2" && x.Value == 84));
        }

        /// <summary>
        /// Tests the IsExistAsync method of the repository to ensure it checks for entity existence correctly.
        /// </summary>
        /// <returns></returns>
        [TestMethod]
        public async Task IsExistAsync_ShouldReturnTrueIfEntityExists()
        {
            // Arrange
            var entity = new TestObject { Id = 1, Name = "Test", Value = 42 };
            await _repository.AddAsync(entity);
            await _context.SaveChangesAsync();

            // Act
            var exists = await _repository.IsExistAsync(x => x.Id == 1);

            // Assert
            Assert.IsTrue(exists);
        }
    }
}
