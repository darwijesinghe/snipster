---
title: Remove()
---

## Description
Removes an entity from the database.

### Method Signature

```csharp
void Remove(TEntity entity)
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
        /// Removes an existing <see cref="TEntity"/> instance from the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> instance to remove.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="entity"/> parameter is null.
        /// </exception>
        public async Task RemoveAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            var existingEntity = await _repository.GetByConditionAsync(x => x.Id == 1);
            if (existingEntity != null)
            {
                _repository.Remove(existingEntity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
```