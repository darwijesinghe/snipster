---
title: ToOrdinal()
---

## Description
Converts a number to its ordinal representation as a string. e.g. "1st", "2nd", "3rd", "4th", etc.

### Method Signature

```csharp
string ToOrdinal(this int number)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        int num1 = 1;
        string result1 = num1.ToOrdinal(); 
        // Output: "1st"

        int num2 = 10;
        string result2 = num2.ToOrdinal(); 
        // Output: "10th"
    }
}
```