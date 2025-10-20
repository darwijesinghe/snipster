---
title: GetDirectorySize()
---

## Description
Calculates the total size of a directory, including all its subdirectories and files.

### Method Signature

```csharp
long GetDirectorySize(string path)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        long size = FileFx.GetDirectorySize("C:\\Projects\\MyApp");
        Console.WriteLine($"Directory size: {size} bytes.");
    }
}
```