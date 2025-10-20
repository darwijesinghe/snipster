---
title: HasDuplicates<T>()
---

## Description
Returns true if the collection contains any duplicates.

### Method Signature

```csharp
bool HasDuplicates<T>(this IEnumerable<T> source)
```
### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // Example 1: Collection with duplicates
        var fruits = new List<string> { "apple", "banana", "apple", "orange" };
        bool result1 = fruits.HasDuplicates(); 
        // True - "apple" appears more than once

        // Example 2: Collection without duplicates
        var numbers = new List<int> { 1, 2, 3, 4, 5 };
        bool result2 = numbers.HasDuplicates(); 
        // False - all elements are unique

        // Example 3: Empty or null collection
        var emptyList = new List<string>();
        bool result3 = emptyList.HasDuplicates(); 
        // False - no duplicates in an empty collection
    }
}
```