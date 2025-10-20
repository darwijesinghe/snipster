---
title: WriteToExcel<T>()
---

## Description
Exports a collection of data to an `Excel file` written to the provided memory stream, using the specified column definitions and export options.

### Method Signature

```csharp
void WriteToExcel<T>(IEnumerable<T> data, List<ExcelColumn> columns, string filePath, string fileName, Action<ExcelExportOptions>? configureOptions = null)
```
### Examples

```csharp
using Snipster.Library.Helpers;
using Snipster.Library.Enums;

public class Example
{
    // Test class
    public class TestObject
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int Value { get; set; }
        public int Age { get; set; }
        public bool IsMember { get; set; }
        public DateTime JoinDate { get; set; }
        public double Salary { get; set; }
        public double Commission { get; set; }
    }

    public static void Main()
    {
        // Test data list
        var data = new List<TestObject>
        {
            new TestObject { Id = 1, Name = "Darshana", Value = 1000, Age = 30, IsMember = true, JoinDate = new DateTime(2023, 01, 15), Salary = 5000.25, Commission = 0.075 },
            new TestObject { Id = 2, Name = "Nadeesha", Value = 2500, Age = 27, IsMember = false, JoinDate = new DateTime(2024, 06, 05), Salary = 7250.50, Commission = 0.10 }
        };

        // Column definitions
        var columns = new List<ExcelColumn>
        {
            new ExcelColumn { Name = "Id", DataType = typeof(int), HeaderText = "ID", Format = ExcelFormats.Integer, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "Name", DataType = typeof(string), HeaderText = "Full Name", Format = ExcelFormats.Text, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "Value", DataType = typeof(int), HeaderText = "Value", Format = ExcelFormats.Integer, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "Age", DataType = typeof(int), HeaderText = "Age", Format = ExcelFormats.Integer, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "IsMember", DataType = typeof(bool), HeaderText = "Membership", TrueText = "Yes", FalseText = "No", Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "JoinDate", DataType = typeof(DateTime), HeaderText = "Join Date", Format = ExcelFormats.DateTime, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "Salary", DataType = typeof(double), HeaderText = "Salary", Format = ExcelFormats.Currency, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
            new ExcelColumn { Name = "Commission", DataType = typeof(double), HeaderText = "Commission", Format = ExcelFormats.Percent, Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left }
        };

        // Export to disk
        ExcelFx.WriteToExcel(data, columns, "C:\\Exports", "Employees.xlsx", opts =>
        {
            opts.AutoFitColumns = false;
            opts.FreezeHeader = true;
            opts.AlternateRowColors = true;
            opts.HeaderBackground = Color.LightGray;
            opts.AlternateRowColor = Color.LightYellow;
            opts.SheetName = "Employee Report";
        });

        // Output: A formatted Excel file at C:\Exports\Employees.xlsx with 
        // frozen headers, header background colors, alternate row colors, and formatted columns.
    }
}
```