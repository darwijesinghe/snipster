---
title: ToTimeZone()
---

## Description
Converts the specified `DateTime` to the specified time zone.

### Method Signature

```csharp
DateTime ToTimeZone(this DateTime date, string timeZoneId)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var utcDate = new DateTime(2023, 10, 1, 12, 0, 0, DateTimeKind.Utc);
        var pacificDate = utcDate.ToTimeZone("Pacific Standard Time");
        // pacificDate -> 10/1/2023 5:00:00 AM
    }
}
```