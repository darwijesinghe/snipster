---
title: SetCacheAsync<T>()
---

## Description
Retrieves data from the cache or loads it using the provided function if not cached.

### Method Signature

```csharp
Task<T?> SetCacheAsync<T>(string key, double duration, Func<Task<T>> create) where T : class
```
### Examples

```csharp
using Snipster.Library.Cache;

namespace Test.Services
{
    /// <summary>
    /// Demonstrates usage of <see cref="ICacheService"/> within a service class.
    /// </summary>
    public class TestService
    {
        private readonly ICacheService _cacheService;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestService"/> class.
        /// </summary>
        /// <param name="cacheService">The cache service used for storing and retrieving cached data.</param>
        public TestService(ICacheService cacheService)
        {
            _cacheService = cacheService;
        }

        /// <summary>
        /// Retrieves user data with a custom cache duration.
        /// </summary>
        public async Task<User?> GetUserAsync(int userId)
        {
            string cacheKey = $"user_{userId}";

            return await _cacheService.SetCacheAsync(
                cacheKey,
                duration: 10
                async () =>
                {
                    // Simulate fetching user from database or API
                    await Task.Delay(100); 
                    return new User { Id = userId, Name = "John Doe" };
                });
        }
    }
}
```