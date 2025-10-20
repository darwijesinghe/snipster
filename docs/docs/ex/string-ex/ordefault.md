---
title: OrDefault()
---

## Description
Returns a default value if string is null or empty.

### Method Signature

```csharp
string? OrDefault(this string? input, string defaultValue)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string? input = null;
        input.OrDefault("Default Value");
        // Output: "Default Value"
    }
}
```