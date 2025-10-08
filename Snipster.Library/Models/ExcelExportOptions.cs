using ClosedXML.Excel;
using System.Drawing;

namespace Snipster.Library.Models
{
    /// <summary>
    /// Defines options for exporting data to an Excel file, including formatting and layout preferences.
    /// </summary>
    public class ExcelExportOptions
    {
        /// <summary>
        /// Gets or sets a value indicating whether to automatically adjust column widths to fit content.
        /// </summary>
        public bool AutoFitColumns     { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to freeze the header row, keeping it visible during scrolling.
        /// </summary>
        public bool FreezeHeader       { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether to apply alternating row colors for better readability.
        /// </summary>
        public bool AlternateRowColors { get; set; }

        /// <summary>
        /// Gets or sets the background color for the header row.
        /// </summary>
        public Color HeaderBackground  { get; set; }

        /// <summary>
        /// Gets or sets the color used for alternating rows when <see cref="AlternateRowColors"/> is true.
        /// </summary>
        public Color AlternateRowColor { get; set; }

        /// <summary>
        /// Gets or sets the name of the worksheet within the Excel file.
        /// </summary>
        public string SheetName        { get; set; } = "Sheet1";
    }
}
