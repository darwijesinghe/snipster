using Snipster.Library.Extensions.Validations;

namespace Snipster.Test.Extensions.Validations
{
    /// <summary>
    /// Unit tests to validate the functionality of the DateTimeValEx class.
    /// </summary>
    [TestClass]
    public class DateTimeValExTest
    {
        /// <summary>
        /// Test IsToday method to ensure it correctly identifies today's date.
        /// </summary>
        [TestMethod]
        public void IsToday_ShouldIdentifyTodayDate()
        {
            // Arrange
            var today = DateTime.Today;

            // Act
            bool isTodayResult = today.IsToday();

            // Assert
            Assert.AreEqual(today, DateTime.Today);
            Assert.IsTrue(isTodayResult);
        }

        /// <summary>
        /// Test IsFuture method to ensure it correctly identifies future dates.
        /// </summary>
        [TestMethod]
        public void IsFuture_ShouldIdentifyFutureDates()
        {
            // Arrange
            var futureDate = DateTime.Now.AddDays(1);

            // Act
            bool isFutureResult = futureDate.IsFuture();

            // Assert
            Assert.AreEqual(futureDate > DateTime.Now, true);
            Assert.IsTrue(isFutureResult);
        }

        /// <summary>
        /// Test IsPast method to ensure it correctly identifies past dates.
        /// </summary>
        [TestMethod]
        public void IsPast_ShouldIdentifyPastDates()
        {
            // Arrange
            var pastDate = DateTime.Now.AddDays(-1);

            // Act
            bool isPastResult = pastDate.IsPast();

            // Assert
            Assert.AreEqual(pastDate < DateTime.Now, true);
            Assert.IsTrue(isPastResult);
        }

        /// <summary>
        /// Test IsWeekend method to ensure it correctly identifies weekend dates.
        /// </summary>
        [TestMethod]
        public void IsWeekend_ShouldIdentifyWeekendDates()
        {
            // Arrange
            var weekendDate = new DateTime(2023, 10, 7); // Saturday

            // Act
            bool isWeekendResult = weekendDate.IsWeekend();

            // Assert
            Assert.AreEqual(weekendDate.DayOfWeek, DayOfWeek.Saturday);
            Assert.IsTrue(isWeekendResult);
        }

        /// <summary>
        /// Test IsWeekday method to ensure it correctly identifies weekday dates.
        /// </summary>
        [TestMethod]
        public void IsWeekday_ShouldIdentifyWeekdayDates()
        {
            // Arrange
            var weekdayDate = new DateTime(2023, 10, 9); // Monday

            // Act
            bool isWeekendResult = weekdayDate.IsWeekend();

            // Assert
            Assert.AreEqual(weekdayDate.DayOfWeek, DayOfWeek.Monday);
            Assert.IsFalse(isWeekendResult);
        }

        /// <summary>
        /// Test IsValidDate method to ensure it correctly identifies valid and invalid date formats.
        /// </summary>
        [TestMethod]
        public void IsValidDate_ShouldIdentifyValidAndInvalidDateFormats()
        {
            // Arrange
            string validDate = "2023-10-01";
            string invalidDate = "2023-13-01";

            // Act
            bool isValidDateResult = validDate.IsValidDate();
            bool isInvalidDateResult = invalidDate.IsValidDate();

            // Assert
            Assert.IsTrue(isValidDateResult);
            Assert.IsFalse(isInvalidDateResult);
        }
    }
}
