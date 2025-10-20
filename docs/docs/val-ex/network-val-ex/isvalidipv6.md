---
title: IsValidIPv6()
---

## Description
Validates if a given string is a valid IPv6 address.

### Method Signature

```csharp
bool IsValidIPv6(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        string validIPv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:7334";
        string invalidIPv6 = "2001:0db8:85a3:0000:0000:8a2e:0370:zzzz";

        Console.WriteLine(validIPv6.IsValidIPv6());   // True
        Console.WriteLine(invalidIPv6.IsValidIPv6()); // False
    }
}
```