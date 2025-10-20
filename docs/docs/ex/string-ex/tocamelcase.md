---
title: ToCamelCase()
---

## Description
Converts a string to CamelCase format. e.g. "hello world" becomes "helloWorld".

### Method Signature

```csharp
string ToCamelCase(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "hello world".ToCamelCase();
        // Output: "helloWorld"
    }
}
```