---
title: GetCreditCardType()
---

## Description
Determines the type of credit card based on its number. Supports various card types such as `Visa`, `MasterCard`, `American Express`, `Discover`, `JCB`, and `Diners Club`.

### Method Signature

```csharp
CardType GetCreditCardType(this string number)
```
### Examples

```csharp
using Snipster.Library.Enums;
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string visaCard = "4111111111111111";
        CardType visaResult = visaCard.GetCreditCardType();
        // visaResult -> CardType.Visa

        string masterCard = "5555555555554444";
        CardType masterCardResult = masterCard.GetCreditCardType();
        // masterCardResult -> CardType.MasterCard

        string amex = "378282246310005";
        CardType amexResult = amex.GetCreditCardType();
        // amexResult -> CardType.AmericanExpress

        string discover = "6011111111111117";
        CardType discoverResult = discover.GetCreditCardType();
        // discoverResult -> CardType.Discover

        string jcb = "3530111333300000";
        CardType jcbResult = jcb.GetCreditCardType();
        // jcbResult -> CardType.JCB

        string diners = "30569309025904";
        CardType dinersResult = diners.GetCreditCardType();
        // dinersResult -> CardType.DinersClub

        string invalid = "1234567890123456";
        CardType invalidResult = invalid.GetCreditCardType();
        // invalidResult -> CardType.Unknown

        string empty = "";
        CardType emptyResult = empty.GetCreditCardType();
        // emptyResult -> CardType.Unknown

        string nonNumeric = "abcd1234";
        CardType nonNumericResult = nonNumeric.GetCreditCardType();
        // nonNumericResult -> CardType.Unknown
    }
}
```