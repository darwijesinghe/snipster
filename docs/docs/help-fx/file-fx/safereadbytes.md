---
title: SafeReadBytes()
---

## Description
Safely reads the content of a binary file as a byte array.

### Method Signature

```csharp
byte[]? SafeReadBytes(string path)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        byte[]? bytes = FileFx.SafeReadBytes("C:\\temp\\data.bin");
        if (bytes != null)
            Console.WriteLine($"File size: {bytes.Length} bytes.");
    }
}
```