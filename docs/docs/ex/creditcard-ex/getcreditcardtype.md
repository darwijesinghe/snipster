---
title: GetCreditCardType()
---

## Description
Determines the type of credit card based on its number. Supports various card types such as `Visa`, `MasterCard`, `American Express`, `Discover`, `JCB`, and `Diners Club`.

### Method Signature

```csharp
string GetCreditCardType(this string number)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string visaCard = "4111111111111111";
        string result = visaCard.GetCreditCardType();
        // result -> "Visa"

        string masterCard = "5555555555554444";
        string result = masterCard.GetCreditCardType();
        // result -> "MasterCard"

        string amex = "378282246310005";
        string result = amex.GetCreditCardType();
        // result -> "American Express"

        string discover = "6011111111111117";
        string result = discover.GetCreditCardType();
        // result -> "Discover"

        string jcb = "3530111333300000";
        string result = jcb.GetCreditCardType();
        // result -> "JCB"

        string diners = "30569309025904";
        string result = diners.GetCreditCardType();
        // result -> "Diners Club"

        string invalid = "1234567890123456";
        string result = invalid.GetCreditCardType();
        // result -> "Unknown"

        string empty = "";
        string result = empty.GetCreditCardType();
        // result -> "Unknown"

        string nonNumeric = "abcd1234";
        string result = nonNumeric.GetCreditCardType();
        // result -> "Unknown"
    }
}
```