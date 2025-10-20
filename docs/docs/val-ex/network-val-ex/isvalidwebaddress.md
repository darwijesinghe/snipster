---
title: IsValidWebAddress()
---

## Description
Validates if a given string is a valid `HTTP` or `HTTPS` web address (URL).

### Method Signature

```csharp
bool IsValidWebAddress(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        string validWebAddress = "https://www.example.com";
        string invalidWebAddress = "ftp://www.example.com";

        Console.WriteLine(validWebAddress.IsValidWebAddress());   // True
        Console.WriteLine(invalidWebAddress.IsValidWebAddress()); // False
    }
}
```