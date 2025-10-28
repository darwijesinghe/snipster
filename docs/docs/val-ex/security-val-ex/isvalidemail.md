---
title: IsValidEmail()
---

## Description
Validates standard, and internationalized (Unicode) email addresses.

### Method Signature

```csharp
bool IsValidEmail(this string email, bool allowUnicode = false)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // Basic valid email
        string email1 = "test@example.com";
        bool result1 = email1.IsValidEmail();   // True
        Console.WriteLine($"{email1} → {result1}");
        
        // Valid email with subdomain
        string email2 = "user@mail.sales.example.com";
        bool result2 = email2.IsValidEmail();   // True
        Console.WriteLine($"{email2} → {result2}");
        
        // Valid email with plus tag (common in Gmail)
        string email3 = "user+tag@example.com";
        bool result3 = email3.IsValidEmail();   // True
        Console.WriteLine($"{email3} → {result3}");
        
        // Missing '@' symbol
        string email4 = "invalid-email";
        bool result4 = email4.IsValidEmail();   // False
        Console.WriteLine($"{email4} → {result4}");
        
        // Consecutive dots in local part
        string email5 = "user..name@example.com";
        bool result5 = email5.IsValidEmail();   // False
        Console.WriteLine($"{email5} → {result5}");
        
        // Starts with special characters
        string email6 = "!!!@example.com";
        bool result6 = email6.IsValidEmail();   // False
        Console.WriteLine($"{email6} → {result6}");
        
        // Unicode support (local and domain parts)
        string email7 = "usér@dömäin.com";
        bool result7 = email7.IsValidEmail(allowUnicode: true);  // True
        Console.WriteLine($"{email7} → {result7}");
        
        // Invalid Unicode structure (double dot)
        string email8 = "usér..name@dömäin.com";
        bool result8 = email8.IsValidEmail(allowUnicode: true);  // False
        Console.WriteLine($"{email8} → {result8}");
        
        // Unicode domain (Greek)
        string email9 = "δοκιμή@παράδειγμα.ελ";
        bool result9 = email9.IsValidEmail(allowUnicode: true);  // True
        Console.WriteLine($"{email9} → {result9}");
        
        // Unicode domain (Chinese)
        string email10 = "用户@例子.公司";
        bool result10 = email10.IsValidEmail(allowUnicode: true);  // True
        Console.WriteLine($"{email10} → {result10}");
        
        // Subdomain with Unicode
        string email11 = "usér@mail.例子.公司";
        bool result11 = email11.IsValidEmail(allowUnicode: true);  // True
        Console.WriteLine($"{email11} → {result11}");
    }
}
```