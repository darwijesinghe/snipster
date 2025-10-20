---
title: IsFuture()
---

## Description
Returns true if the date is in the future.

### Method Signature

```csharp
bool IsFuture(this DateTime date)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        var futureDate = DateTime.Now.AddDays(5);
        var pastDate = DateTime.Now.AddDays(-5);

        Console.WriteLine(futureDate.IsFuture()); // True
        Console.WriteLine(pastDate.IsFuture());   // False
    }
}
```