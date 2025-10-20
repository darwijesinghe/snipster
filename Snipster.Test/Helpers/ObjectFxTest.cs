using Snipster.Library.Helpers;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the ObjectFx class.
    /// </summary>
    [TestClass]
    public class ObjectFxTest
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

        /// <summary>
        /// Tests the DeepClone method to ensure it throws an ArgumentNullException when the input object is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeepClone_ShouldThrow_WhenObjectIsNull()
        {
            // Arrange
            Person? person = null;

            // Act
            var clone = person.DeepClone();
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it correctly clones a simple object.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldClone_SimpleObject()
        {
            // Arrange
            var person = new Person { Name = "John", Age = 30 };

            // Act
            var clone = person.DeepClone();

            // Assert
            Assert.AreNotSame(person, clone);
            Assert.AreEqual(person.Name, clone.Name);
            Assert.AreEqual(person.Age, clone.Age);
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it correctly clones a nested object.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldClone_NestedObject()
        {
            // Arrange
            var person = new Person
            {
                Name    = "Jane",
                Age     = 25,
                Address = new Address { City = "Colombo", Country = "Sri Lanka" }
            };

            // Act
            var clone = person.DeepClone();

            // Assert
            Assert.AreNotSame(person, clone);
            Assert.AreNotSame(person.Address, clone.Address);
            Assert.AreEqual(person.Address.City, clone.Address.City);
            Assert.AreEqual(person.Address.Country, clone.Address.Country);
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it correctly clones a collection of objects.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldClone_Collections()
        {
            // Arrange
            var list = new List<Person>
            {
                new Person { Name = "A", Age = 20 },
                new Person { Name = "B", Age = 30 }
            };

            // Act
            var clone = list.DeepClone();

            // Assert
            Assert.AreNotSame(list, clone);
            Assert.AreEqual(list.Count, clone.Count);
            Assert.AreEqual(list[0].Name, clone[0].Name);
            Assert.AreNotSame(list[0], clone[0]);
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it correctly clones and preserves derived types.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldPreserve_DerivedType()
        {
            // Arrange
            Person employee = new Employee
            {
                Name       = "Sam",
                Age        = 40,
                Department = "IT",
                Address    = new Address { City = "Kandy", Country = "Sri Lanka" }
            };

            // Act
            var clone = employee.DeepClone();

            // Assert
            Assert.IsInstanceOfType(clone, typeof(Employee));
            var empClone = (Employee)clone;
            Assert.AreEqual("IT", empClone.Department);
            Assert.AreEqual("Kandy", empClone.Address.City);
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it throws an InvalidOperationException when a circular reference is encountered.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DeepClone_ShouldThrow_OnCircularReference()
        {
            // Arrange
            var circular  = new Circular();
            circular.Self = circular;

            // Act
            var clone = circular.DeepClone(); // Should throw due to ReferenceLoopHandling.Error
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it correctly handles an empty object.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldHandle_EmptyObject()
        {
            // Arrange
            var address = new Address();

            // Act
            var clone = address.DeepClone();

            // Assert
            Assert.AreNotSame(address, clone);
            Assert.IsTrue(string.IsNullOrEmpty(clone.City));
            Assert.IsTrue(string.IsNullOrEmpty(clone.Country));
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it clones anonymous objects correctly.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldClone_AnonymousObject()
        {
            // Arrange
            var anon = new { Name = "Anonymous", Age = 99 };

            // Act
            var clone = anon.DeepClone();

            // Assert
            Assert.AreEqual(anon.Name, clone.Name);
            Assert.AreEqual(anon.Age, clone.Age);
            Assert.AreNotSame(anon, clone);
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it clones nullable value types correctly.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldClone_NullableValues()
        {
            // Arrange
            int? number = 123;

            // Act
            var clone = number.DeepClone();

            // Assert
            Assert.AreEqual(number, clone);
        }

        /// <summary>
        /// Tests the DeepClone method to ensure it clones value types correctly.
        /// </summary>
        [TestMethod]
        public void DeepClone_ShouldClone_ValueType()
        {
            // Arrange
            var point = new KeyValuePair<int, string>(10, "X");

            // Act
            var clone = point.DeepClone();

            // Assert
            Assert.AreEqual(point.Key, clone.Key);
            Assert.AreEqual(point.Value, clone.Value);
        }
    }
}
