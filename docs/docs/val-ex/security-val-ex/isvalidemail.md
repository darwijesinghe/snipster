---
title: IsValidEmail()
---

## Description
Validates string type email address. Checks for proper structure (`username`, `domain`, and `top-level domain`).

### Method Signature

```csharp
bool IsValidEmail(this string email)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        string email1 = "test@example.com";
        bool result1 = email1.IsValidEmail(); // True

        string email2 = "invalid-email";
        bool result2 = email2.IsValidEmail(); // False
    }
}
```