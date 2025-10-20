---
title: RemoveSpecialCharacters()
---

## Description
Removes all special characters except spaces.

### Method Signature

```csharp
string RemoveSpecialCharacters(this string input)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        "Hello@123! World".RemoveSpecialCharacters();
        // Output: "Hello123 World"
    }
}
```