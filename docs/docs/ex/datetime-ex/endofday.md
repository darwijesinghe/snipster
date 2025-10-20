---
title: EndOfDay()
---

## Description
Converts `DateTime` to the end of the day (23:59:59.999).

### Method Signature

```csharp
DateTime EndOfDay(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 10, 1, 15, 30, 45);
        var result = date.EndOfDay();
        // result -> 2023-10-01 23:59:59.999
    }
}
```