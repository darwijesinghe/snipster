---
title: IsNullOrEmpty<T>()
---

## Description
Returns true if the collection is null or has no elements.

### Method Signature

```csharp
bool IsNullOrEmpty<T>(this IEnumerable<T> source)
```
### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // Example 1: Empty list
        var emptyList = new List<string>();
        bool result1 = emptyList.IsNullOrEmpty(); 
        // True - because the list is empty

        // Example 2: Null collection
        List<int>? nullList = null;
        bool result2 = nullList.IsNullOrEmpty(); 
        // True - because the collection is null

        // Example 3: Non-empty list
        var numbers = new List<int> { 1, 2, 3 };
        bool result3 = numbers.IsNullOrEmpty(); 
        // False - because the list contains items
    }
}
```