---
title: RemoveWhitespace()
---

## Description
Removes all whitespace (`spaces`, `tabs`, `newlines`) from the string.

### Method Signature

```csharp
string RemoveWhitespace(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello   World".RemoveWhitespace();
        // Output: "HelloWorld"
    }
}
```