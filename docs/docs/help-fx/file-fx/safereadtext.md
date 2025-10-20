---
title: SafeReadText()
---

## Description
Safely reads the content of a text file.

### Method Signature

```csharp
string? SafeReadText(string path, Encoding? encoding = null)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        string? content = FileFx.SafeReadText("C:\\temp\\notes.txt");
        if (content is not null)
            Console.WriteLine(content);
    }
}
```