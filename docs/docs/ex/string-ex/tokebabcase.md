---
title: ToKebabCase()
---

## Description
Converts a string to kebab-case. e.g. "Hello World" becomes "hello-world".

### Method Signature

```csharp
string ToKebabCase(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello World".ToKebabCase();
        // Output: "hello-world"
    }
}
```