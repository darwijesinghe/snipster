---
title: RandomItem<T>()
---

## Description
Returns a random element from a collection.

### Method Signature

```csharp
T RandomItem<T>(this IEnumerable<T> source)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var colors = new[] { "Red", "Green", "Blue" };
        var randomColor = colors.RandomItem();
        // randomColor -> "Green" (varies)
    }
}
```