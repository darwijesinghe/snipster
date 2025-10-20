---
title: ToJson()
---

## Description
Serializes the specified object to a JSON string.

### Method Signature

```csharp
string ToJson(this object obj, Formatting formatting = Formatting.None)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var obj = new { Name = "Test", Value = 123 };

        string json = obj.ToJson();
        // Output: {"Name":"Test","Value":123}
    }
}
```