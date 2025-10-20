---
title: LeastCommon<T>()
---

## Description
Returns the least frequent item in the collection.

### Method Signature

```csharp
T LeastCommon<T>(this IEnumerable<T> source)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 2, 3, 3, 3 };
        var result = numbers.LeastCommon();
        // result -> 1
    }
}
```