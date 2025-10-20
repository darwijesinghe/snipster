---
title: ExceptSafe<T>()
---

## Description
Compares two collections and returns elements only in the first.

### Method Signature

```csharp
IEnumerable<T> ExceptSafe<T>(this IEnumerable<T> source, IEnumerable<T> other)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var first = new[] { 1, 2, 3 };
        var second = new[] { 2, 3, 4 };

        var result = first.ExceptSafe(second);
        // result -> [1]
    }
}
```