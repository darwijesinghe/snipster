---
title: Prettify()
---

## Description
Prettifies a `Json` string (adds indentation and newlines for readability).

### Method Signature

```csharp
string Prettify(string json)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        string json = "{\"name\":\"John\",\"age\":30,\"city\":\"New York\"}";

        string pretty = JsonFx.Prettify(json);
        /*
        Result:
        {
            "name": "John",
            "age": 30,
            "city": "New York"
        }
        */
    }
}
```