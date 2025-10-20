---
title: IsDefaultValue<T>()
---

## Description
Determines whether the specified object is equal to its type's default value.

### Method Signature

```csharp
bool IsDefaultValue<T>(this T obj)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // True (null reference)
        string? name = null;
        bool isDefault1 = name.IsDefaultValue();

        // True (default int)
        int age = 0;
        bool isDefault2 = age.IsDefaultValue();

        // False (non-default)
        int age2 = 25;
        bool isDefault3 = age2.IsDefaultValue();

        // True
        int? nullableNum = null;
        bool isDefault4 = nullableNum.IsDefaultValue();

        // True (default DateTime)
        DateTime date = default;
        bool isDefault5 = date.IsDefaultValue();

        // False (non-default struct)
        DateTime now = DateTime.Now;
        bool isDefault6 = now.IsDefaultValue();
    }
}
```