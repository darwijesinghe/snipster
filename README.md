# Snipster

[![NuGet version](https://img.shields.io/nuget/v/Snipster.svg)](https://www.nuget.org/packages/Snipster/)
[![NuGet Downloads](https://img.shields.io/nuget/dt/Snipster.svg)](https://www.nuget.org/packages/Snipster/)
[![GitHub license](https://img.shields.io/github/license/darwijesinghe/snipster.svg)](https://opensource.org/licenses/MIT)
[![Maintenance](https://img.shields.io/maintenance/yes/2025.svg)](https://github.com/darwijesinghe/snipster/commits/main)

Snipster is a lightweight, open-source .NET utility library that provides a comprehensive collection of helper and extension methods for everyday development tasks — including validation, data formatting, parsing, security, and more. It also includes a generic repository interface with an optional EF Core-based implementation, as well as a flexible cache service for in-memory caching with configurable expiration and validation support.

Available on [NuGet](https://www.nuget.org/packages/Snipster/)  
License: MIT  
Tags: `.NET`, utilities, helpers, validations, dotnet, repository, caching, uow, excel

---

## NuGet Packages Used

| Package                                                                                       | .NET Standard 2.0 Version | .NET 6+ Version |
|-----------------------------------------------------------------------------------------------|---------------------------|-----------------|
| [Microsoft.EntityFrameworkCore](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore) | 3.1.32                    | 6.0.36          |
| [Newtonsoft.Json](https://www.nuget.org/packages/Newtonsoft.Json)                             | 13.0.1                    | 13.0.1          |
| [ClosedXML](https://www.nuget.org/packages/ClosedXML)                                         | 0.95.4                    | 0.105.0         |

---

## Installation

Add Snipster to your .NET project using the CLI:

```bash
dotnet add package Snipster
```
Or install via the NuGet Package Manager:

```bash
Install-Package Snipster
```
---

## Documentation 

Explore detailed API references, usage guides, and practical examples in the official [documentation](https://darwijesinghe.github.io/snipster/).

## Available Utilities

### Validation Extensions

| Category            | Method Highlights                                                                                                                  | Description                                           |
|---------------------|------------------------------------------------------------------------------------------------------------------------------------|-------------------------------------------------------|
| **CollectionValEx** | `IsNullOrEmpty<T>()` `HasDuplicates<T>()`                                                                                          | Check if a collection is null/empty or has duplicates |
| **CreditCardValEx** | `IsValidCreditCard()`                                                                                                              | Validates if a string is a valid card number          |
| **DateTimeValEx**   | `IsToday()` `IsFuture()` `IsPast()` `IsWeekend()` `IsWeekday()` `IsValidDate(format)`                                              | Various date validation helpers                       |
| **JsonValEx**       | `IsValidJson()`                                                                                                                    | Checks if a string is valid JSON                      |
| **SecurityValEx**   | `IsValidEmail()` `IsStrongPassword(minLength)`                                                                                     | Email, password validations                           |
| **StringValEx**     | `IsContainsIgnoreCase()` `IsValidSriLankanPhone()` `IsValidInternationalPhone()` `IsNumeric()` `IsAlphabetic()` `IsAlphanumeric()` | String-related validations                            |
| **NetworkValEx**    | `IsValidIPv4()` `IsValidIPv6()` `IsValidWebAddress()`                                                                              | Network-related validations                           |
| **ObjectValEx**     | `IsDefaultValue()` `HasProperty()`                                                                                                 | Object-related validations                            |

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
| **ObjectEx**     | `GetPropertyValue()` `SetPropertyValue()`                                                                                                                                                                                                                                                                                        | Get and set property values by name       |

---

### Helper Methods

| Category       | Method Highlights                                                                                                                    | Description                                            |
|----------------|--------------------------------------------------------------------------------------------------------------------------------------|--------------------------------------------------------|
| **JsonFx**     | `Minify()` `Prettify()`                                                                                                              | Minify and format JSON strings                         |
| **SecurityFx** | `RandomString()` `GenerateSecureToken()` `PasswordHash()` `VerifyPassword()`                                                         | Security and password utilities                        |
| **StringFx**   | `FormatBytes()` `GenerateUniqueUsername()` `GenerateGuid()`                                                                          | Friendly sizes, safe usernames, GUID control           |
| **NetworkFx**  | `IsHostAvailableAsync(host)` `BuildUrl(baseUrl, params)` `HasInternetConnectionAsync()`                                              | Network & URL Utilities (with Query Parameter Support) |
| **FileFx**     | `SafeReadText()` `SafeReadBytes()` `SafeWriteText()` `SafeWriteBytes()` `CreateTempFile()` `GetDirectorySize()` `SanitizeFileName()` | File Handling & Directory Utilities                    |
| **ExcelFx**    | `WriteToExcel()` `WriteToMemory()`                                                                                                   | Write data to a file or memory stream                  |
| **ObjectFx**   | `DeepClone<T>(T)`                                                                                                                    | Deep clone an object                                   |

---

### IGenericRepository Interface Methods

| Method Highlights                                                                                                                                                                                                         | Description                                                                                                          |
|---------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------|----------------------------------------------------------------------------------------------------------------------|
| `GetAllAsync()` `GetAllByConditionAsync()` `GetByConditionAsync()` `GetSelectedColumnsAsync()` `IsExistAsync()` `AddAsync()` `AddRangeAsync()` `Update()` `UpdateRange()` `Remove()` `RemoveAsync()` `SaveChangesAsync()` | Common generic CRUD operations using Entity Framework Core. Designed for asynchronous and synchronous data handling. |

---

### IUnitOfWork Interface Methods

| Method Highlights                                                                                        | Description                                                                                           |
|----------------------------------------------------------------------------------------------------------|-------------------------------------------------------------------------------------------------------|
| `Repository<TEntity>()` `BeginTransactionAsync()` `CommitAsync()` `RollbackAsync()` `SaveChangesAsync()` | Centralized transaction and repository management with EF Core, supporting async and sync operations. |

---

### ICacheService Interface Methods

| Method Highlights         | Description                                                       |
|---------------------------|-------------------------------------------------------------------|
| `SetCacheAsync()`         | Sets a cache entry with default duration (5 min) asynchronously   |
| `SetCacheAsync(duration)` | Sets a cache entry with a specified duration asynchronously       |
| `SetLongCacheAsync()`     | Sets a cache entry with a long (60 min) expiration asynchronously |
| `RemoveCache()`           | Removes a cache entry                                             |

---

## Contributions

Pull requests, suggestions, and feedback are welcome!  
Feel free to fork and improve or extend the utility set for the .NET community.

---

## Contributors

Thanks to these wonderful people for their contributions!   
[Contributors Graph](https://github.com/darwijesinghe/snipster/graphs/contributors)

---

## Maintainers

This project is maintained by [Darshana Wijesinghe](https://github.com/darwijesinghe).

---

## Support & Contact

Email	: [dar.dev.mail@gmail.com](mailto:dar.dev.mail@gmail.com)  
LinkedIn: [darwijesinghe](https://www.linkedin.com/in/darwijesinghe/)  
Website	: [Portfolio](https://darwijesinghe.github.io/)

---

## License

This project is licensed under the [MIT License](LICENSE.txt).