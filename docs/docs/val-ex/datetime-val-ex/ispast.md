---
title: IsPast()
---

## Description
Returns true if the date is in the past.

### Method Signature

```csharp
bool IsPast(this DateTime date)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        var pastDate = DateTime.Now.AddDays(-10);
        var currentDate = DateTime.Now;

        Console.WriteLine(pastDate.IsPast());    // True
        Console.WriteLine(currentDate.IsPast()); // False
    }
}
```