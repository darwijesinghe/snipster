---
title: RemoveCache()
---

## Description
Removes a specific entry from the cache.

### Method Signature

```csharp
void RemoveCache(string key)
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
        /// Removes a specific cache entry by key.
        /// </summary>
        public void RemoveUserCache(int userId)
        {
            string cacheKey = $"user_{userId}";
            _cacheService.RemoveCache(cacheKey);
        }
    }
}
```