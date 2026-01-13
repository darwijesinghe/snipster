---
title: IsAlphanumeric()
---

## Description
Validates that a string contains only English letters and ASCII digits (A–Z, a–z, 0-9). Does not allow underscores, hyphens, spaces, symbols, or Unicode characters.

### Method Signature

```csharp
bool IsAlphanumeric(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        "Hello123".IsAlphanumeric();  // True
        "Hello@123".IsAlphanumeric(); // False
    }
}
```