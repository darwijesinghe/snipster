---
title: IsValidCreditCard()
---

## Description
Validates if a given string is a valid credit card number using Luhn algorithm. Supports major card types such as `Visa`, `MasterCard`, `American Express`, and `Discover`.

### Method Signature

```csharp
bool IsValidCreditCard(this string input)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // Example 1: Valid credit card numbers
        var validCards = new List<string>
        {
            "4111111111111111",     // Visa
            "4111 1111 1111 1111",  // Visa with spaces
            "5500000000000004",     // MasterCard
            "340000000000009",      // American Express
            "6011000000000012"      // Discover
        };

        var validResults = validCards.Select(x => x.IsValidCreditCard()).ToList();
        Console.WriteLine(validResults.All(x => x)); // True (all valid)

        // Example 2: Invalid credit card numbers
        var invalidCards = new List<string>
        {
            "1234567890123456",     // Invalid Luhn checksum
            "4111111111111",        // Too short
            "41111111111111111111", // Too long
            "abcd efgh ijkl mnop",  // Non-numeric
            "",                     // Empty string
            "    ",                 // Whitespace only
            "4111-1111-1111-1111"   // Dashes instead of digits/spaces
        };

        foreach (var card in invalidCards)
        {
            bool result = card.IsValidCreditCard();
            Console.WriteLine($"{card} -> {result}"); 
            // False for all cases above
        }
    }
}
```