using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the <see cref="ObjectValEx"/> class.
    /// </summary>
    [TestClass]
    public class ObjectValExTest
    {
        // Test classes
        private class Person
        {
            public string? Name  { get; set; }
            public int Age       { get; set; }
            public bool IsActive { get; set; }
        }

        /// <summary>
        /// Provides anonymous objects used in dynamic data-driven tests.
        /// </summary>
        public static IEnumerable<object[]> AnonymousObjects()
        {
            yield return new object[] { new { Id = 1, Name = "Alice" } };
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="true"/> for reference types that are <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnTrue_ForNullReferenceType()
        {
            // Arrange
            string? text = null;
            
            // Act & Assert
            Assert.IsTrue(text.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="true"/> for default value types.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnTrue_ForDefaultValueType()
        {
            // Arrange
            int num = default;
            
            // Act & Assert
            Assert.IsTrue(num.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="false"/> for non-default value types.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnFalse_ForNonDefaultValueType()
        {
            // Arrange
            int num = 10;

            // Act & Assert
            Assert.IsFalse(num.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="true"/> for value types that are <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnTrue_ForNullableDefault()
        {
            // Arrange
            int? num = null;
            
            // Act & Assert
            Assert.IsTrue(num.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="false"/> for nullable value types that are non-default.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnFalse_ForNullableNonDefault()
        {
            // Arrange
            int? num = 5;

            // Act & Assert
            Assert.IsFalse(num.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="true"/> for default structs.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnTrue_ForDefaultStruct()
        {
            // Arrange
            DateTime date = default;

            // Act & Assert
            Assert.IsTrue(date.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.IsDefaultValue"/> method to ensure it returns <see langword="false"/> for non-default structs.
        /// </summary>
        [TestMethod]
        public void IsDefaultValue_ShouldReturnFalse_ForNonDefaultStruct()
        {
            // Arrange
            DateTime date = DateTime.Now;

            // Act & Assert
            Assert.IsFalse(date.IsDefaultValue());
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.HasProperty"/> method to ensure it returns <see langword="true"/> when the property exists.
        /// </summary>
        [TestMethod]
        public void HasProperty_ShouldReturnTrue_WhenPropertyExists()
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.IsTrue(person.HasProperty("Name"));
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.HasProperty"/> method to ensure it returns <see langword="false"/> when case differs.
        /// </summary>
        [TestMethod]
        public void HasProperty_ShouldReturnFalse_WhenCaseDiffers()
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.IsFalse(person.HasProperty("name"));
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.HasProperty"/> method to ensure it returns <see langword="false"/> when the property does not exist.
        /// </summary>
        [TestMethod]
        public void HasProperty_ShouldReturnFalse_WhenPropertyDoesNotExist()
        {
            // Arrange
            var person = new Person();

            // Act & Assert
            Assert.IsFalse(person.HasProperty("Email"));
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.HasProperty"/> method to ensure it throws an <see cref="ArgumentNullException"/> when the object is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void HasProperty_ShouldThrow_WhenObjectIsNull()
        {
            // Arrange
            Person? person = null;

            // Act
            person!.HasProperty("Name");
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.HasProperty"/> method to ensure it throws an <see cref="ArgumentException"/> when the property name is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HasProperty_ShouldThrow_WhenPropertyNameIsNull()
        {
            // Arrange
            var person = new Person();

            // Act
            person.HasProperty(null!);
        }

        /// <summary>
        /// Tests the <see cref="ObjectValEx.HasProperty"/> method to ensure it throws an <see cref="ArgumentException"/> when the property name is empty.
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void HasProperty_ShouldThrow_WhenPropertyNameIsEmpty()
        {
            // Arrange
            var person = new Person();

            // Act
            person.HasProperty("");
        }

        /// <summary>
        /// Tests that <see cref="ObjectValEx.HasProperty"/> returns false when the property does not exist on an anonymous object.
        /// </summary>
        [DataTestMethod]
        [DynamicData(nameof(AnonymousObjects), DynamicDataSourceType.Method)]
        public void HasProperty_ShouldReturnFalse_WhenPropertyDoesNotExist(object obj)
        {
            // Act
            var result = obj.HasProperty("Age"); // property does not exist

            // Assert
            Assert.IsFalse(result);
        }

        /// <summary>
        /// Tests <see cref="ObjectValEx.HasProperty"/> with an anonymous object and validates empty property name.
        /// </summary>
        [DataTestMethod]
        [DynamicData(nameof(AnonymousObjects), DynamicDataSourceType.Method)]
        public void HasProperty_ShouldThrowArgumentException_ForAnonymousObject(object obj)
        {
            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                obj.HasProperty("");
            });
        }
    }
}