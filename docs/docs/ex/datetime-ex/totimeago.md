---
title: ToTimeAgo()
---

## Description
Returns a human-readable "time ago" string (e.g. "3 hours ago").

### Method Signature

```csharp
string ToTimeAgo(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = DateTime.UtcNow.AddHours(-3);
        string result = date.ToTimeAgo();
        // result -> "3 hours ago"
    }
}
```