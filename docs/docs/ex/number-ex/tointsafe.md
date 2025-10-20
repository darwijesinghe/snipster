---
title: ToIntSafe()
---

## Description
Converts string to an integer safely, returns default if invalid. e.g. "123" becomes 123, "abc" becomes 0.

### Method Signature

```csharp
int ToIntSafe(this string input, int defaultValue = 0)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string input = "123";
        int result = input.ToIntSafe(); 
        // Output: 123

        string invalid = "abc";
        int safeResult = invalid.ToIntSafe(0);
        // Output: 0
    }
}
```