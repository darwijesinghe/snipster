---
title: GetDescription()
---

## Description
Retrieves the value of the <see cref="DescriptionAttribute"/> applied to an enum value. If no description is found, it returns the enum's name as a fallback.

### Method Signature

```csharp
string GetDescription(this Enum value)
```
### Examples

```csharp
// Test enum class
public enum Status
{
    [Description("Operation successful")]
    Success,
    Pending
}

using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        Status.Success.GetDescription(); // "Operation successful"
        Status.Pending.GetDescription(); // "Pending"
    }
}
```