---
title: Quick Start
description: Learn how to get started quickly with Snipster utilities and examples.
---

# Quick Start

**Snipster** is a lightweight, open-source `.NET` utility library packed with 
extension and helper methods for everyday development tasks including validation, formatting, JSON handling, 
caching, and repository patterns.

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
## Inside Snipster

| Category                  | Description                                                                       |
| ------------------------- | --------------------------------------------------------------------------------- |
| **Validation Extensions** | Extensions for validating strings, dates, JSON, collections, and security inputs. |
| **Extensions**            | String, DateTime, JSON, Collection, and Security extensions for common tasks.     |
| **Helpers**               | Utility classes for JSON, File, Excel, Network, Object and Security operations.   |
| **Repository Pattern**    | Generic repository interface with async CRUD support for EF Core.                 |
| **Unit of Work**          | Centralized transaction and repository management.                                |
| **Caching Service**       | In-memory cache with configurable duration and async refresh.                     |

## Dependency Injection Setup

Easily register services in your application:

```csharp
using Snipster.Library.Repository;
using Snipster.Library.UOW;
using Snipster.Library.Cache;

services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
services.AddScoped<IUnitOfWork, UnitOfWork>();
services.AddSingleton<ICacheService, CacheService>();
```
## Why Use Snipster?

- Simplifies repetitive coding tasks.
- Fully compatible with .NET Standard 2.0 and .NET 6+.
- Clean and consistent naming conventions.
- Works across web, API, and console projects.
- 100% Open Source under MIT License.

## NuGet
Package: [Snipster on NuGet](https://www.nuget.org/packages/Snipster/)

```bash
dotnet add package Snipster
```

## Contributing

Pull requests, suggestions, and feedback are welcome!  
Feel free to fork and improve or extend the utility set for the .NET community. 

See the [Contributing Guidelines](https://github.com/darwijesinghe/Snipster/blob/main/CONTRIBUTING.md) for more info.

## Maintainers

This project is maintained by: [Darshana Wijesinghe](https://github.com/darwijesinghe)

## License

This project is licensed under the [MIT License](https://github.com/darwijesinghe/Snipster/blob/main/LICENSE.txt).