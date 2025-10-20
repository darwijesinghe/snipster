---
title: GetSelectedColumnsAsync()
---

## Description
Projects a selection of fields from entities.

### Method Signature

```csharp
Task<IEnumerable<TResult>> GetSelectedColumnsAsync<TResult>(Expression<Func<TEntity, TResult>> selector)
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
        /// Retrieves specific columns from all <see cref="TEntity"/> instances in the database
        /// and prints the selected data to the console.
        /// </summary>
        public async Task GetSelectedColumnsAsync()
        {
            var projections = await _repository.GetSelectedColumnsAsync(x => new { x.Name, x.Value });

            foreach (var item in projections)
                Console.WriteLine($"{item.Name}: {item.Value}");
        }
    }
}
```