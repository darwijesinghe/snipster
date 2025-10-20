---
title: GetByConditionAsync()
---

## Description
Retrieves the first entity matching a condition, with optional eager loading.

### Method Signature

```csharp
Task<TEntity?> GetByConditionAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
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
        /// Retrieves a single <see cref="TEntity"/> instance from the database that satisfies a specific condition
        /// and prints its details to the console.
        /// </summary>
        public async Task GetByConditionAsync()
        {
            var entity = await _repository.GetByConditionAsync(x => x.Name == "Test");

            if (entity != null)
                Console.WriteLine($"{entity.Id} - {entity.Name} - {entity.Value}");
            else
                Console.WriteLine("No matching record found.");
        }
    }
}
```