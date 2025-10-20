---
title: IsToday()
---

## Description
Returns true if the date is today.

### Method Signature

```csharp
bool IsToday(this DateTime date)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        var today = DateTime.Today;
        var yesterday = DateTime.Today.AddDays(-1);
        var tomorrow = DateTime.Today.AddDays(1);

        Console.WriteLine(today.IsToday());     // True
        Console.WriteLine(yesterday.IsToday()); // False
        Console.WriteLine(tomorrow.IsToday());  // False
    }
}
```