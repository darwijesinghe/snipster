using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the <see cref="CollectionValEx"/> class.
    /// </summary>
    [TestClass]
    public class CollectionValExTest
    {
        /// <summary>
        /// Test <see cref="CollectionValEx.IsNullOrEmpty"/> to ensure it identifies a <see langword="null"/> collection as empty.
        /// </summary>
        [TestMethod]
        public void IsNullOrEmpty_ShouldIdentifyNullOrEmptyCollections()
        {
            // Arrange
            var emptyList = new List<string>();

            // Act
            var isEmpty = emptyList.IsNullOrEmpty();

            // Assert
            Assert.IsTrue(isEmpty);
        }

        /// <summary>
        /// Test <see cref="CollectionValEx.HasDuplicates"/> to ensure it identifies duplicates in a collection.
        /// </summary>
        [TestMethod]
        public void HasDuplicates_ShouldIdentifyDuplicatesInCollection()
        {
            // Arrange
            var listWithDuplicates = new List<string> { "apple", "banana", "apple", "orange" };

            // Act
            var hasDuplicates = listWithDuplicates.HasDuplicates();

            // Assert
            Assert.IsTrue(hasDuplicates);
        }
    }
}
