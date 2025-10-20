---
title: UpdateRange()
---

## Description
Updates multiple entities.

### Method Signature

```csharp
void UpdateRange(IEnumerable<TEntity> entities)
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
        /// Updates a collection of <see cref="TEntity"/> instances in the database.
        /// </summary>
        /// <param name="entities">The collection of <see cref="TEntity"/> instances to update.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="entities"/> parameter is null or empty.
        /// </exception>
        public async Task UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            if (entities == null || !entities.Any())
                throw new ArgumentNullException(nameof(entities), "Entities collection cannot be null or empty.");

            _repository.UpdateRange(entities);
            await _repository.SaveChangesAsync();
        }
    }
}
```