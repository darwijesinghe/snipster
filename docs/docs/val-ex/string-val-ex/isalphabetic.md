---
title: IsAlphabetic()
---

## Description
Validates that a string contains only letters (no `digits` or `symbols`).

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
    }
}
```