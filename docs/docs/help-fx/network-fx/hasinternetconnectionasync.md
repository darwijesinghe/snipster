---
title: HasInternetConnectionAsync()
---

## Description
Checks if the system has an active internet connection by sending a lightweight request to a reliable host (default: https://www.google.com).

### Method Signature

```csharp
Task<bool> HasInternetConnectionAsync(string testUrl = "http://www.google.com", int timeoutSeconds = 5)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    public static void Main()
    {
        bool online = await NetworkFx.HasInternetConnectionAsync();
        if (!online)
            Console.WriteLine("No internet connection detected.");
    }
}
```