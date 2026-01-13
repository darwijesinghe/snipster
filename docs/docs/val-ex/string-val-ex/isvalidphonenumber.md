---
title: IsValidPhoneNumber()
---

## Description
Validates a phone number and returns it in E.164 format. Accepts common user input and applies 
region-specific rules when needed.

### Method Signature

```csharp
bool IsValidPhoneNumber(this string input, string? region, out string? formattedNumber)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{  
    public static void Main()
    {
        // 🇱🇰 Sri Lanka — International format
        var isValidLk1 = "+94 70 229 3007"
            .IsValidatePhoneNumber(null, out var lkFormatted1);
        // isValidLk1 == true
        // lkFormatted1 == "+94702293007"

        // 🇱🇰 Sri Lanka — National format
        var isValidLk2 = "0702293007"
            .IsValidatePhoneNumber("LK", out var lkFormatted2);
        // isValidLk2 == true
        // lkFormatted2 == "+94702293007"

        // 🇺🇸 United States — International format
        var isValidUs1 = "+1 202 555 0125"
            .IsValidatePhoneNumber(null, out var usFormatted1);
        // isValidUs1 == true
        // usFormatted1 == "+12025550125"

        // 🇺🇸 United States — National format
        var isValidUs2 = "(202) 555-0125"
            .IsValidatePhoneNumber("US", out var usFormatted2);
        // isValidUs2 == true
        // usFormatted2 == "+12025550125"

        // 🇬🇧 United Kingdom — International format
        var isValidUk1 = "+44 7911 123456"
            .IsValidatePhoneNumber(null, out var ukFormatted1);
        // isValidUk1 == true
        // ukFormatted1 == "+447911123456"

        // 🇬🇧 United Kingdom — National format
        var isValidUk2 = "07911 123456"
            .IsValidatePhoneNumber("GB", out var ukFormatted2);
        // isValidUk2 == true
        // ukFormatted2 == "+447911123456"

        // Invalid number
        var isValidInvalid = "12345"
            .IsValidatePhoneNumber("LK", out var invalidFormatted);
        // isValidInvalid == false
        // invalidFormatted == null
    }
}
```

> [!NOTE]  
> - Formatting characters are handled internally by Google's libphonenumber.
> - Consumers can pass raw user input without pre-cleaning.