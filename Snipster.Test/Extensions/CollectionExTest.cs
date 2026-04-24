using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the <see cref="CollectionEx"/> class.
    /// </summary>
    [TestClass]
    public class CollectionExTest
    {
        /// <summary>
        /// Represents a sample item used in collection tests.
        /// </summary>
        public class TestItem
        {
            /// <summary>
            /// Gets or sets the item identifier.
            /// </summary>
            public int Id       { get; set; }
            /// <summary>
            /// Gets or sets the item value.
            /// </summary>
            public string Value { get; set; } = string.Empty;
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ChunkBy"/> method to ensure it splits a sequence
        /// into the expected number of chunks based on the provided chunk size.
        /// </summary>
        [DataTestMethod]
        [DataRow(5, 2, 3)]
        [DataRow(10, 3, 4)]
        [DataRow(4, 4, 1)]
        [DataRow(3, 5, 1)]
        [DataRow(0, 3, 0)]
        public void ChunkBy_Should_Split_Into_Expected_Number_Of_Chunks(int totalItems, int chunkSize, int expectedChunkCount)
        {
            // Arrange
            var source = Enumerable.Range(1, totalItems);

            // Act
            var result = source.ChunkBy(chunkSize).ToList();

            // Assert
            Assert.AreEqual(expectedChunkCount, result.Count);

            if (totalItems > 0)
            {
                // Ensure chunk sizes are correct
                for (int i = 0; i < result.Count - 1; i++)
                    Assert.AreEqual(chunkSize, result[i].Count());

                // Last chunk can be smaller
                Assert.IsTrue(result.Last().Count() <= chunkSize);
            }
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ChunkBy"/> method to ensure it preserves the original ordering of elements across all generated chunks.
        /// </summary>
        [DataTestMethod]
        [DataRow(6, 2)]
        [DataRow(7, 3)]
        public void ChunkBy_ShouldPreserveOrder(int totalItems, int chunkSize)
        {
            // Arrange
            var source = Enumerable.Range(1, totalItems).ToList();

            // Act
            var chunks = source.ChunkBy(chunkSize).ToList();

            // Assert
            var flattened = chunks.SelectMany(x => x).ToList();
            CollectionAssert.AreEqual(source, flattened);
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ChunkBy"/> method to ensure it throws an <see cref="ArgumentNullException"/> when the source sequence is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ChunkBy_ShouldThrow_WhenSourceIsNull()
        {
            IEnumerable<int> source = null!;

            Assert.ThrowsException<ArgumentNullException>(() =>
                source.ChunkBy(2).ToList());
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ChunkBy"/> method to ensure it throws throws an <see cref="ArgumentOutOfRangeException"/> when 
        /// the chunk size is zero or negative.
        /// </summary>
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(-1)]
        [DataRow(-5)]
        public void ChunkBy_ShouldThrow_WhenSizeIsInvalid(int size)
        {
            var source = new[] { 1, 2, 3 };

            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                source.ChunkBy(size).ToList());
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ToSafeDictionary"/> method to ensure it creates a dictionary with unique keys
        /// and ignores duplicate keys while preserving the first occurrence.
        /// </summary>
        [DataTestMethod]
        [DataRow(5)]
        [DataRow(10)]
        public void ToSafeDictionary_Should_Ignore_DuplicateKeys(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount)
                .Select(x => new TestItem { Id = x % 2, Value = $"Value{x}" });

            // Act
            var result = source.ToSafeDictionary(x => x.Id, x => x.Value);

            // Assert
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual("Value1", result[1]);
            Assert.AreEqual("Value2", result[0]);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ToSafeDictionary"/> returns an empty dictionary when the source sequence is empty.
        /// </summary>
        [DataTestMethod]
        [DataRow(0)]
        public void ToSafeDictionary_Should_Return_EmptyDictionary(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount)
                .Select(x => new TestItem { Id = x, Value = $"Value{x}" });

            // Act
            var result = source.ToSafeDictionary(x => x.Id, x => x.Value);

            // Assert
            Assert.AreEqual(0, result.Count);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ToSafeDictionary"/> correctly maps keys and values using the provided selector functions.
        /// </summary>
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(7)]
        public void ToSafeDictionary_Should_Map_KeysAndValuesCorrectly(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount)
                .Select(x => new TestItem { Id = x, Value = $"Item{x}" });

            // Act
            var result = source.ToSafeDictionary(x => x.Id, x => x.Value);

            // Assert
            Assert.AreEqual(itemCount, result.Count);

            foreach (var item in source)
            {
                Assert.AreEqual(item.Value, result[item.Id]);
            }
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ToSafeDictionary"/> throws <see cref="ArgumentNullException"/> when the source sequence is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ToSafeDictionary_ShouldThrow_WhenSourceIsNull()
        {
            // Arrange
            IEnumerable<TestItem> source = null!;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                source.ToSafeDictionary(x => x.Id, x => x.Value));
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ToSafeDictionary"/> throws <see cref="ArgumentNullException"/> when the key selector function is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ToSafeDictionary_ShouldThrow_WhenKeySelectorIsNull()
        {
            // Arrange
            var source = new[] { new TestItem { Id = 1, Value = "A" } };
            Func<TestItem, int> keySelector = null!;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                source.ToSafeDictionary(keySelector, x => x.Value));
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ToSafeDictionary"/> throws <see cref="ArgumentNullException"/> when the value selector function is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ToSafeDictionary_ShouldThrow_WhenValueSelectorIsNull()
        {
            // Arrange
            var source = new[] { new TestItem { Id = 1, Value = "A" } };
            Func<TestItem, int> valueSelector = null!;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                source.ToSafeDictionary(x => x.Id, valueSelector));
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ForEach"/> method to ensure it executes the provided action for every element
        /// in the source sequence.
        /// </summary>
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void ForEach_ShouldInvokeActionForEachItem(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount);
            var executionCount = 0;

            // Act
            source.ForEach(_ => executionCount++);

            // Assert
            Assert.AreEqual(itemCount, executionCount);
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ForEach"/> method to ensure it processes elements in the original sequence order.
        /// </summary>
        [DataTestMethod]
        [DataRow(3)]
        [DataRow(7)]
        public void ForEach_ShouldPreserveIterationOrder(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount).ToList();
            var result = new List<int>();

            // Act
            source.ForEach(x => result.Add(x));

            // Assert
            CollectionAssert.AreEqual(source, result);
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ForEach"/> method to ensure it performs no action when the source sequence is empty.
        /// </summary>
        [DataTestMethod]
        [DataRow(0)]
        public void ForEach_ShouldNotInvokeAction_WhenSourceIsEmpty(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount);
            var executionCount = 0;

            // Act
            source.ForEach(_ => executionCount++);

            // Assert
            Assert.AreEqual(0, executionCount);
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ForEach"/> method to ensure it throws <see cref="ArgumentNullException"/> when the source is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ForEach_ShouldThrow_WhenSourceIsNull()
        {
            IEnumerable<int> source = null!;

            Assert.ThrowsException<ArgumentNullException>(() =>
                source.ForEach(_ => { }));
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.ForEach"/> method to ensure it <see cref="ArgumentNullException"/> when the action is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ForEach_ShouldThrow_WhenActionIsNull()
        {
            var source = new[] { 1, 2, 3 };
            Action<int> action = null!;

            Assert.ThrowsException<ArgumentNullException>(() =>
                source.ForEach(action));
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.RandomItem"/> method to ensure it returns a value contained within the source sequence.
        /// </summary>
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void RandomItem_ShouldReturn_Item_From_Source(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount).ToList();

            // Act
            var result = source.RandomItem();

            // Assert
            CollectionAssert.Contains(source, result);
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.RandomItem"/> method to ensure it returns the only element
        /// when the source contains a single item.
        /// </summary>
        [TestMethod]
        public void RandomItem_ShouldReturn_OnlyItem_WhenSingleElement()
        {
            // Arrange
            var source = new List<string> { "OnlyItem" };

            // Act
            var result = source.RandomItem();

            // Assert
            Assert.AreEqual("OnlyItem", result);
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.RandomItem"/> method to ensure it throws <see cref="ArgumentNullException"/> when the source is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void RandomItem_ShouldThrow_WhenSourceIsNull()
        {
            IEnumerable<int> source = null!;

            Assert.ThrowsException<ArgumentNullException>(() =>
                source.RandomItem());
        }

        /// <summary>
        /// Tests the <see cref="CollectionEx.RandomItem"/> method to ensure it throws <see cref="ArgumentOutOfRangeException"/>
        /// when the source sequence is empty.
        /// </summary>
        [TestMethod]
        public void RandomItem_ShouldThrow_WhenSourceIsEmpty()
        {
            // Arrange
            var source = new List<int>();

            // Act & Assert
            Assert.ThrowsException<ArgumentOutOfRangeException>(() =>
                source.RandomItem());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.MostCommon"/> returns the element that appears most frequently in the sequence.
        /// </summary>
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 2, 3 }, 2)]
        [DataRow(new[] { 5, 5, 5, 1, 2 }, 5)]
        [DataRow(new[] { 9, 8, 7, 7, 8, 7 }, 7)]
        public void MostCommon_ShouldReturn_MostFrequent_Element(int[] source, int expected)
        {
            // Act
            var result = source.MostCommon();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.MostCommon"/> returns the only element when the sequence contains a single value.
        /// </summary>
        [TestMethod]
        public void MostCommon_ShouldReturnSingleElement_WhenOnlyOneItem()
        {
            // Arrange
            var source = new[] { 42 };

            // Act
            var result = source.MostCommon();

            // Assert
            Assert.AreEqual(42, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.MostCommon"/> returns the first encountered element
        /// when multiple elements share the same highest frequency.
        /// </summary>
        [TestMethod]
        public void MostCommon_ShouldReturn_First_Encountered_WhenTieOccurs()
        {
            // Arrange
            var source = new[] { 1, 2, 1, 2 };

            // Act
            var result = source.MostCommon();

            // Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.MostCommon"/> throws <see cref="ArgumentNullException"/> when the source is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void MostCommon_ShouldThrow_WhenSourceIsNull()
        {
            // Arrange
            IEnumerable<int> source = null!;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                source.MostCommon());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.MostCommon"/> throws <see cref="InvalidOperationException"/> when the source sequence is empty.
        /// </summary>
        [TestMethod]
        public void MostCommon_ShouldThrow_WhenSourceIsEmpty()
        {
            // Arrange
            var source = Array.Empty<int>();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
                source.MostCommon());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.LeastCommon"/> returns the element that appears least frequently in the sequence.
        /// </summary>
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 2, 3 }, 1)]
        [DataRow(new[] { 5, 5, 5, 1, 2 }, 1)]
        [DataRow(new[] { 9, 8, 7, 7, 8, 7 }, 9)]
        public void LeastCommon_ShouldReturn_Least_FrequentElement(int[] source, int expected)
        {
            // Act
            var result = source.LeastCommon();

            // Assert
            Assert.AreEqual(expected, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.LeastCommon"/> returns the only element when the sequence contains a single value.
        /// </summary>
        [TestMethod]
        public void LeastCommon_ShouldReturn_SingleElement_WhenOnlyOneItem()
        {
            // Arrange
            var source = new[] { 42 };

            // Act
            var result = source.LeastCommon();

            // Assert
            Assert.AreEqual(42, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.LeastCommon"/> returns the first encountered element
        /// when multiple elements share the same lowest frequency.
        /// </summary>
        [TestMethod]
        public void LeastCommon_ShouldReturn_FirstEncountered_WhenTieOccurs()
        {
            // Arrange
            var source = new[] { 1, 2, 1, 2, 3, 3 };

            // All appear twice — first encountered should win

            // Act
            var result = source.LeastCommon();

            // Assert
            Assert.AreEqual(1, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.LeastCommon"/> throws <see cref="ArgumentNullException"/> when the source is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void LeastCommon_ShouldThrow_WhenSourceIsNull()
        {
            // Arrange
            IEnumerable<int> source = null!;

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
                source.LeastCommon());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.LeastCommon"/> throws <see cref="InvalidOperationException"/> when the source sequence is empty.
        /// </summary>
        [TestMethod]
        public void LeastCommon_ShouldThrow_WhenSourceIsEmpty()
        {
            // Arrange
            var source = Array.Empty<int>();

            // Act & Assert
            Assert.ThrowsException<InvalidOperationException>(() =>
                source.LeastCommon());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ExceptSafe"/> returns elements from the source that are not present in the other sequence.
        /// </summary>
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3 }, new[] { 2 }   , new[] { 1, 3 })]
        [DataRow(new[] { 5, 6, 7 }, new[] { 5, 7 }, new[] { 6 })]
        [DataRow(new[] { 1, 2 }   , new int[0]    , new[] { 1, 2 })]
        public void ExceptSafe_ShouldReturn_CorrectDifference(int[] source, int[] other, int[] expected)
        {
            // Act
            var result = source.ExceptSafe(other).ToArray();

            // Assert
            CollectionAssert.AreEquivalent(expected, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ExceptSafe"/> returns an empty sequence when the source is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ExceptSafe_ShouldReturn_Empty_When_SourceIsNull()
        {
            // Arrange
            IEnumerable<int> source = null!;
            var other               = new[] { 1, 2 };

            // Act
            var result = source.ExceptSafe(other);

            // Assert
            Assert.IsFalse(result.Any());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ExceptSafe"/> treats a <see langword="null"/> other sequence as an empty sequence.
        /// </summary>
        [DataTestMethod]
        [DataRow(new[] { 1, 2, 3 })]
        [DataRow(new[] { 5 })]
        public void ExceptSafe_ShouldReturn_Source_When_OtherIsNull(int[] source)
        {
            // Arrange
            IEnumerable<int> other = null!;

            // Act
            var result = source.ExceptSafe(other).ToArray();

            // Assert
            CollectionAssert.AreEquivalent(source, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.ExceptSafe"/> returns an empty sequence when both source and other are <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void ExceptSafe_ShouldReturnEmpty_WhenBothAreNull()
        {
            // Arrange
            IEnumerable<int> source = null!;
            IEnumerable<int> other  = null!;

            // Act
            var result = source.ExceptSafe(other);

            // Assert
            Assert.IsFalse(result.Any());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.Shuffle"/> returns a sequence containing the same elements as the source.
        /// </summary>
        [DataTestMethod]
        [DataRow(1)]
        [DataRow(5)]
        [DataRow(10)]
        public void Shuffle_Should_Contain_SameElements(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount).ToList();

            // Act
            var result = source.Shuffle().ToList();

            // Assert
            CollectionAssert.AreEquivalent(source, result);
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.Shuffle"/> preserves the total number of elements.
        /// </summary>
        [DataTestMethod]
        [DataRow(0)]
        [DataRow(3)]
        [DataRow(15)]
        public void Shuffle_Should_Preserve_ElementCount(int itemCount)
        {
            // Arrange
            var source = Enumerable.Range(1, itemCount);

            // Act
            var result = source.Shuffle();

            // Assert
            Assert.AreEqual(itemCount, result.Count());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.Shuffle"/> returns an empty sequence when the source is <see langword="null"/>.
        /// </summary>
        [TestMethod]
        public void Shuffle_Should_ReturnEmpty_When_SourceIsNull()
        {
            // Arrange
            IEnumerable<int> source = null!;

            // Act
            var result = source.Shuffle();

            // Assert
            Assert.IsFalse(result.Any());
        }

        /// <summary>
        /// Tests that <see cref="CollectionEx.Shuffle"/> returns an empty sequence when the source is empty.
        /// </summary>
        [TestMethod]
        public void Shuffle_Should_ReturnEmpty_When_SourceIsEmpty()
        {
            // Arrange
            var source = Array.Empty<int>();

            // Act
            var result = source.Shuffle();

            // Assert
            Assert.IsFalse(result.Any());
        }

        /// <summary>
        /// Tests that multiple enumerations of <see cref="CollectionEx.Shuffle"/> produce valid sequences
        /// containing all original elements.
        /// </summary>
        [TestMethod]
        public void Shuffle_Should_RemainValid_On_MultipleEnumerations()
        {
            // Arrange
            var source   = Enumerable.Range(1, 5).ToList();
            var shuffled = source.Shuffle();

            // Act
            var firstRun  = shuffled.ToList();
            var secondRun = shuffled.ToList();

            // Assert
            CollectionAssert.AreEquivalent(source, firstRun);
            CollectionAssert.AreEquivalent(source, secondRun);
        }
    }
}
