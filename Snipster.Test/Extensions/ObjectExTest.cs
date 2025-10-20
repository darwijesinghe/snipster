using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the ObjectEx class.
    /// </summary>
    [TestClass]
    public class ObjectExTest
    {
        // Test classes
        public class Address
        {
            public string City { get; set; } = string.Empty;
        }

        public enum Status 
        { 
            Active, 
            Inactive 
        }

        public class Person
        {
            public string Name       { get; set; } = string.Empty;
            public int Age           { get; set; }
            public Address? Address  { get; set; }
            public string? Nickname  { get; private set; } // read-only property
            public Status UserStatus { get; set; }

            public void SetNickname(string name) => Nickname = name;
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it throws an ArgumentNullException when the input object is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetPropertyValue_ShouldThrow_WhenObjectIsNull()
        {
            // Arrange
            object obj = null!;

            // Act
            _ = obj.GetPropertyValue("Name");
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it throws an ArgumentException when the property name is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetPropertyValue_ShouldThrow_WhenPropertyNameIsEmpty()
        {
            // Arrange
            var person = new Person();
            
            // Act
            _ = person.GetPropertyValue("");
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it returns value when the property exists.
        /// </summary>
        [TestMethod]
        public void GetPropertyValue_ShouldReturn_Value_WhenPropertyExists()
        {
            // Arrange
            var person = new Person { Name = "John" };
            
            // Act
            var value = person.GetPropertyValue("Name");

            // Assert
            Assert.AreEqual("John", value);
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it returns null for nullable properties.
        /// </summary>
        [TestMethod]
        public void GetPropertyValue_ShouldReturn_Null_ForNullableProperty()
        {
            // Arrange
            var person = new Person { Address = null };

            // Act
            var value = person.GetPropertyValue("Address");

            // Assert
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it throws an InvalidOperationException when the property does not exist.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetPropertyValue_ShouldReturn_Null_WhenPropertyDoesNotExist()
        {
            // Arrange
            var person = new Person { Name = "John" };
            
            // Act
            var value = person.GetPropertyValue("InvalidProp");
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it returns object instance for complex type properties.
        /// </summary>
        [TestMethod]
        public void GetPropertyValue_ShouldReturn_ObjectInstance_ForComplexType()
        {
            // Arrange
            var person = new Person { Address = new Address { City = "Colombo" } };
            
            // Act
            var value = person.GetPropertyValue("Address");

            // Assert
            Assert.IsNotNull(value);
            Assert.IsInstanceOfType(value, typeof(Address));
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it returns null when the complex type property is null.
        /// </summary>
        [TestMethod]
        public void GetPropertyValue_ShouldReturn_Null_WhenComplexPropertyIsNull()
        {
            // Arrange
            var person = new Person { Address = null };
            
            // Act
            var value = person.GetPropertyValue("Address");

            // Assert
            Assert.IsNull(value);
        }

        /// <summary>
        /// Tests the GetPropertyValue method to ensure it throws an InvalidOperationException when the property name case does not match.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void GetPropertyValue_ShouldBeCaseSensitive()
        {
            // Arrange
            var person = new Person { Name = "John" };
            
            // Act
            var value = person.GetPropertyValue("name"); // lowercase "n" — no match
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it throws an ArgumentNullException when the input object is null.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void SetPropertyValue_ShouldThrow_WhenObjectIsNull()
        {
            // Arrange
            object obj = null!;
            
            // Act
            obj.SetPropertyValue("Name", "John");
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it throws an ArgumentException when the property name is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void SetPropertyValue_ShouldThrow_WhenPropertyNameIsEmpty()
        {
            // Arrange
            var person = new Person();
            
            // Act
            person.SetPropertyValue("", "John");
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it throws an InvalidOperationException when the property does not exist.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetPropertyValue_ShouldThrow_WhenPropertyDoesNotExist()
        {
            // Arrange
            var person = new Person();
            
            // Act
            person.SetPropertyValue("InvalidProp", "X");
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it throws an InvalidOperationException when the property is read-only.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void SetPropertyValue_ShouldThrow_WhenPropertyIsReadOnly()
        {
            // Arrange
            var person = new Person();
            
            // Act
            person.SetPropertyValue("Nickname", "Sam");
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it sets the value when the property exists.
        /// </summary>
        [TestMethod]
        public void SetPropertyValue_ShouldSet_Value_WhenPropertyExists()
        {
            // Arrange
            var person = new Person();
            
            // Act
            person.SetPropertyValue("Name", "Jane");

            // Assert
            Assert.AreEqual("Jane", person.Name);
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it sets null for nullable properties.
        /// </summary>
        [TestMethod]
        public void SetPropertyValue_ShouldSet_Null_ForNullableProperty()
        {
            // Arrange
            var person = new Person { Address = new Address() };
            
            // Act
            person.SetPropertyValue("Address", null);

            // Assert
            Assert.IsNull(person.Address);
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it converts the type when possible.
        /// </summary>
        [TestMethod]
        public void SetPropertyValue_ShouldConvertType_WhenPossible()
        {
            // Arrange
            var person = new Person();
            
            // Act
            person.SetPropertyValue("Age", "42"); // string -> int

            // Assert
            Assert.AreEqual(42, person.Age);
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it sets complex type properties.
        /// </summary>
        [TestMethod]
        public void SetPropertyValue_ShouldSet_ComplexProperty()
        {
            // Arrange
            var person = new Person();
            var addr   = new Address { City = "Thanamalwila" };

            // Act
            person.SetPropertyValue("Address", addr);

            // Assert
            Assert.AreEqual("Thanamalwila", person.Address!.City);
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it sets enum properties from string values.
        /// </summary>
        [TestMethod]
        public void SetPropertyValue_ShouldSet_EnumProperty_FromStringValue()
        {
            // Arrange
            var person = new Person();

            // Act
            person.SetPropertyValue("UserStatus", "Active"); // string -> enum

            // Assert
            Assert.AreEqual(Status.Active, person.UserStatus);
        }

        /// <summary>
        /// Tests the SetPropertyValue method to ensure it sets enum properties from enum values.
        /// </summary>
        [TestMethod]
        public void SetPropertyValue_ShouldSet_EnumProperty_FromEnumValue()
        {
            // Arrange
            var person = new Person();

            // Act
            person.SetPropertyValue("UserStatus", Status.Inactive); // enum -> enum

            // Assert
            Assert.AreEqual(Status.Inactive, person.UserStatus);
        }
    }
}
