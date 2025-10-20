---
title: ToBase64()
---

## Description
Converts a string to Base64.

### Method Signature

```csharp
string ToBase64(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello world from me".ToBase64();
        // Output: "SGVsbG8gd29ybGQgZnJvbSBtZQ=="
    }
}
```