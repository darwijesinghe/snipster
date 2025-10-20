---
title: Setup
---

## Registering the Generic Repository in Dependency Injection
To make the `GenericRepository<T>` available throughout your application, register it inside the Program.cs (or Startup.cs for older projects).

### 1. Add Interface and Implementation to DI Container

```csharp
// Program.cs

using Microsoft.EntityFrameworkCore;
using Snipster.Library.Repository;

var builder = WebApplication.CreateBuilder(args);

// Register your DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Register the generic repository
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

var app = builder.Build();
app.Run();
```

### 2. Inject and Use in Services or Controllers
You can now inject the repository wherever needed. The repository is automatically injected and ready to use with your entities.

```csharp
using Snipster.Library.Repository;

public class TestService
{
    private readonly IGenericRepository<TestObject> _repository;

    public TestService(IGenericRepository<TestObject> repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<TestObject>> GetAllAsync()
    {
        return await _repository.GetAllAsync();
    }
}
```

## Implementing IGenericRepository<T>
The interface defines all reusable CRUD and query operations for entities.

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