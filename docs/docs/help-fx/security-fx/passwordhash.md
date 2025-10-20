---
title: PasswordHash()
---

## Description
Generates a hashed password and salt using HMACSHA256.

### Method Signature

```csharp
void PasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Hash a user password with salt
        string password = "MySecurePassword123";
        SecurityFx.PasswordHash(password, out byte[] passwordHash, out byte[] passwordSalt);

        Console.WriteLine($"Hash: {Convert.ToBase64String(passwordHash)}");
        Console.WriteLine($"Salt: {Convert.ToBase64String(passwordSalt)}");

        // Example Output:
        // Hash: j0rxVgxxyA2u7M3p6qYH1o/4D6DfKj5Wx9lIuK9LZqU=
        // Salt: 7hK4tG0r6pJd3yE5xL1aOw==
        // Note: The actual hash and salt values will vary each time.
    }
}
```