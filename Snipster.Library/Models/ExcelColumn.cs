using ClosedXML.Excel;
using Snipster.Library.Enums;
using System;

namespace Snipster.Library.Models
{
#nullable disable

    /// <summary>
    /// Defines the properties and formatting options for a column in an Excel export.
    /// </summary>
    public class ExcelColumn
    {
        /// <summary>
        /// Gets or sets the property name from the data source that this column represents.
        /// </summary>
        public string Name                     { get; set; }

        /// <summary>
        /// Gets or sets the header text to display for this column in the Excel sheet.
        /// </summary>
        public string HeaderText               { get; set; }

        /// <summary>
        /// Gets or sets the data type of the column (e.g., typeof(int), typeof(string), typeof(DateTime)).
        /// </summary>
        public Type DataType                   { get; set; }

        /// <summary>
        /// Gets or sets the width of the column in characters. If the <see cref="ExcelExportOptions.AutoFitColumns"/> option is enabled, this value may be overridden.
        /// </summary>
        public double Width                    { get; set; }

        /// <summary>
        /// Gets or sets the Excel format string to apply to the column (e.g., "#,##0.00" for numbers, "yyyy-MM-dd" for dates).
        /// </summary>
        public string Format                   { get; set; }

        /// <summary>
        /// Gets or sets the text to display for true boolean values. If null, defaults to "True".
        /// </summary>
        public string TrueText                 { get; set; }

        /// <summary>
        ///Gets or sets the text to display for false boolean values. If null, defaults to "False".
        /// </summary>
        public string FalseText                { get; set; }

        /// <summary>
        /// Alignment customization for column data cells.
        /// </summary>
        public ExcelAlignment? Alignment       { get; set; }

        /// <summary>
        /// Alignment customization for header cell.
        /// </summary>
        public ExcelAlignment? HeaderAlignment { get; set; }
    }
}
