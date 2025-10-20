---
title: GenerateGuid()
---

## Description
Generates a new GUID as a string.

### Method Signature

```csharp
string GenerateGuid(bool includeDashes)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Generate a new GUID without dashes
        string guid = StringFx.GenerateGuid(includeDashes: false);

        Console.WriteLine(guid);  // Example: "a3f1b9e88a6b41dca3d4b1f26dfc9f42"
        Console.WriteLine(guid.Length);  // 32

        // Generate a new GUID with standard dash separators
        string guid = StringFx.GenerateGuid(includeDashes: true);

        Console.WriteLine(guid);  // Example: "a3f1b9e8-8a6b-41dc-a3d4-b1f26dfc9f42"
        Console.WriteLine(guid.Length);  // 36
    }
}
```