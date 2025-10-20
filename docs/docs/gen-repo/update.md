---
title: Update()
---

## Description
Updates an existing entity.

### Method Signature

```csharp
void Update(TEntity entity)
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
        /// Updates an existing <see cref="TEntity"/> in the database.
        /// </summary>
        /// <param name="entity">The <see cref="TEntity"/> instance to update.</param>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the <paramref name="entity"/> parameter is null.
        /// </exception>
        public async Task UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");

            _repository.Update(entity);
            await _repository.SaveChangesAsync();
        }
    }
}
```