---
title: FromTimeZone()
---

## Description
Converts a date from a specific time zone to UTC.

### Method Signature

```csharp
DateTime FromTimeZone(this DateTime date, string timeZoneId)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var localDate = new DateTime(2023, 10, 1, 12, 0, 0);
        var utcDate = localDate.FromTimeZone("Pacific Standard Time");
        // utcDate -> 10/1/2023 7:00:00 PM
    }
}
```