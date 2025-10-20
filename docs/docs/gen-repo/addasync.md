---
title: AddAsync()
---

## Description
Adds a new entity to the database.

### Method Signature

```csharp
Task AddAsync(TEntity entity)
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
        /// Adds a new <see cref="TestObject"/> to the database.
        /// </summary>
        /// <param name="entity">The <see cref="TestObject"/> entity to add.</param>
        /// <returns>
        /// The created entity.
        /// </returns>
        /// <exception cref="ArgumentNullException">
        /// Thrown when the entity is null.
        /// </exception>
        public async Task<TestObject> AddAsync(TestObject entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            await _repository.AddAsync(entity);
            await _repository.SaveChangesAsync();

            return entity;
        }
    }
}
```