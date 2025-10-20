---
title: ToDateString()
---

## Description
Formats a `DateTime` as a date string of `yyyy-MM-dd`.

### Method Signature

```csharp
string ToDateString(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 10, 1);
        string result = date.ToDateString();
        // result -> "2023-10-01"
    }
}
```