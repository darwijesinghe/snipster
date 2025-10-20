---
title: OnlyDigits()
---

## Description
Removes all non-numeric characters.

### Method Signature

```csharp
string OnlyDigits(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "123@abc".OnlyDigits();  
        // Output: "123"
    }
}
```