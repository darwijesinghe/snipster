---
title: GetPropertyValue()
---

## Description
Gets the value of a public instance property by name.

### Method Signature

```csharp
object? GetPropertyValue(this object obj, string propertyName)
```
### Examples

```csharp
using Snipster.Library.Extensions;

public class Example
{
    // Test classes
    public class Person
    {
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
        public string? Nickname { get; } = "ReadOnly";
        public Address? Address { get; set; }
        public Status UserStatus { get; set; }
    }

    public class Address
    {
        public string City { get; set; } = string.Empty;
    }

    public enum Status
    {
        Active,
        Inactive
    }

    public static void Main()
    {
        // 1. Throws when object is null
        object obj = null!;
        _ = obj.GetPropertyValue("Name"); 
        // Throws ArgumentNullException

        // 2. Throws when property name is empty
        var person = new Person();
        _ = person.GetPropertyValue("");
        // Throws ArgumentException

        // 3. Returns property value
        var person = new Person { Name = "John" };
        var value = person.GetPropertyValue("Name"); 
        // Output: "John"

        // 4. Returns null for nullable property
        var person = new Person { Address = null };
        var value = person.GetPropertyValue("Address"); 
        // Output: null

        // 5. Throws when property doesn’t exist
        var person = new Person { Name = "John" };
        _ = person.GetPropertyValue("InvalidProp");
        // Throws InvalidOperationException

        // 6 .Returns object instance for complex type
        var person = new Person { Address = new Address { City = "Colombo" } };
        var value = person.GetPropertyValue("Address"); 
        // Output: Address { City = "Colombo" }

        // 7. Returns null for null complex property
        var person = new Person { Address = null };
        var value = person.GetPropertyValue("Address");
        // Output: null

        // 8. Case sensitivity check
        var person = new Person { Name = "John" };
        _ = person.GetPropertyValue("name"); 
        // Throws InvalidOperationException — property names are case-sensitive
    }
}
```