---
title: Shuffle<T>()
---

## Description
Shuffles the collection randomly.

### Method Signature

```csharp
IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var numbers = Enumerable.Range(1, 5);
        var shuffled = numbers.Shuffle();
        // Example output: 3, 1, 5, 2, 4
    }
}
```