---
title: ToAge()
---

## Description
Returns the age based on date of birth. e.g. if born on 1990-01-01 and today is 2023-10-01, returns 33.

### Method Signature

```csharp
int ToAge(this DateTime birthDate)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        var birthDate = new DateTime(1990, 1, 1);
        int age = birthDate.ToAge();
        // age -> e.g. 35 (depending on current date)
    }
}
```