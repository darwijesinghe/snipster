---
title: GetWeekEndDate()
---

## Description
Returns the end of the week (Sunday) for the specified `DateTime`.

### Method Signature

```csharp
DateTime GetWeekEndDate(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2025, 7, 30); // Wednesday
        DateTime result = date.GetWeekEndDate();
        // result -> 2025-08-03 23:59:59.9999999
    }
}
```