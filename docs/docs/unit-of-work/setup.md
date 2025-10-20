---
title: Setup
---

## Registering the Unit of Work (UoW) in Dependency Injection
To make the UnitOfWork and its dependent services (such as `GenericRepository<T>` and `DbContext`) available throughout the application, register them in the Dependency Injection (DI) container — typically inside Program.cs (or Startup.cs for older ASP.NET Core projects).

### 1. Add Required Interfaces and Implementations to DI Container

```csharp
// Program.cs

using Microsoft.EntityFrameworkCore;
using Snipster.Library.Repository;
using Snipster.Library.UOW;

var builder = WebApplication.CreateBuilder(args);

// Register your DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

// Register the unit of work
services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
app.Run();
```