---
title: ToSha256()
---

## Description
Generates a SHA256 hash from a string. Useful for creating unique identifiers or checksums.

### Method Signature

```csharp
string ToSha256(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string input = "Hello, World!";
        string hash  = input.ToSha256();

        Console.WriteLine(hash);
        // Output: dffd6021bb2bd5b0af676290809ec3a53191dd81c7f70a4b28688a362182986f
    }
}
```