---
title: ToSafeDictionary<TSource, TKey, TValue>()
---

## Description
Returns a dictionary from a list safely and skips duplicate keys.

### Method Signature

```csharp
Dictionary<TKey, TValue> ToSafeDictionary<TSource, TKey, TValue>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector, Func<TSource, TValue> valueSelector) where TKey : notnull
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var items = new[]
        {
            new { Key = 1, Value = "A" },
            new { Key = 2, Value = "B" },
            new { Key = 1, Value = "C" } // duplicate key
        };

        var dict = items.ToSafeDictionary(x => x.Key, x => x.Value);
        // Result: { 1: "A", 2: "B" }
    }
}
```