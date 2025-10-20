---
title: GetAllAsync()
---

## Description
Retrieves all entities with optional eager loading.

### Method Signature

```csharp
Task<IEnumerable<TEntity>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
```
### Examples

```csharp
using Snipster.Library.Repository;

namespace Test.Services
{
    /// <summary>
    /// Demonstrates usage of <see cref="IGenericRepository"/> within a service class.
    /// </summary>
    public class TestService
    {
        private readonly IGenericRepository<TestObject> _repository;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestService"/> class.
        /// </summary>
        /// <param name="repository">The generic repository for data access.</param>
        public TestService(IGenericRepository<TestObject> repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Retrieves and prints all <see cref="TEntity"/> instances from the database.
        /// </summary>
        public async Task GetAllAsync()
        {
            var allItems = await _repository.GetAllAsync();

            foreach (var item in allItems)
                Console.WriteLine($"{item.Id} - {item.Name}");
        }
    }
}
```