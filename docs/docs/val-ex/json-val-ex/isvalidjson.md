---
title: IsValidJson()
---

## Description
Validates if a string is a valid JSON format. Supports validation for `objects ({})`, `arrays ([])`, and `nested structures`.

### Method Signature

```csharp
bool IsValidJson(this string json)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // Example 1: Valid JSON object
        string validJson = @"{""name"":""John"", ""age"":30, ""city"":""New York""}";
        Console.WriteLine(validJson.IsValidJson()); // True

        // Example 2: Invalid JSON (missing quotes around keys)
        string invalidJson = @"{name:""John"", age:30, city:""New York""}";
        Console.WriteLine(invalidJson.IsValidJson()); // False

        // Example 3: JSON array
        string jsonArray = @"[""apple"", ""banana"", ""cherry""]";
        Console.WriteLine(jsonArray.IsValidJson()); // True

        // Example 4: Nested JSON object with array
        string nestedJson = @"{""name"":""John"", ""age"":30, ""cars"": [""Ford"", ""BMW"", ""Fiat""]}";
        Console.WriteLine(nestedJson.IsValidJson()); // True
    }
}
```