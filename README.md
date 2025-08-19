# Snipster

[![NuGet version](https://img.shields.io/nuget/v/Snipster.svg)](https://www.nuget.org/packages/Snipster/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Snipster.svg)](https://www.nuget.org/packages/Snipster/)
[![GitHub license](https://img.shields.io/github/license/darwijesinghe/Snipster.svg)](https://opensource.org/licenses/MIT)
[![Maintenance](https://img.shields.io/maintenance/yes/2025.svg)](https://github.com/darwijesinghe/Snipster/commits/main)

Snipster is a lightweight, open-source .NET utility library that provides a comprehensive collection of helper and extension methods for everyday development tasks — including validation, data formatting, parsing, security, and more. It also includes a generic repository interface with an optional EF Core-based implementation, as well as a flexible cache service for in-memory caching with configurable expiration and validation support.

Available on [NuGet](https://www.nuget.org/packages/Snipster/)  
License: MIT  
Tags: `.NET`, utilities, helpers, validations, dotnet, repository, caching

---

## NuGet Packages Used

| Package                                                                                       | Version |
|-----------------------------------------------------------------------------------------------|---------|
| [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) | 3.1.32  |
| [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json)                             | 13.0.1  |

---

## Installation

```bash
dotnet add package Snipster
```

---

## Available Utilities

### Validation Extensions

| Category            | Method Highlights                                                                                                                  | Description                                           |
|---------------------|------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------|
| **CollectionValEx** | `IsNullOrEmpty<T>()` `HasDuplicates<T>()`                                                                                          | Check if a collection is null/empty or has duplicates |
| **CreditCardValEx** | `IsValidCreditCard()`                                                                                                              | Validates if a string is a valid card number          |
| **DateTimeValEx**   | `IsToday()` `IsFuture()` `IsPast()` `IsWeekend()` `IsWeekday()` `IsValidDate(format)`                                              | Various date validation helpers                       |
| **JsonValEx**       | `IsValidJson()`                                                                                                                    | Checks if a string is valid JSON                      |
| **SecurityValEx**   | `IsValidEmail()` `IsStrongPassword(minLength)` `IsValidIPv4()`                                                                     | Email, password, and IPv4 validations                 |
| **StringValEx**     | `IsContainsIgnoreCase()` `IsValidSriLankanPhone()` `IsValidInternationalPhone()` `IsNumeric()` `IsAlphabetic()` `IsAlphanumeric()` | String-related validations                            |

---

### Extension Methods

| Category         | Method Highlights                                                                                                                                                                                                                                                                                                                | Description                               |
|------------------|----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------|
| **CollectionEx** | `ChunkBy()` `ToSafeDictionary()` `RandomItem()` `ForEach()` `MostCommon()` `Shuffle()` `LeastCommon()` `ExceptSafe()`                                                                                                                                                                                                            | LINQ-style enhancements for collections   |
| **CreditCardEx** | `GetCreditCardType()`                                                                                                                                                                                                                                                                                                            | Detects the card brand from a number      |
| **DateTimeEx**   | `ToUnixTimestamp()` `FromUnixTimestamp()` `ToTimeAgo()` `StartOfDay()` `EndOfDay()` `ToTimeZone()` `FromTimeZone()` `ToDateString()` `ToTimeString()` `ToFullDateTimeString()` `GetWeekStartDate()` `GetWeekEndDate()` `GetWeekOfYear()` `ToAge()`                                                                               | Rich date/time formatting and conversions |
| **JsonEx**       | `ToJson()` `FromJson<T>()`                                                                                                                                                                                                                                                                                                       | Object-to-JSON and JSON-to-object         |
| **NumberEx**     | `ToOrdinal()` `ToIntSafe()` `ToDoubleSafe()`                                                                                                                                                                                                                                                                                     | Numeric formatting and safe conversion    |
| **SecurityEx**   | `ToSha256()`                                                                                                                                                                                                                                                                                                                     | Secure hash generation                    |
| **StringEx**     | `CapitalizeFirst()` `ToTitleCase()` `OnlyDigits()` `Truncate()` `Slugify()` `ToBase64()` `FromBase64()` `OrDefault()` `StripHtmlTags()` `SanitizeAlphanumeric()` `RemoveSpecialCharacters()` `ToCamelCase()` `ToPascalCase()` `ToKebabCase()` `RemoveWhitespace()` `NormalizeSpaces()` `GetDescription()` `ToCleanQueryString()` | Powerful string manipulation toolkit      |

---

### Helper Methods

| Category       | Method Highlights                                                            | Description                                  |
|----------------|------------------------------------------------------------------------------|----------------------------------------------|
| **JsonFx**     | `Minify()` `Prettify()`                                                      | Minify and format JSON strings               |
| **SecurityFx** | `RandomString()` `GenerateSecureToken()` `PasswordHash()` `VerifyPassword()` | Security and password utilities              |
| **StringFx**   | `FormatBytes()` `GenerateUniqueUsername()` `GenerateGuid()`                  | Friendly sizes, safe usernames, GUID control |

---

### IGenericRepository Interface Methods

| Method Highlights                                                                                                                                                                                                         | Description                                                                                                          |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------|
| `GetAllAsync()` `GetAllByConditionAsync()` `GetByConditionAsync()` `GetSelectedColumnsAsync()` `IsExistAsync()` `AddAsync()` `AddRangeAsync()` `Update()` `UpdateRange()` `Remove()` `RemoveAsync()` `SaveChangesAsync()` | Common generic CRUD operations using Entity Framework Core. Designed for asynchronous and synchronous data handling. |

---

### ICacheService Interface Methods

| Method Highlights         | Description                                                       |
|---------------------------|-------------------------------------------------------------------|
| `SetCacheAsync()`         | Sets a cache entry with default duration (5 min) asynchronously   |
| `SetCacheAsync(duration)` | Sets a cache entry with a specified duration asynchronously       |
| `SetLongCacheAsync()`     | Sets a cache entry with a long (60 min) expiration asynchronously |
| `RemoveCache()`           | Removes a cache entry                                             |

---

## Example Usage

### String: Slugify & Case Conversion

```csharp
using Snipster.Library.Extensions;

var title = "Hello World!";
var slug = title.Slugify();

// Output: "hello-world"
```

### Collection: Chunk and Random Item

```csharp
using Snipster.Library.Extensions;

var numbers = Enumerable.Range(1, 10);
var chunks = numbers.ChunkBy(3);

// Output: [[1,2,3],[4,5,6],[7,8,9],[10]]
```

### JSON: Safe Serialization

```csharp
using Snipster.Library.Extensions;

var json = new { Name = "Dev" }.ToJson();

// Output: {"Name":"Dev"}

var obj = "{"Name":"Dev"}".FromJson<Dictionary<string, string>>();
Console.WriteLine(obj["Name"]);

// Output: Dev
```

### DateTime: Time Ago & Start of Day

```csharp
using Snipster.Library.Extensions;

var ago = DateTime.UtcNow.AddMinutes(-10).ToTimeAgo();

// Output: "10 minutes ago"
```

### Security: Hash a password

```csharp
using Snipster.Library.Helpers;

SecurityFx.PasswordHash("myPassword", out var hash, out var salt);
bool isValid = SecurityFx.VerifyPassword("myPassword", hash, salt);

// Output: true/false based on verification
```

### Implement IGenericRepository

```csharp
using Snipster.Library.Repository;

public class MyRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
{
    private readonly DbContext _context;
    private readonly DbSet<TEntity> _dbSet;

    public MyRepository(DbContext context)
    {
       _context = context;
       _dbSet = context.Set<TEntity>();
    }

    public async Task AddAsync(TEntity entity)
    {
       await _dbSet.AddAsync(entity);
    }

    ...
}
```

### IGenericRepository with DI

```csharp
// Register in DI
services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Then use it in your services
using Snipster.Library.Repository;

public class UserService
{
    private readonly IGenericRepository<User> _userRepository;

    public UserService(IGenericRepository<User> userRepository)
    {
       _userRepository = userRepository;
    }

    public async Task PrintAllUsersAsync()
    {
       var users = await _userRepository.GetAllAsync();
       foreach(var user in users)
       {
           Console.WriteLine(user.Name);
       }
    }

    ...
}
```

### Implement ICacheService

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

### ICacheService with DI

```csharp
// Register in DI
services.AddSingleton<ICacheService, CacheService>();

// Then use it in your services
using Snipster.Library.Cache;

public class MyService
{
    private readonly ICacheService _cacheService;

    public MyService(ICacheService cacheService)
    {
        _cacheService = cacheService;
    }

    public async Task<string?> GetDataAsync()
    {
        const string cacheKey = "my_data";

        return await _cacheService.SetCacheAsync(cacheKey, async () =>
        {
            // Simulate fetching data from a database or API
            await Task.Delay(100); 
            return "Hello from database!";
        });
    }

    ...
}
```

---

## Contributions

Pull requests, suggestions, and feedback are welcome!  
Feel free to fork and improve or extend the utility set for the .NET community.

---

## Contributors

Thanks to these wonderful people for their contributions!   
[Contributors Graph](https://github.com/darwijesinghe/Snipster/graphs/contributors)

---

## Maintainers

This project is maintained by:

- [darwijesinghe](https://github.com/darwijesinghe)

---

## Support & Contact

Email	: [dar.dev.mail@gmail.com](mailto:dar.dev.mail@gmail.com)  
LinkedIn: [darwijesinghe](https://www.linkedin.com/in/darwijesinghe/)  
Website	: [Portfolio](https://darwijesinghe.github.io/)

---

## License

This project is licensed under the [MIT License](LICENSE.txt).