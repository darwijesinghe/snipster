---
title: IsExistAsync()
---

## Description
Determines if any entity exists that matches a condition.

### Method Signature

```csharp
Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> predicate)
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
        /// Checks whether any <see cref="TEntity"/> instance in the database satisfies a specific condition
        /// and prints the result to the console.
        /// </summary>
        public async Task IsExistAsync()
        {
            bool exists = await _repository.IsExistAsync(x => x.Name == "Test");
            Console.WriteLine(exists ? "Entity exists" : "Entity not found");
        }
    }
}
```