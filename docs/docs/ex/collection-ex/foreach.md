---
title: ForEach<T>()
---

## Description
Executes an action for each element in the collection.

### Method Signature

```csharp
void ForEach<T>(this IEnumerable<T> source, Action<T> action)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var numbers = new[] { 1, 2, 3 };
        numbers.ForEach(n => Console.WriteLine(n * 2));
        // Output: 2, 4, 6
    }
}
```