---
title: GetWeekStartDate()
---

## Description
Returns the start of the week (Monday) for the specified `DateTime`.

### Method Signature

```csharp
DateTime GetWeekStartDate(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 1, 4); // Wednesday
        DateTime result = date.GetWeekStartDate();
        // result -> 2023-01-02 (Monday)
    }
}
```