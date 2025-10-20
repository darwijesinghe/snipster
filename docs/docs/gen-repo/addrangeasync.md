---
title: AddRangeAsync()
---

## Description
Adds multiple entities to the database.

### Method Signature

```csharp
Task AddRangeAsync(IEnumerable<TEntity> entities)
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
        /// Adds a collection of <see cref="TestObject"/> entities to the database.
        /// </summary>
        /// <param name="entities">The collection of <see cref="TestObject"/> entities to add.</param>
        /// <returns>
        /// The collection of added <see cref="TestObject"/> instances after persistence.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="entities"/> parameter is null or empty.
        /// </exception>
        public async Task<IEnumerable<TestObject>> AddRangeAsync(IEnumerable<TestObject> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities), "Entities collection cannot be null or empty.");

            await _repository.AddRangeAsync(entities);
            await _repository.SaveChangesAsync();

            return entities;
        }
    }
}
```