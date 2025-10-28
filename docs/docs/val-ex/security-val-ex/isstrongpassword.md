---
title: IsStrongPassword()
---

## Description
Determines whether the specified password is considered strong based on length, character variety, and Unicode support.

### Validation Rules
A strong password must meet all of the following criteria:

- At least the specified minimum length (default: 8).
- Contains at least one digit (0–9 or any Unicode numeric digit).
- Contains at least one symbol or punctuation (e.g. @, #, !, $, emoji, etc.).
- For cased scripts → includes both uppercase and lowercase letters.
- For uncased scripts (e.g. Japanese, Chinese) → includes at least one letter.

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
        // Meets all criteria: uppercase, lowercase, digit, symbol
        string password1 = "StrongP@ss1";
        bool result1 = password1.IsStrongPassword(); // True

        // Too weak (no digits or symbols)
        string password2 = "weak";
        bool result2 = password2.IsStrongPassword(); // False

        // Supports Unicode scripts with case
        string password3 = "Ünicode1@";
        bool result3 = password3.IsStrongPassword(); // True

        // Supports uncased scripts like Japanese (has letters, digits, and symbols)
        string password4 = "パスワード123@";
        bool result4 = password4.IsStrongPassword(); // True

        // Too short (less than 8 characters)
        string password5 = "パスワード1@";
        bool result5 = password5.IsStrongPassword(); // False
    }
}
```