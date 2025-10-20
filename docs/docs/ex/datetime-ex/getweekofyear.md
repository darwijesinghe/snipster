---
title: GetWeekOfYear()
---

## Description
Gets the week number of the year (ISO 8601). e.g. 1 for the first week of the year.

### Method Signature

```csharp
int GetWeekOfYear(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 1, 4);
        int week = date.GetWeekOfYear();
        // week -> 1
    }
}
```