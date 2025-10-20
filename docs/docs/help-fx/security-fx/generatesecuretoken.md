---
title: GenerateSecureToken()
---

## Description
Generates a secure random token of specified length using cryptographic random number generation.

### Method Signature

```csharp
string GenerateSecureToken(int length = 32)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Generate a 32-character secure random token
        string secureToken = SecurityFx.GenerateSecureToken(32);

        Console.WriteLine(secureToken);
        // Example Output: "b3a41c2f5e8d9a1b7c4f0e2d1a6b3c5f"
    }
}
```