---
title: FromUnixTimestamp()
---

## Description
Converts a Unix timestamp to `DateTime` (UTC). e.g. 1609459200 to 2021-01-01T00:00:00Z.

### Method Signature

```csharp
DateTime FromUnixTimestamp(this long timestamp)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        long timestamp = 1609459200;
        DateTime date = timestamp.FromUnixTimestamp();
        // date -> 2021-01-01 00:00:00 (UTC)
    }
}
```