---
title: SanitizeFileName()
---

## Description
Sanitizes a file name by replacing all invalid file name characters with a specified replacement string (default is underscore).

### Method Signature

```csharp
string? SanitizeFileName(string fileName, string replacement = "_")
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        string safe = FileFx.SanitizeFileName("my:file*name?.txt");
        // Result: "my_file_name_.txt"
    }
}
```