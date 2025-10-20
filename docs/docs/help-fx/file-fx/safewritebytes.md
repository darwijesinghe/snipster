---
title: SafeWriteBytes()
---

## Description
Safely writes a byte array to a file, creating the file if it does not exist or overwriting it if it does.

### Method Signature

```csharp
bool SafeWriteBytes(string path, byte[] data)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        var data = new byte[] { 1, 2, 3, 4 };
        bool success = FileFx.SafeWriteBytes("C:\\temp\\data.bin", data);
        if (success)
            Console.WriteLine("Bytes written successfully to C:\\temp\\data.bin.");
    }
}
```