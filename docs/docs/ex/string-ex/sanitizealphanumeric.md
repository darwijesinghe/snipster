---
title: SanitizeAlphanumeric()
---

## Description
Removes all `non-alphanumeric` characters from a string.

### Method Signature

```csharp
string SanitizeAlphanumeric(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello@123!".SanitizeAlphanumeric();
        // Output: "Hello123"
    }
}
```