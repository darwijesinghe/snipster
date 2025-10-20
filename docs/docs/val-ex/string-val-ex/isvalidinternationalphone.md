---
title: IsValidInternationalPhone()
---

## Description
Checks if the string is a valid international phone number (starts with + and contains 10–15 digits).

### Method Signature

```csharp
bool IsValidInternationalPhone(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        "+941234567890".IsValidInternationalPhone(); // True
        "12345".IsValidInternationalPhone();         // False
    }
}
```