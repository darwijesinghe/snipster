---
title: ToUnixTimestamp()
---

## Description
Converts a `DateTime` to a Unix timestamp (seconds since Unix epoch: 1970-01-01T00:00:00Z).

### Method Signature

```csharp
long ToUnixTimestamp(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        long timestamp = date.ToUnixTimestamp();
        // timestamp -> 1609459200
    }
}
```