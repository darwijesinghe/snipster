---
title: IsHostAvailableAsync()
---

## Description
Checks if a host is available by sending a ping request.

### Method Signature

```csharp
Task<bool> IsHostAvailableAsync(string host, int timeout = 1000)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        bool reachable = await NetworkFx.IsHostAvailableAsync("google.com", 2000);
        Console.WriteLine(reachable ? "Host reachable" : "Host unreachable");
    }
}
```