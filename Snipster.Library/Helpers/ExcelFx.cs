using ClosedXML.Excel;
using Snipster.Library.Enums;
using Snipster.Library.Extensions.Validations;
using Snipster.Library.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace Snipster.Library.Helpers
{
    /// <summary>
    /// A class that provides Excel files related utility functions.
    /// </summary>
    public static class ExcelFx
    {
        /// <summary>
        /// Exports a collection of data to an Excel file written to the provided memory stream, using the specified column definitions and export options.
        /// </summary>
        /// <param name="data">The collection of data to export.</param>
        /// <param name="columns">The list of column definitions specifying how to map and format the data.</param>
        /// <param name="filePath">The file path where the Excel file will be saved.</param>
        /// <param name="fileName">The name of the Excel file to create (e.g., "output.xlsx").</param>
        /// <param name="configureOptions">An optional action to configure additional export options.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the file path or file name is null or empty.
        /// </exception>
        /// <exception cref="DirectoryNotFoundException">
        /// Thrown if the specified directory does not exist.
        /// </exception>
        public static void WriteToExcel<T>(IEnumerable<T> data, List<ExcelColumn> columns, string filePath, string fileName,
            Action<ExcelExportOptions>? configureOptions = null)
        {
            if (string.IsNullOrWhiteSpace(filePath))
                throw new ArgumentException("Directory path cannot be null or empty.", nameof(filePath));

            if (string.IsNullOrWhiteSpace(fileName))
                throw new ArgumentException("File name cannot be null or empty.", nameof(fileName));

            if (!Directory.Exists(filePath))
                throw new DirectoryNotFoundException($"The directory '{filePath}' does not exist.");

            // write to memory stream first
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, configureOptions);

            // reset position before writing
            stream.Position = 0;

            // build safe path
            var fullPath = Path.Combine(filePath, fileName);

            // write to disk
            using (var file = new FileStream(fullPath, FileMode.Create, FileAccess.Write))
            {
                stream.CopyTo(file);
            }

#if DEBUG
            Console.WriteLine($"Excel file written: {fullPath}");
#endif
        }

        /// <summary>
        /// Exports a collection of data to an Excel file written to the provided memory stream, using the specified column definitions and export options.
        /// </summary>
        /// <param name="data">The collection of data to export.</param>
        /// <param name="columns">The list of column definitions specifying how to map and format the data.</param>
        /// <param name="stream">The memory stream to which the Excel file will be written.</param>
        /// <param name="configureOptions">An optional action to configure additional export options.</param>
        /// <exception cref="ArgumentException">
        /// Thrown if the <paramref name="columns"/> list is null or empty,
        /// if the <paramref name="data"/> collection is null or empty,
        /// or if a column definition cannot be matched to a property or if there is a type mismatch in the <paramref name="data"/>.
        /// </exception>
        /// <exception cref="ArgumentNullException">
        /// Thrown if the provided memory stream is null.
        /// </exception>
        public static void WriteToMemory<T>(IEnumerable<T> data, List<ExcelColumn> columns, MemoryStream stream, 
            Action<ExcelExportOptions>? configureOptions = null)
        {
            if (columns.IsNullOrEmpty())
                throw new ArgumentException("At least one column definition is required.", nameof(columns));

            if (data.IsNullOrEmpty())
                throw new ArgumentException("The data collection is null or empty.", nameof(data));

            if (stream == null)
                throw new ArgumentNullException(nameof(stream), "The output stream cannot be null.");

            var options = new ExcelExportOptions();
            configureOptions?.Invoke(options);

            using var workbook = new XLWorkbook();
            var worksheet      = workbook.Worksheets.Add(options.SheetName);

            // headers row
            for (int i = 0; i < columns.Count; i++)
            {
                var header = string.IsNullOrWhiteSpace(columns[i].HeaderText)
                    ? columns[i].Name
                    : columns[i].HeaderText;

                var cell   = worksheet.Cell(1, i + 1);
                cell.Value = header;

                // header styling
                cell.Style.Font.Bold            = true;
                cell.Style.Fill.BackgroundColor = XLColor.FromColor(options.HeaderBackground);

                ExcelAlignment? alignment = columns[i].HeaderAlignment;
                if (alignment.HasValue)
                    cell.Style.Alignment.Horizontal = (XLAlignmentHorizontalValues)alignment.Value;

                // set column width if specified
                double? width = columns[i].Width;
                if (width.HasValue)
                    worksheet.Column(i + 1).Width = width.Value;
            }

            // validate columns and data
            var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            var propertyMap = columns.Select(col =>
            {
                var prop = properties.FirstOrDefault(p => string.Equals(p.Name, col.Name, StringComparison.OrdinalIgnoreCase));
                if (prop == null)
                    throw new ArgumentException($"Property '{col.Name}' was not found on type {typeof(T).Name}.");

                if (prop.PropertyType != col.DataType)
                    throw new ArgumentException($"Property '{col.Name}' type mismatch. Expected {col.DataType.Name}, found {prop.PropertyType.Name}.");

                return prop;
            })
            .ToList();

            // data rows
            int rowIndex = 2;
            foreach (var item in data)
            {
                for (int col = 0; col < columns.Count; col++)
                {
                    var value = propertyMap[col].GetValue(item);
                    var cell  = worksheet.Cell(rowIndex, col + 1);

                    // handle boolean with custom true/false text
                    if (columns[col].DataType == typeof(bool) && value is bool b)
                    {
                        if (!string.IsNullOrEmpty(columns[col].TrueText) || !string.IsNullOrEmpty(columns[col].FalseText))
                            // apply custom boolean text
                            cell.Value = b ? (columns[col].TrueText ?? "True") : (columns[col].FalseText ?? "False");
                        else
                            // default Excel boolean
                            cell.Value = b;
                    }
                    else if (columns[col].DataType == typeof(DateTime) && value is DateTime dt)
                        cell.Value = dt;
                    else if (columns[col].DataType == typeof(double) && value is double dec)
                        cell.Value = dec;
                    else if (columns[col].DataType == typeof(int) && value is int i)
                        cell.Value = i;
                    else
                        // fallback to string
                        cell.Value = value?.ToString() ?? string.Empty;

                    // apply formatting
                    if (!string.IsNullOrWhiteSpace(columns[col].Format))
                        cell.Style.NumberFormat.Format = columns[col].Format;

                    // apply alignment if specified
                    ExcelAlignment? alignment = columns[col].Alignment;
                    if (alignment.HasValue)
                        cell.Style.Alignment.Horizontal = (XLAlignmentHorizontalValues)alignment.Value;

                    // alternate row color
                    if (options.AlternateRowColors && rowIndex % 2 == 0)
                        cell.Style.Fill.BackgroundColor = XLColor.FromColor(options.AlternateRowColor);
                }
                rowIndex++;
            }

            // global options
            if (options.AutoFitColumns)
                worksheet.Columns().AdjustToContents();

            if (options.FreezeHeader)
                worksheet.SheetView.FreezeRows(1);

            workbook.SaveAs(stream);

#if DEBUG
            Console.WriteLine($"Excel file written to the provided memory stream.");
#endif
        }
    }
}
