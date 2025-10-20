---
title: ToTimeString()
---

## Description
Formats a `DateTime` as a time string of `HH:mm:ss`.

### Method Signature

```csharp
string ToTimeString(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 10, 1, 15, 30, 45);
        string result = date.ToTimeString();
        // result -> "15:30:45"
    }
}
```