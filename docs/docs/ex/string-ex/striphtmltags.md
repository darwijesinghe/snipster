---
title: StripHtmlTags()
---

## Description
Removes `HTML` tags from the string.

### Method Signature

```csharp
string StripHtmlTags(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "<p>Hello <strong>world</strong> from me</p>".StripHtmlTags();
        // Output: "Hello world from me"
    }
}
```