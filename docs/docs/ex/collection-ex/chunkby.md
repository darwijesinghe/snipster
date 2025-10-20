---
title: ChunkBy<T>()
---

## Description
Splits a collection into chunks of the specified size.

### Method Signature

```csharp
IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> source, int size)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var numbers = Enumerable.Range(1, 10);
        var chunks = numbers.ChunkBy(3);

        foreach (var chunk in chunks)
        {
            Console.WriteLine(string.Join(", ", chunk));
        }
        
        // Output:
        // 1, 2, 3
        // 4, 5, 6
        // 7, 8, 9
        // 10
    }
}
```