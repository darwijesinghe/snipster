---
title: IsAlphabetic()
---

## Description
Validates that a string contains only English alphabetic characters (A–Z, a–z). Does not allow spaces, accents (é, ü), or Unicode letters.

### Method Signature

```csharp
bool IsAlphabetic(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        "Hello".IsAlphabetic();    // True
        "Hello123".IsAlphabetic(); // False
        "über".IsAlphabetic();     // False
    }
}
```