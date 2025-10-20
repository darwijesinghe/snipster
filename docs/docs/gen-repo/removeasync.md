---
title: RemoveAsync()
---

## Description
Removes an entity by its identifier.

### Method Signature

```csharp
Task RemoveAsync(object id)
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
        /// Removes an existing <see cref="TEntity"/> instance from the database by its identifier.
        /// </summary>
        /// <param name="id">The unique identifier of the entity to remove.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="id"/> parameter is null.
        /// </exception>
        public async Task RemoveAsync(object id)
        {
            if (id == null)
                throw new ArgumentNullException(nameof(id), "Id cannot be null.");

            await _repository.RemoveAsync(id);
            await _context.SaveChangesAsync();
        }
    }
}
```