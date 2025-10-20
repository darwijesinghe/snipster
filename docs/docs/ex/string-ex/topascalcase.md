---
title: ToPascalCase()
---

## Description
Converts a string to PascalCase. e.g. "hello world" becomes "HelloWorld".

### Method Signature

```csharp
string ToPascalCase(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "hello world".ToPascalCase();
        // Output: "HelloWorld"
    }
}
```