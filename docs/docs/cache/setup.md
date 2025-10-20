---
title: Setup
---

## Registering the ICacheService in Dependency Injection
To make the caching functionality available throughout your application, register the `ICacheService` and its implementation in the Dependency Injection (DI) container — typically inside Program.cs (or Startup.cs for older ASP.NET Core versions).

### 1. Add the Cache Service to the DI Container

```csharp
// Program.cs

using Snipster.Library.Cache;

var builder = WebApplication.CreateBuilder(args);

// Register cache service
services.AddSingleton<ICacheService, CacheService>();

var app = builder.Build();
app.Run();
```

### 2. Implement ICacheService

```csharp
using Snipster.Library.Cache;

public class MyCacheService : ICacheService
{
    private readonly IMemoryCache _cache;

    public MyCacheService(IMemoryCache cache)
    {
        _cache = cache;
    }

    public async Task<T?> SetCacheAsync<T>(string key, Func<Task<T>> create) where T : class
    {
        ...
    }

    ...
}
```

> [!NOTE]
> - `AddSingleton<ICacheService, CacheService>()` — Registers the cache service as a singleton, ensuring a single shared instance of the cache is used throughout the application’s lifetime.  
> - This allows you to inject `ICacheService` into any class (such as services or controllers) for centralized caching operations.
> - By implementing `ICacheService`, you can customize your caching logic as needed.