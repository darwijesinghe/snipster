---
title: HasProperty()
---

## Description
Checks whether the given object has a property with the specified name.

### Method Signature

```csharp
bool HasProperty(this object obj, string propertyName)
```

### Examples

```csharp
using Snipster.Library.Extensions.Validations;

public class Example
{
    public static void Main()
    {
        // Person object
        var person = new Person { Name = "John", Age = 30, IsActive = true };

        // Property exists
        bool hasName = person.HasProperty("Name"); // True

        // Case-sensitive: "name" does not match "Name"
        bool hasNameLower = person.HasProperty("name"); // False

        // Property does not exist
        bool hasEmail = person.HasProperty("Email"); // False

        // Throws ArgumentNullException
        Person? nullPerson = null;
        bool invalidCheck = nullPerson!.HasProperty("Name"); // Exception

        // Throws ArgumentException (null or empty property name)
        person.HasProperty(null!); // Exception
        person.HasProperty("");    // Exception
    }
}
```