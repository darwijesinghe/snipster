---
title: IsValidIPv4()
---

## Description
Validates if a given string is a valid IPv4 address, where each segment (x) is an integer between 0 and 255.


### Method Signature

```csharp
bool IsValidIPv4(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        string validIPv4 = "192.168.1.1";
        string invalidIPv4 = "999.999.999.999";

        Console.WriteLine(validIPv4.IsValidIPv4());   // True
        Console.WriteLine(invalidIPv4.IsValidIPv4()); // False
    }
}
```