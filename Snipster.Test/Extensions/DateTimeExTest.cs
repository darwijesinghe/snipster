using Snipster.Library.Extensions;

namespace Snipster.Test.Extensions
{
    /// <summary>
    /// Unit tests to validate the functionality of the DateTimeEx class.
    /// </summary>
    [TestClass]
    public class DateTimeExTest
    {
        /// <summary>
        /// Tests the ToUnixTimestamp method to ensure it converts DateTime to Unix timestamp correctly.
        /// </summary>
        [TestMethod]
        public void ToUnixTimestamp_ShouldReturnCorrectUnixTimestamp()
        {
            // Arrange
            var date     = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            var expected = 1609459200;

            // Act
            var actual = date.ToUnixTimestamp();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the FromUnixTimestamp method to ensure it converts Unix timestamp to DateTime correctly.
        /// </summary>
        [TestMethod]
        public void FromUnixTimestamp_ShouldReturnCorrectDateTime()
        {
            // Arrange
            long timestamp = 1609459200;
            var expected   = new DateTime(2021, 1, 1, 0, 0, 0, DateTimeKind.Utc);

            // Act
            var actual = timestamp.FromUnixTimestamp();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the ToTimeAgo method to ensure it returns the correct time ago string.
        /// </summary>
        [TestMethod]
        public void ToTimeAgo_ShouldReturnCorrectTimeAgoString()
        {
            // Arrange
            var date     = DateTime.UtcNow.AddHours(-3);
            var expected = "3 hours ago";

            // Act
            var actual = date.ToTimeAgo();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the StartOfDay method to ensure it returns the start of the day for a given DateTime.
        /// </summary>
        [TestMethod]
        public void StartOfDay_ShouldReturnStartOfDay()
        {
            // Arrange
            var date     = new DateTime(2023, 10, 1, 15, 30, 45);
            var expected = new DateTime(2023, 10, 1, 0, 0, 0);

            // Act
            var actual = date.StartOfDay();
                
            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the EndOfDay method to ensure it returns the end of the day for a given DateTime.
        /// </summary>
        [TestMethod]
        public void EndOfDay_ShouldReturnEndOfDay()
        {
            // Arrange
            var date     = new DateTime(2023, 10, 1, 15, 30, 45);
            var expected = new DateTime(2023, 10, 1, 23, 59, 59, 999);

            // Act
            var actual = date.EndOfDay();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the ToTimeZone method to ensure it converts a DateTime to a specific time zone correctly.
        /// </summary>
        [TestMethod]
        public void ToTimeZone_ShouldConvertToSpecificTimeZone()
        {
            // Arrange
            var date       = new DateTime(2023, 10, 1, 12, 0, 0, DateTimeKind.Utc);
            var timeZoneId = "Pacific Standard Time";
            var expected   = TimeZoneInfo.ConvertTimeFromUtc(date, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));

            // Act
            var actual = date.ToTimeZone(timeZoneId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the FromTimeZone method to ensure it converts a specific time zone to UTC correctly.
        /// </summary>
        [TestMethod]
        public void FromTimeZone_ShouldConvertToCorrectUTC()
        {
            // Arrange
            var date       = new DateTime(2023, 10, 1, 12, 0, 0, DateTimeKind.Unspecified);
            var timeZoneId = "Pacific Standard Time";
            var expected   = TimeZoneInfo.ConvertTimeToUtc(date, TimeZoneInfo.FindSystemTimeZoneById(timeZoneId));

            // Act
            var actual = date.FromTimeZone(timeZoneId);

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the ToDateString method to ensure it formats a DateTime to a date string correctly.
        /// </summary>
        [TestMethod]
        public void ToDateString_ShouldFormatDateCorrectly()
        {
            // Arrange
            var date     = new DateTime(2023, 10, 1);
            var expected = "2023-10-01";

            // Act
            var actual = date.ToDateString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the ToTimeString method to ensure it formats a DateTime to a time string correctly.
        /// </summary>
        [TestMethod]
        public void ToTimeString_ShouldFormatTimeCorrectly()
        {
            // Arrange
            var date     = new DateTime(2023, 10, 1, 15, 30, 45);
            var expected = "15:30:45";

            // Act
            var actual = date.ToTimeString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the ToFullDateTimeString method to ensure it formats a DateTime to a full date and time string correctly.
        /// </summary>
        [TestMethod]
        public void ToFullDateTimeString_ShouldFormatDateTimeCorrectly()
        {
            // Arrange
            var date     = new DateTime(2023, 10, 1, 15, 30, 45);
            var expected = "2023-10-01 15:30:45";

            // Act
            var actual = date.ToFullDateTimeString();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the GetWeekStartDate method to ensure it returns the correct start date of the week for a given date.
        /// </summary>
        [TestMethod]
        public void GetWeekStartDate_ShouldReturnCorrectWeekStartDate()
        {
            // Arrange
            var date     = new DateTime(2023, 1, 4); // Wednesday, which is the middle of the week
            var expected = new DateTime(2023, 1, 2); // Monday, the start of the week

            // Act
            var actual = date.GetWeekStartDate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the GetWeekEndDate method to ensure it returns the correct end date of the week for a given date.
        /// </summary>
        [TestMethod]
        public void GetWeekEndDate_ShouldReturnCorrectWeekEndDate()
        {
            // Arrange
            var date     = new DateTime(2025, 7, 30); // Wednesday
            var expected = new DateTime(2025, 8, 3, 23, 59, 59, 999).AddTicks(9999); // Sunday 23:59:59.9999999

            // Act
            var actual = date.GetWeekEndDate();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the GetWeekOfYear method to ensure it returns the correct week number for a given date.
        /// </summary>
        [TestMethod]
        public void GetWeekOfYear_ShouldReturnCorrectWeekNumber()
        {
            // Arrange
            var date     = new DateTime(2023, 1, 4); // ISO week 1  
            var expected = 1;

            // Act
            var actual = date.GetWeekOfYear();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        /// <summary>
        /// Tests the ToAge method to ensure it calculates the correct age from a birth date.
        /// </summary>
        [TestMethod]
        public void ToAge_ShouldReturnCorrectAge()
        {
            // Arrange
            var birthDate = new DateTime(1990, 1, 1);
            var expected  = DateTime.Today.Year - birthDate.Year - (birthDate.Date > DateTime.Today.AddYears(-(DateTime.Today.Year - birthDate.Year)) ? 1 : 0);

            // Act
            var actual = birthDate.ToAge();

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
