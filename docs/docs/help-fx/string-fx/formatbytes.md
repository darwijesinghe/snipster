---
title: FormatBytes()
---

## Description
Formats a byte size into a human-readable string (e.g. "1.5 MB", "200 KB").

### Method Signature

```csharp
string FormatBytes(long bytes, int decimals = 2)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        // Convert bytes into a human-readable string with 2 decimal places
        long bytes = 1_500_000;

        string result = StringFx.FormatBytes(bytes, 2);
        Console.WriteLine(result);  // Output: "1.43 MB"

        // Negative byte values are handled as well
        string negative = StringFx.FormatBytes(-bytes, 2);
        Console.WriteLine(negative);  // Output: "-1.43 MB"
    }
}
```