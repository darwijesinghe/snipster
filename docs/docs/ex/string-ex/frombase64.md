---
title: FromBase64()
---

## Description
Decodes a Base64-encoded string.

### Method Signature

```csharp
string FromBase64(this string base64)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "SGVsbG8gd29ybGQgZnJvbSBtZQ==".FromBase64();
        // Output: "Hello world from me"
    }
}
```