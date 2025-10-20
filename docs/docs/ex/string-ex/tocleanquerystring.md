---
title: ToCleanQueryString()
---

## Description
Cleans a SQL query string by removing any zero-width characters and BOM.

### Method Signature

```csharp
string ToCleanQueryString(this string sql)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    public static void Main()
    {
        // SQL query with BOM at the start
        "\uFEFFSELECT * FROM Customers WHERE Id = 1".ToCleanQueryString();
        // Output: "SELECT * FROM Customers WHERE Id = 1"
    }
}
```