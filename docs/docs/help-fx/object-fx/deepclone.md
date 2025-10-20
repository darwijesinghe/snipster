---
title: DeepClone<T>()
---

## Description
Creates a deep clone of the specified object using json serialization. Supports `reference types`, `collections`, `anonymous types`, and `value types`.

### Method Signature

```csharp
T DeepClone<T>(this T obj)
```
### Examples

```csharp
using Snipster.Library.Helpers;

public class Example
{
    // Test classes
    public class Address
    {
        public string City    { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }

    public class Person
    {
        public string Name     { get; set; } = string.Empty;
        public int Age         { get; set; }
        public Address Address { get; set; } = new Address();
    }

    public class Employee : Person
    {
        public string Department { get; set; } = string.Empty;
    }

    public class Circular
    {
        public Circular? Self { get; set; }
    }

    public static void Main()
    {
        // 1. Clone Simple Object
        var person = new Person { Name = "John", Age = 30 };
        var clone  = person.DeepClone();

        Console.WriteLine(clone.Name); // John
        Console.WriteLine(ReferenceEquals(person, clone)); // False

        // 2. Clone Nested Object
        var person = new Person
        {
            Name = "Jane",
            Age = 25,
            Address = new Address { City = "Colombo", Country = "Sri Lanka" }
        };

        var clone = person.DeepClone();

        Console.WriteLine(clone.Address.City); // Colombo
        Console.WriteLine(ReferenceEquals(person.Address, clone.Address)); // False

        // 3. Clone Collection
        var list = new List<Person>
        {
            new Person { Name = "A", Age = 20 },
            new Person { Name = "B", Age = 30 }
        };

        var clone = list.DeepClone();

        Console.WriteLine(clone[0].Name); // A
        Console.WriteLine(ReferenceEquals(list[0], clone[0])); // False

        // 4. Preserve Derived Types
        Person employee = new Employee
        {
            Name       = "Sam",
            Age        = 40,
            Department = "IT",
            Address    = new Address { City = "Kandy", Country = "Sri Lanka" }
        };

        var clone = employee.DeepClone();

        Console.WriteLine(clone is Employee); // True
        Console.WriteLine(((Employee)clone).Department); // IT

        // 5. Handle Circular References
        var circular = new Circular();
        circular.Self = circular;

        // Throws InvalidOperationException
        var clone = circular.DeepClone();

        // 6. Clone Anonymous Objects
        var anon  = new { Name = "Anonymous", Age = 99 };
        var clone = anon.DeepClone();

        Console.WriteLine(clone.Name); // Anonymous

        // 7. Clone Value and Nullable Types
        int? number = 123;
        var clone = number.DeepClone(); // 123

        // 8. Clone a KeyValuePair (struct with value and reference types)
        var point = new KeyValuePair<int, string>(10, "X");
        var clonedPoint = point.DeepClone();

        Console.WriteLine($"Cloned: [{clonedPoint.Key}, {clonedPoint.Value}]");
        // Output: Cloned: [10, X]
    }
}
```