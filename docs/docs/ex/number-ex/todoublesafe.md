---
title: ToDoubleSafe()
---

## Description
Converts string to a double safely, returns default if invalid. e.g. "123.45" becomes 123.45, "abc" becomes 0.

### Method Signature

```csharp
double ToDoubleSafe(this string input, double defaultValue = 0)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string input = "123.45";
        double result = input.ToDoubleSafe();
        // Output: 123.45

        string invalid = "xyz";
        double safeResult = invalid.ToDoubleSafe(-1);
        // Output: -1
    }
}
```