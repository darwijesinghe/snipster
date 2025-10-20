---
title: GetAllByConditionAsync()
---

## Description
Retrieves all entities matching a condition, with optional eager loading.

### Method Signature

```csharp
Task<IEnumerable<TEntity>> GetAllByConditionAsync(Expression<Func<TEntity, bool>> predicate, Func<IQueryable<TEntity>, IQueryable<TEntity>>? include = null)
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
        /// Retrieves all <see cref="TEntity"/> instances from the database that satisfy a specific condition
        /// and prints them to the console.
        /// </summary>
        public async Task GetAllByConditionAsync()
        {
            var filtered = await _repository.GetAllByConditionAsync(x => x.Value > 50);

            if (filtered == null || !filtered.Any())
            {
                Console.WriteLine("No matching records found.");
                return;
            }

            foreach (var item in filtered)
                Console.WriteLine($"{item.Id} - {item.Name} - {item.Value}");
        }
    }
}
```