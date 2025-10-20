---
title: IsAlphanumeric()
---

## Description
Validates that a string contains only letters or numbers. Determines whether a string contains only alphabetic and numeric characters (A–Z, a–z, 0–9).

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