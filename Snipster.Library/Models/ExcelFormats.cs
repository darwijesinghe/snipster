namespace Snipster.Library.Models
{
    /// <summary>
    /// Provides commonly used Excel number, date, and text format strings.
    /// Use these constants when defining <see cref="ExcelColumn.Format"/>.
    /// </summary>
    public static class ExcelFormats
    {
        // Number formats ----------------------

        /// <summary>
        /// Whole numbers with thousands separator (e.g., 1,234).
        /// </summary>
        public const string Integer   = "#,##0";

        /// <summary>
        /// Double with thousands separator and two decimals (e.g., 1,234.56).
        /// </summary>
        public const string Double    = "#,##0.00";

        /// <summary>
        /// Currency with symbol and two decimals (e.g., $1,234.56).
        /// </summary>
        public const string Currency  = "$#,##0.00";

        /// <summary>
        /// Percentage with two decimals (e.g., 12.34%).
        /// </summary>
        public const string Percent   = "0.00%";

        // Date formats ------------------------

        /// <summary>
        /// Short date format (e.g., 2025-09-20).
        /// </summary>
        public const string DateShort = "yyyy-MM-dd";

        /// <summary>
        /// Long date format (e.g., 20-Sep-2025).
        /// </summary>
        public const string DateLong  = "dddd, MMMM dd, yyyy";

        /// <summary>
        /// Date and time format (e.g., 2025-09-20 18:45).
        /// </summary>
        public const string DateTime  = "yyyy-MM-dd HH:mm";

        // Text formats ------------------------

        /// <summary>
        /// General format (default, no specific formatting).
        /// </summary>
        public const string General   = "General";

        /// <summary>
        /// Text format (treats content as text).
        /// </summary>
        public const string Text      = "@";
    }
}
