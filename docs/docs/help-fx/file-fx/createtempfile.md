---
title: CreateTempFile()
---

## Description
Creates a temporary file with a unique name in the system's temporary directory.

### Method Signature

```csharp
string? CreateTempFile(string extension = ".tmp")
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        string tempLog = FileFx.CreateTempFile(".log");
        Console.WriteLine($"Temp file: {tempLog}");
    }
}
```