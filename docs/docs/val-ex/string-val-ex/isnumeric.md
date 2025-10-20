---
title: IsNumeric()
---

## Description
Validates that a string contains only digits. Determines whether a given string contains only numeric characters (0–9).

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