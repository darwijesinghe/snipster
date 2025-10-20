---
title: IsStrongPassword()
---

## Description
Validates if a password meets basic rules. Typically checks for a `minimum length`, `at least one uppercase letter`, `one lowercase letter`, `one digit`, and `one special character`.

### Method Signature

```csharp
bool IsStrongPassword(this string input, int minLength = 8)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        string password1 = "StrongP@ss1";
        bool result1 = password1.IsStrongPassword(); // True

        string password2 = "weak";
        bool result2 = password2.IsStrongPassword(); // False
    }
}
```