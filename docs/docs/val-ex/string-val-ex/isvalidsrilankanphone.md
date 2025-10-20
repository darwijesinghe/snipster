---
title: IsValidSriLankanPhone()
---

## Description
Validates whether the string is a valid Sri Lankan phone number (starting with 07, 10 digits).

### Method Signature

```csharp
bool IsValidSriLankanPhone(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        "0712345678".IsValidSriLankanPhone(); // True
        "123456".IsValidSriLankanPhone();     // False
    }
}
```