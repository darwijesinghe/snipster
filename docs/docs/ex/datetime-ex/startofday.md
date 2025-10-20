---
title: StartOfDay()
---

## Description
Converts `DateTime` to the start of the day (00:00:00).

### Method Signature

```csharp
DateTime StartOfDay(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 10, 1, 15, 30, 45);
        var result = date.StartOfDay();
        // result -> 2023-10-01 00:00:00
    }
}
```