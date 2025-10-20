---
title: IsWeekend()
---

## Description
Returns true if the date is a weekend (Saturday or Sunday).

### Method Signature

```csharp
bool IsWeekend(this DateTime date)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        var saturday = new DateTime(2023, 10, 7);
        var sunday   = new DateTime(2023, 10, 8);
        var monday   = new DateTime(2023, 10, 9);

        Console.WriteLine(saturday.IsWeekend()); // True
        Console.WriteLine(sunday.IsWeekend());   // True
        Console.WriteLine(monday.IsWeekend());   // False
    }
}
```