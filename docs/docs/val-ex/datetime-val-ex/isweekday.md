---
title: IsWeekday()
---

## Description
Returns true if the date is a weekday (Monday–Friday).

### Method Signature

```csharp
bool IsWeekday(this DateTime date)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        var monday  = new DateTime(2023, 10, 9);
        var saturday = new DateTime(2023, 10, 7);

        Console.WriteLine(monday.IsWeekday());   // True
        Console.WriteLine(saturday.IsWeekday()); // False
    }
}
```