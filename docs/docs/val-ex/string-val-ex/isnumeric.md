---
title: IsNumeric()
---

## Description
Validates that a string contains only ASCII numeric digits (0–9). Does not allow 
whitespace, signs (+, -), decimals, or Unicode digits.

### Method Signature

```csharp
bool IsNumeric(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        "123456".IsNumeric();  // True
        "123abc".IsNumeric();  // False
    }
}
```