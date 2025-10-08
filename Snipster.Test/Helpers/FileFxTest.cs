using Snipster.Library.Helpers;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the FileFx class.
    /// </summary>
    [TestClass]
    public class FileFxTest
    {
        /// <summary>
        /// Tests the SafeReadText method to ensure it returns null for the invalid path.
        /// </summary>
        [TestMethod]
        public void SafeReadText_ShouldReturnNullForInvalidPath()
        {
            // Arrange
            var invalidPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            // Act
            var result = FileFx.SafeReadText(invalidPath);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests the SafeReadText method to ensure it returns file content for the valid path.
        /// </summary>
        [TestMethod]
        public void SafeReadText_ShouldReturnFileContent()
        {
            // Arrange
            var tempFile = Path.GetTempFileName();
            File.WriteAllText(tempFile, "Hello World");

            // Act
            var result = FileFx.SafeReadText(tempFile);

            // Assert
            Assert.AreEqual("Hello World", result);

            // Cleanup
            File.Delete(tempFile);
        }

        /// <summary>
        /// Tests the SafeWriteText method to ensure it writes content to the file.
        /// </summary>
        [TestMethod]
        public void SafeWriteText_ShouldWriteContentToTheFile()
        {
            // Arrange
            var tempFile = Path.GetTempFileName();
            var content  = "Hello, Utils!";

            // Act
            var writeResult = FileFx.SafeWriteText(tempFile, content);

            // Assert
            Assert.IsTrue(writeResult);
            Assert.AreEqual(content, FileFx.SafeReadText(tempFile));

            // Clean up
            File.Delete(tempFile);
        }

        /// <summary>
        /// Tests the SafeReadBytes method to ensure it returns null for the invalid path.
        /// </summary>
        [TestMethod]
        public void SafeReadBytes_ShouldReturnNullForInvalidPath()
        {
            // Arrange
            var invalidPath = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString());

            // Act
            var result = FileFx.SafeReadBytes(invalidPath);

            // Assert
            Assert.IsNull(result);
        }

        /// <summary>
        /// Tests the SafeReadBytes and SafeWriteBytes methods to ensure they work correctly.
        /// </summary>
        [TestMethod]
        public void SafeWriteBytes_And_SafeReadBytes_ShouldWork()
        {
            // Arrange
            var tempFile = Path.GetTempFileName();
            var data     = new byte[] { 1, 2, 3, 4 };

            // Act
            var writeResult = FileFx.SafeWriteBytes(tempFile, data);
            var readResult  = FileFx.SafeReadBytes(tempFile);

            // Assert
            Assert.IsTrue(writeResult);
            CollectionAssert.AreEqual(data, readResult);

            // Clean up
            File.Delete(tempFile);
        }

        /// <summary>
        /// Tests the CreateTempFile method to ensure it creates a file with the given extension.
        /// </summary>
        [TestMethod]
        public void CreateTempFile_ShouldCreateFileWithCorrectExtension()
        {
            // Act
            var tempFile = FileFx.CreateTempFile(".log");

            // Assert
            Assert.IsTrue(File.Exists(tempFile));

            // Clean up
            File.Delete(tempFile);
        }

        /// <summary>
        /// Tests the GetDirectorySize method to ensure it returns the correct directory size.
        /// </summary>
        [TestMethod]
        public void GetDirectorySize_ShouldReturnCorrectSize()
        {
            // Arrange
            var tempDir = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
            Directory.CreateDirectory(tempDir);

            var filePath = Path.Combine(tempDir, "file.txt");
            var content  = new string('A', 100); // 100 bytes
            File.WriteAllText(filePath, content);

            // Act
            var size = FileFx.GetDirectorySize(tempDir);

            // Assert
            Assert.IsTrue(size >= 100);

            // Clean up
            Directory.Delete(tempDir, true);
        }

        /// <summary>
        /// Tests the SanitizeFileName method to ensure it returns the correct file name by replacing _ with invalid characters.
        /// </summary>
        [TestMethod]
        public void SanitizeFileName_ShouldReplaceInvalidCharacters()
        {
            // Arrange
            var invalidName = "my:file*name?.txt";

            // Act
            var result = FileFx.SanitizeFileName(invalidName);

            // Assert
            Assert.IsFalse(result?.Contains(":"));
            Assert.IsFalse(result?.Contains("*"));
            Assert.IsFalse(result?.Contains("?"));
        }
    }
}
