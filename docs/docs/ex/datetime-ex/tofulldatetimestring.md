---
title: ToFullDateTimeString()
---

## Description
Formats a `DateTime` as a full date and time string of `yyyy-MM-dd HH:mm:ss`.

### Method Signature

```csharp
string ToFullDateTimeString(this DateTime date)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var date = new DateTime(2023, 10, 1, 15, 30, 45);
        string result = date.ToFullDateTimeString();
        // result -> "2023-10-01 15:30:45"
    }
}
```