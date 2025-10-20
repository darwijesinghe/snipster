---
title: VerifyPassword()
---

## Description
Verifies if the provided password matches the stored password hash using the provided salt.

### Method Signature

```csharp
bool VerifyPassword(string password, byte[] passwordHash, byte[] passwordSalt)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Verify a password against a stored hash and salt
        string password = "MySecurePassword123";
        SecurityFx.PasswordHash(password, out byte[] hash, out byte[] salt);

        bool isValid = SecurityFx.VerifyPassword(password, hash, salt);

        Console.WriteLine(isValid); // Output: True
    }
}
```