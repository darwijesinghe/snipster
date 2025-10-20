---
title: Unit of Work
---

### Examples
Once registered, you can inject IUnitOfWork anywhere in your application — for example, in a controller or service class.

```csharp
using Snipster.Library.UOW;

namespace Test.Services
{
    /// <summary>
    /// Demonstrates usage of <see cref="IUnitOfWork"/> within a service class.
    /// </summary>
    public class TestService
    {
        private readonly IUnitOfWork _unitOfWork;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestService"/> class.
        /// </summary>
        /// <param name="unitOfWork">The unit of work used to access repositories.</param>
        public TestService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        /// <summary>
        /// Retrieves all <see cref="TestObject"/> entities from the database.
        /// </summary>
        /// <returns>
        /// A collection of <see cref="TestObject"/> instances.
        /// </returns>
        public async Task<IEnumerable<TestObject>> GetAllAsync()
        {
            return await _unitOfWork.Repository<TestObject>().GetAllAsync();
        }
    }
}
```