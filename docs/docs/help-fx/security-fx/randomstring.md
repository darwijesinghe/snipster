---
title: RandomString()
---

## Description
Generates a random string of specified length using allowed characters.

### Method Signature

```csharp
string RandomString(int length = 32, string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789")
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Generate a 16-character random string using letters and numbers
        string allowedChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        string randomString = SecurityFx.RandomString(16, allowedChars);

        Console.WriteLine(randomString);
        // Example Output: "hT9sZ2AbQwEfLp3X"
    }
}
```