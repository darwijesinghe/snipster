---
title: Minify()
---

## Description
Minifies a `Json` string (removes all whitespace and newlines).

### Method Signature

```csharp
string Minify(string json)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        string json = "{ \"name\": \"John\", \"age\": 30, \"city\": \"New York\" }";

        string minified = JsonFx.Minify(json);
        // Result: {"name":"John","age":30,"city":"New York"}
    }
}
```