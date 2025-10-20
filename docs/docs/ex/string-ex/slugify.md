---
title: Slugify()
---

## Description
Slugifies a string (e.g. "Hello World!" -> "hello-world").

### Method Signature

```csharp
string Slugify(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello world from me".Slugify();
        // Output: "hello-world-from-me"
    }
}
```