---
title: MostCommon<T>()
---

## Description
Returns the most frequent item in the collection.

### Method Signature

```csharp
T MostCommon<T>(this IEnumerable<T> source)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 2, 3, 3, 3 };
        var result = numbers.MostCommon();
        // result -> 3
    }
}
```