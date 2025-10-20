---
title: SafeWriteText()
---

## Description
Safely writes text content to a file, creating the file if it does not exist or overwriting it if it does.

### Method Signature

```csharp
bool SafeWriteText(string path, string content, Encoding? encoding = null)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        bool ok = FileFx.SafeWriteText("C:\\temp\\output.txt", "Hello, Utils!");
        if (ok)
            Console.WriteLine("File saved successfully.");
    }
}
```