---
title: IsValidDate()
---

## Description
Validates if a given string is a valid date in a specific format.

### Method Signature

```csharp
bool IsValidDate(this string input, string format = "yyyy-MM-dd")
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        string validDate = "2023-10-01";
        string invalidDate = "2023-13-01"; // Invalid month

        Console.WriteLine(validDate.IsValidDate());   // True
        Console.WriteLine(invalidDate.IsValidDate()); // False
    }
}
```

> [!NOTE]
> - `IsToday`, `IsFuture`, and `IsPast` typically rely on `DateTime.Now` or `DateTime.Today` for comparison.  
> - `IsWeekend` and `IsWeekday` use the `DayOfWeek` property to determine whether a date falls on a weekday or weekend.  
> - `IsValidDate` is useful for validating date input before parsing or storing it in a database.