using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the CollectionEx class.
    /// </summary>
    [TestClass]
    public class CollectionExTest
    {
        /// <summary>
        /// Tests the ChunkBy method to ensure it splits a collection into chunks of specified size.
        /// </summary>
        [TestMethod]
        public void ChunkBy_ShouldSplitCollectionIntoChunks()
        {
            // Arrange
            var source = Enumerable.Range(1, 10);

            // Act
            var result = source.ChunkBy(3).ToList();

            // Assert
            Assert.AreEqual(4, result.Count);
            Assert.IsTrue(result[0].SequenceEqual(new[] { 1, 2, 3 }));
            Assert.IsTrue(result[3].SequenceEqual(new[] { 10 }));
        }

        /// <summary>
        /// Tests the ToSafeDictionary method to ensure it creates a dictionary from a collection, skipping duplicate keys.
        /// </summary>
        [TestMethod]
        public void ToSafeDictionary_ShouldSkipDuplicateKeys()
        {
            // Arrange
            var source = new[]
            {
                new { Key = 1, Value = "A" },
                new { Key = 2, Value = "B" },
                new { Key = 1, Value = "C" }
            };

            // Act
            var result = source.ToSafeDictionary(x => x.Key, x => x.Value);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("A", result[1]);
            Assert.AreEqual("B", result[2]);
        }

        /// <summary>
        /// Tests the ForEach method to ensure it executes an action for each element in the collection.
        /// </summary>
        [TestMethod]
        public void ForEach_ShouldExecuteActionForEachElement()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var sum    = 0;

            // Act
            source.ForEach(x => sum += x);

            // Assert
            Assert.AreEqual(6, sum);
        }

        /// <summary>
        /// Tests the RandomItem method to ensure it returns a random element from the collection.
        /// </summary>
        [TestMethod]
        public void RandomItem_ShouldReturnRandomElement()
        {
            // Arrange
            var source = new[] { 1, 2, 3, 4, 5 };

            // Act
            var result = source.RandomItem();

            // Assert
            Assert.IsTrue(source.Contains(result));
        }

        /// <summary>
        /// Tests the MostCommon method to ensure it returns the most frequently occurring element in the collection.
        /// </summary>
        [TestMethod]
        public void MostCommon_ShouldReturnMostFrequentElement()
        {
            // Arrange
            var source = new[] { 1, 2, 2, 3, 3, 3 };

            // Act
            var result = source.MostCommon();

            // Assert
            Assert.AreEqual(3, result);
        }

        /// <summary>
        /// Tests the LeastCommon method to ensure it returns the least frequently occurring element in the collection.
        /// </summary>
        [TestMethod]
        public void LeastCommon_ShouldReturnLeastFrequentElement()
        {
            // Arrange
            var source = new[] { 1, 2, 2, 3, 3, 3 };

            // Act
            var result = source.LeastCommon();

            // Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Tests the ExceptSafe method to ensure it returns elements that are only in the first collection.
        /// </summary>
        [TestMethod]
        public void ExceptSafe_ShouldReturnElementsOnlyInFirstCollection()
        {
            // Arrange
            var source = new[] { 1, 2, 3 };
            var other  = new[] { 2, 3, 4 };

            // Act
            var result = source.ExceptSafe(other).ToList();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0]);
        }

        /// <summary>
        /// Tests the Shuffle method to ensure it returns the collection in random order.
        /// </summary>
        [TestMethod]
        public void Shuffle_ShouldReturnCollectionInRandomOrder()
        {
            // Arrange
            var source = Enumerable.Range(1, 10).ToList();

            // Act
            var result = source.Shuffle().ToList();

            // Assert
            Assert.AreEqual(source.Count, result.Count);
            Assert.IsTrue(source.All(result.Contains));
        }
    }
}
