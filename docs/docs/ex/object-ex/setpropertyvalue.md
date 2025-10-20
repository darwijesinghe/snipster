---
title: SetPropertyValue()
---

## Description
Sets the value of a public instance property by name, if it exists and is writable.

### Method Signature

```csharp
void SetPropertyValue(this object obj, string propertyName, object? value)
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
        obj.SetPropertyValue("Name", "John");
        // Throws ArgumentNullException

        // 2. Throws when property name is empty
        var person = new Person();
        person.SetPropertyValue("", "John");
        // Throws ArgumentException

        // 3. Throws when property doesn’t exist
        var person = new Person();
        person.SetPropertyValue("InvalidProp", "X");
        // Throws InvalidOperationException

        // 4. Throws when property is read-only
        var person = new Person();
        person.SetPropertyValue("Nickname", "Sam");
        // Throws InvalidOperationException

        // 5. Sets value when property exists
        var person = new Person();
        person.SetPropertyValue("Name", "Jane");
        // person.Name == "Jane"

        // 6. Sets null for nullable property
        var person = new Person { Address = new Address() };
        person.SetPropertyValue("Address", null);
        // person.Address == null

        // 7. Converts type automatically
        var person = new Person();
        person.SetPropertyValue("Age", "42"); 
        // person.Age == 42

        // 8. Sets complex object property
        var person = new Person();
        var addr = new Address { City = "Thanamalwila" };
        person.SetPropertyValue("Address", addr);
        // person.Address.City == "Thanamalwila"

        // 9. Sets enum property from string
        var person = new Person();
        person.SetPropertyValue("UserStatus", "Active");
        // person.UserStatus == Status.Active

        // 10. Sets enum property from enum value
        var person = new Person();
        person.SetPropertyValue("UserStatus", Status.Inactive);
        // person.UserStatus == Status.Inactive
    }
}
```