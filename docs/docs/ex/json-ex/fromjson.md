---
title: FromJson<T>()
---

## Description
De-serializes a JSON string to an object of type T.

### Method Signature

```csharp
T? FromJson<T>(this string json)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        string json = "{\"Name\":\"Test\",\"Value\":123}";

        var obj = json.FromJson<TestObject>();
        // obj.Name -> "Test"
        // obj.Value -> 123

        string invalidJson = "{InvalidJson}";

        var obj = invalidJson.FromJson<dynamic>();
        // Output: null
    }
}
```