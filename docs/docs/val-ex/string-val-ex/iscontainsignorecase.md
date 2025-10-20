---
title: IsContainsIgnoreCase()
---

## Description
Checks if the string contains another string with case-insensitive comparison.

### Method Signature

```csharp
bool IsContainsIgnoreCase(this string source, string toCheck)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        string text = "Hello World";

        text.IsContainsIgnoreCase("world");  // True
        text.IsContainsIgnoreCase("planet"); // False
    }
}
```