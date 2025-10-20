---
title: NormalizeSpaces()
---

## Description
Normalizes spaces — trims and replaces multiple spaces with a single space. e.g. "  Hello   World  " becomes "Hello World".

### Method Signature

```csharp
string NormalizeSpaces(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "  Hello   World  ".NormalizeSpaces();
        // Output: "Hello World"
    }
}
```