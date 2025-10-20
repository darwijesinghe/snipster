using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the ObjectValEx class.
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
        /// Tests the IsDefaultValue method to ensure it returns true for reference types that are null.
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
        /// Tests the IsDefaultValue method to ensure it returns true for default value types.
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
        /// Tests the IsDefaultValue method to ensure it returns false for non-default value types.
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
        /// Tests the IsDefaultValue method to ensure it returns true for value types that are null.
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
        /// Tests the IsDefaultValue method to ensure it returns false for nullable value types that are non-default.
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
        /// Tests the IsDefaultValue method to ensure it returns true for default structs.
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
        /// Tests the IsDefaultValue method to ensure it returns false for non-default structs.
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
        /// Tests the HasProperty method to ensure it returns true when the property exists.
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
        /// Tests the HasProperty method to ensure it returns false when case differs.
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
        /// Tests the HasProperty method to ensure it returns false when the property does not exist.
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
        /// Tests the HasProperty method to ensure it throws an ArgumentNullException when the object is null.
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
        /// Tests the HasProperty method to ensure it throws an ArgumentException when the property name is null.
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
        /// Tests the HasProperty method to ensure it throws an ArgumentException when the property name is empty.
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
    }
}
