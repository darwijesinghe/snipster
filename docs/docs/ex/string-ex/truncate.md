---
title: Truncate()
---

## Description
Truncates the string to a specified maximum length and optionally appends a suffix (e.g. "...").

### Method Signature

```csharp
string Truncate(this string input, int maxLength, string suffix = "...")
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello world from me".Truncate(10);
        // Output: "Hello worl..."
    }
}
```