---
title: BuildUrl()
---

## Description
Builds a URL with query parameters from a base URL and a dictionary of parameters. Supports both single values and collections as parameter values.

### Method Signature

```csharp
string BuildUrl(string baseUrl, Dictionary<string, object?> parameters)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // 1. Basic Usage
        var url = NetworkFx.BuildUrl(
            "https://www.google.com/search",
            new Dictionary<string, object?>
            {
                ["q"] = "books",
                ["page"] = 2
            }
        );

        // Result: https://www.google.com/search?q=books&page=2

        // 2. List Parameters
        var url = NetworkFx.BuildUrl(
            "https://www.google.com/search",
            new Dictionary<string, object?>
            {
                ["tags"] = new[] { "csharp", "dotnet", "helpers" }
            }
        );

        // Result: https://www.google.com/search?tags=csharp&tags=dotnet&tags=helpers

        // 3. Special Characters
        var url = NetworkFx.BuildUrl(
            "https://www.google.com/search",
            new Dictionary<string, object?>
            {
                ["q"] = "C# helpers & utils"
            }
        );

        // Result: https://www.google.com/search?q=C%23+helpers+%26+utils
    }
}
```