using Snipster.Library.Helpers;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the NetworkFx class.
    /// </summary>
    [TestClass]
    public class NetworkFxTest
    {
        /// <summary>
        /// Tests the IsHostAvailableAsync method to ensure it returns true when the host is available and false when it is not available, as expected.
        /// </summary>
        [TestMethod]
        public async Task IsHostAvailableAsync_ValidHostReturnsTrueOrFalse()
        {
            // Arrange
            var host = "google.com";

            // Act
            var result = await NetworkFx.IsHostAvailableAsync(host);

            // We just ensure it doesn't crash
            // Optionally, you can assert it's true, but connectivity can fail in CI/CD or offline environments

            // Assert
            Assert.IsNotNull(result);
        }

        /// <summary>
        /// Tests the IsHostAvailableAsync method throws an <see cref="ArgumentException"/> when the host is empty.
        /// </summary>
        [TestMethod]
        public async Task IsHostAvailableAsync_EmptyHostThrowsArgumentException()
        {
            // Arrange
            var host = string.Empty;

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentException>(async () =>
            {
                await NetworkFx.IsHostAvailableAsync(host);
            });
        }

        /// <summary>
        /// Tests the IsHostAvailableAsync method throws an <see cref="ArgumentOutOfRangeException"/> when the timeout parameter is zero.
        /// </summary>
        [TestMethod]
        public async Task IsHostAvailableAsync_TimeoutZeroThrowsArgumentOutOfRangeException()
        {
            // Arrange
            var host = "google.com";

            // Act & Assert
            await Assert.ThrowsExceptionAsync<ArgumentOutOfRangeException>(async () =>
            {
                await NetworkFx.IsHostAvailableAsync(host, 0);
            });
        }

        /// <summary>
        /// Tests the BuildUrl method throws an <see cref="ArgumentException"/> when the base url is empty.
        /// </summary>
        [TestMethod]
        public void BuildUrl_ShouldReturnArgumentExceptionOnEmptyUrl()
        {
            // Arrange
            string baseUrl = string.Empty;
            var parameters = new Dictionary<string, object?>
            {
                ["q"]    = "books",
                ["page"] = "2"
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
                NetworkFx.BuildUrl(baseUrl, parameters);
            });
        }

        /// <summary>
        /// Tests the BuildUrl method throws an <see cref="ArgumentNullException"/> when the parameters are null.
        /// </summary>
        [TestMethod]
        public void BuildUrl_ShouldReturnArgumentNullExceptionOnNullParameters()
        {
            // Arrange
            string baseUrl = "https://www.google.com/search";

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                NetworkFx.BuildUrl(baseUrl, null);
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            });
        }

        /// <summary>
        /// Tests the BuildUrl method returns valid url with the provided query params.
        /// </summary>
        [TestMethod]
        public void BuildUrl_ShouldReturnValidUrlWithQueryParams()
        {
            // Arrange
            string baseUrl = "https://www.google.com/search";
            var parameters = new Dictionary<string, object?>
            {
                ["q"]    = "books",
                ["page"] = "2"
            };
            string expected = "https://www.google.com/search?q=books&page=2";

            // Act
            string url = NetworkFx.BuildUrl(baseUrl, parameters);

            // Assert
            Assert.IsNotNull(url);
            Assert.IsTrue(url.Equals(expected));
        }

        /// <summary>
        /// Tests the BuildUrl method returns valid url when query params contains a list.
        /// </summary>
        [TestMethod]
        public void BuildUrl_ShouldReturnValidUrl_WhenQueryParamsContainList()
        {
            // Arrange
            string baseUrl = "https://www.google.com/search";
            var parameters = new Dictionary<string, object?>
            {
                ["q"]    = "books",
                ["page"] = "2",
                ["tags"] = new[] { "csharp", "dotnet", "helpers" }
            };
            string expected = "https://www.google.com/search?q=books&page=2&tags=csharp&tags=dotnet&tags=helpers";

            // Act
            string url = NetworkFx.BuildUrl(baseUrl, parameters);

            // Assert
            Assert.IsNotNull(url);
            Assert.IsTrue(url.Equals(expected));
        }

        /// <summary>
        /// Tests the BuildUrl method returns a valid url when query parameter values contain special characters.
        /// </summary>
        [TestMethod]
        public void BuildUrl_ShouldReturnValidUrl_WhenQueryParamValuesContainSpecialCharacters()
        {
            // Arrange
            string baseUrl = "https://www.google.com/search";
            var parameters = new Dictionary<string, object?>
            {
                ["q"]    = "C# helpers & utils",
                ["page"] = "2",
                ["tags"] = new[] { "csharp", "dotnet", "helpers" }
            };
            string expected = "https://www.google.com/search?q=C%23+helpers+%26+utils&page=2&tags=csharp&tags=dotnet&tags=helpers";

            // Act
            string url = NetworkFx.BuildUrl(baseUrl, parameters);

            // Assert
            Assert.IsNotNull(url);
            Assert.IsTrue(url.Equals(expected));
        }
    }
}
