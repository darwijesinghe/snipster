using ClosedXML.Excel;
using Snipster.Library.Enums;
using Snipster.Library.Helpers;
using Snipster.Library.Models;
using Snipster.Test.Models;
using System.Drawing;
using System.Globalization;

namespace Snipster.Test.Helpers
{
    /// <summary>
    /// Unit tests to validate the functionality of the ExcelFx class.
    /// </summary>
    [TestClass]
    public class ExcelFxTest
    {
        /// <summary>
        /// The name of the worksheet to be used in tests.
        /// </summary>
        private string _sheetName = string.Empty;

        /// <summary>
        /// The temporary file path used in tests.
        /// </summary>
        private string _tempFilePath = string.Empty;

        /// <summary>
        /// The temporary file name used in tests.
        /// </summary>
        private string _tempFileName = string.Empty;

        [TestInitialize]
        public void Setup()
        {
            _sheetName    = "TestSheet";
            _tempFilePath = Path.GetTempPath();
            _tempFileName = $"test-{Guid.NewGuid()}.xlsx";
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it creates a worksheet with the specified name.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldWorksheetExists()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the General format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyGeneralFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string), Format = ExcelFormats.General }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);


                var cell = ws.Cell(2, 1); // row 2, column 1 = Name
                Assert.AreEqual("John Doe", cell.GetValue<string>());
                Assert.AreEqual(ExcelFormats.General, cell.Style.NumberFormat.Format);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Text format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyTextFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string), Format = ExcelFormats.Text }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);


                var cell = ws.Cell(2, 1); // row 2, column 1 = Name
                Assert.AreEqual("John Doe", cell.GetValue<string>());
                Assert.AreEqual(ExcelFormats.Text, cell.Style.NumberFormat.Format);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Integer format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyIntegerFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", Age = 30 }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) },
                new ExcelColumn { Name = "Age" , HeaderText = "Age"      , DataType = typeof(int), Format = ExcelFormats.Integer }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = Age
                Assert.AreEqual(30, cell.GetValue<int>());
                Assert.AreEqual(ExcelFormats.Integer, cell.Style.NumberFormat.Format);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Boolean format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyBooleanFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", IsMember = true }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"    , HeaderText = "Full Name"        , DataType = typeof(string) },
                new ExcelColumn { Name = "IsMember", HeaderText = "Membership Status", DataType = typeof(bool), TrueText = "Yes", FalseText = "No", Format = ExcelFormats.General }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = IsMember
                Assert.AreEqual("Yes", cell.GetValue<string>());
                Assert.AreEqual(ExcelFormats.General, cell.Style.NumberFormat.Format);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the default Boolean format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyDefaultBooleanFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", IsMember = true }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"    , HeaderText = "Full Name"        , DataType = typeof(string) },
                new ExcelColumn { Name = "IsMember", HeaderText = "Membership Status", DataType = typeof(bool)   }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = IsMember
                Assert.AreEqual(true, cell.GetValue<bool>());
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Short Date format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyShortDateFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", JoinDate = new DateTime(2020, 1, 15) }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"    , HeaderText = "Full Name", DataType = typeof(string) },
                new ExcelColumn { Name = "JoinDate", HeaderText = "Join Date", DataType = typeof(DateTime), Format = ExcelFormats.DateShort }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = JoinDate
                Assert.AreEqual(new DateTime(2020, 1, 15), cell.GetDateTime());
                Assert.AreEqual(ExcelFormats.DateShort, cell.Style.NumberFormat.Format);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Long Date format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyDateLongFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", JoinDate = new DateTime(2020, 1, 15) }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"    , HeaderText = "Full Name", DataType = typeof(string) },
                new ExcelColumn { Name = "JoinDate", HeaderText = "Join Date", DataType = typeof(DateTime), Format = ExcelFormats.DateLong }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = JoinDate
                Assert.AreEqual(new DateTime(2020, 1, 15), cell.GetDateTime());
                Assert.AreEqual(ExcelFormats.DateLong, cell.Style.NumberFormat.Format);

                var formatted = cell.GetDateTime().ToString(cell.Style.NumberFormat.Format);
                Assert.AreEqual("Wednesday, January 15, 2020", formatted);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the DateTime format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyDateTimeFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", JoinDate = new DateTime(2020, 1, 15, 2, 30, 00) }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"    , HeaderText = "Full Name", DataType = typeof(string) },
                new ExcelColumn { Name = "JoinDate", HeaderText = "Join Date", DataType = typeof(DateTime), Format = ExcelFormats.DateTime }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = JoinDate
                Assert.AreEqual(new DateTime(2020, 1, 15, 2, 30, 00), cell.GetDateTime());
                Assert.AreEqual(ExcelFormats.DateTime, cell.Style.NumberFormat.Format);

                var formatted = cell.GetDateTime().ToString(cell.Style.NumberFormat.Format);
                Assert.AreEqual("2020-01-15 02:30", formatted);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Double format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyDoubleFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", Salary = 10500.56 }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"  , HeaderText = "Full Name", DataType = typeof(string) },
                new ExcelColumn { Name = "Salary", HeaderText = "Salary"   , DataType = typeof(double), Format = ExcelFormats.Double }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = Salary
                Assert.AreEqual(10500.56, cell.GetDouble(), 0.001);
                Assert.AreEqual(ExcelFormats.Double, cell.Style.NumberFormat.Format);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Currency format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyCurrencyFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", Salary = 10500.50 }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"  , HeaderText = "Full Name", DataType = typeof(string) },
                new ExcelColumn { Name = "Salary", HeaderText = "Salary"   , DataType = typeof(double), Format = ExcelFormats.Currency }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = Salary
                Assert.AreEqual(10500.50, cell.GetDouble(), 0.001);
                Assert.AreEqual(ExcelFormats.Currency, cell.Style.NumberFormat.Format);

                var formatted = cell.GetDouble().ToString("C", CultureInfo.CurrentCulture);
                StringAssert.Contains(formatted, "10,500.50");
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it applies the Percentage format.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldApplyPercentageFormat()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe", Commission = 0.15 }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name"      , HeaderText = "Full Name"     , DataType = typeof(string) },
                new ExcelColumn { Name = "Commission", HeaderText = "Commission (%)", DataType = typeof(double), Format = ExcelFormats.Percent }
            };

            // Act
            using var stream = new MemoryStream();
            ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));

            // Assert
            stream.Position = 0;
            using (var workbook = new XLWorkbook(stream))
            {
                var ws = workbook.Worksheet(_sheetName);

                // Verify worksheet exists
                Assert.IsNotNull(ws);

                var cell = ws.Cell(2, 2); // row 2, column 2 = Commission
                Assert.AreEqual(0.15, cell.GetValue<double>());
                Assert.AreEqual(ExcelFormats.Percent, cell.Style.NumberFormat.Format);

                var formatted = cell.GetValue<double>().ToString(cell.Style.NumberFormat.Format);
                Assert.AreEqual("15.00%", formatted);
            }
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it returns ArgumentException when data is null or empty.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldReturn_ArgumentException_OnNullOrEmptyData()
        {
            // Arrange
            var data = new List<TestObject>();

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act & Assert
            using var stream = new MemoryStream();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));
            });
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it returns ArgumentException when column data is null or empty.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldReturn_ArgumentException_OnNullOrEmptyColumnData()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>();

            // Act & Assert
            using var stream = new MemoryStream();
            Assert.ThrowsException<ArgumentException>(() =>
            {
                ExcelFx.WriteToMemory(data, columns, stream, opts => ApplyOptions(opts));
            });
        }

        /// <summary>
        /// Tests the WriteToMemory method to ensure it returns ArgumentNullException when the output stream is null.
        /// </summary>
        [TestMethod]
        public void WriteToMemory_ShouldReturn_ArgumentNullException_OnNullStream()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                ExcelFx.WriteToMemory(data, columns, null, opts => ApplyOptions(opts));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            });
        }

        /// <summary>
        /// Tests the WriteToExcel method to ensure it creates an Excel file in the specified path.
        /// </summary>
        [TestMethod]
        public void WriteToExcel_ShouldFileExistsInTempPath()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act
            ExcelFx.WriteToExcel(data, columns, _tempFilePath, _tempFileName, opts => ApplyOptions(opts));

            // Assert
            string fullPath = Path.Combine(_tempFilePath, _tempFileName);
            Assert.IsTrue(File.Exists(fullPath));
        }

        /// <summary>
        /// Tests the WriteToExcel method to ensure it returns ArgumentException when the file path is null or empty.
        /// </summary>
        [TestMethod]
        public void WriteToExcel_ShouldReturn_ArgumentException_OnNullOrEmptyFilePath()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                ExcelFx.WriteToExcel(data, columns, null, _tempFileName, opts => ApplyOptions(opts));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                ExcelFx.WriteToExcel(data, columns, "", _tempFileName, opts => ApplyOptions(opts));
            });
        }

        /// <summary>
        /// Tests the WriteToExcel method to ensure it returns ArgumentException when the file name is null or empty.
        /// </summary>
        [TestMethod]
        public void WriteToExcel_ShouldReturn_ArgumentException_OnNullOrEmptyFileName()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act & Assert
            Assert.ThrowsException<ArgumentException>(() =>
            {
#pragma warning disable CS8625 // Cannot convert null literal to non-nullable reference type.
                ExcelFx.WriteToExcel(data, columns, _tempFilePath, null, opts => ApplyOptions(opts));
#pragma warning restore CS8625 // Cannot convert null literal to non-nullable reference type.
            });

            Assert.ThrowsException<ArgumentException>(() =>
            {
                ExcelFx.WriteToExcel(data, columns, _tempFilePath, "", opts => ApplyOptions(opts));
            });
        }

        /// <summary>
        /// Tests the WriteToExcel method to ensure it returns DirectoryNotFoundException when the specified directory does not exist.
        /// </summary>
        [TestMethod]
        public void WriteToExcel_ShouldReturn_DirectoryNotFoundException_WhenTheDirectoryDoesNotExist()
        {
            // Arrange
            string invalidPath = Path.Combine(_tempFilePath, "NonExistentDirectory");

            var data = new List<TestObject>
            {
                new TestObject(){ Name = "John Doe" }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Name", HeaderText = "Full Name", DataType = typeof(string) }
            };

            // Act & Assert
            Assert.ThrowsException<DirectoryNotFoundException>(() =>
            {
                ExcelFx.WriteToExcel(data, columns, invalidPath, _tempFileName, opts => ApplyOptions(opts));
            });
        }

        /// <summary>
        /// Tests the WriteToExcel method with a full table of diverse data types and formatting options.
        /// </summary>
        [TestMethod]
        public void WriteToExcel_FullTableTest()
        {
            // Arrange
            var data = new List<TestObject>
            {
                new TestObject
                {
                    Id         = 1,
                    Name       = "Darshana",
                    Value      = 1000,                          // Integer (#,##0)
                    Age        = 30,                            // Integer (#,##0)
                    IsMember   = true,                          // Boolean
                    JoinDate   = new DateTime(2023, 01, 15),    // yyyy-MM-dd
                    Salary     = 5000.25,                       // Currency ($#,##0.00)
                    Commission = 0.075                          // Percent (0.00%)
                },
                new TestObject
                {
                    Id         = 2,
                    Name       = "Anika",
                    Value      = 2500,
                    Age        = 27,
                    IsMember   = false,
                    JoinDate   = new DateTime(2024, 06, 05),
                    Salary     = 7250.50,
                    Commission = 0.10
                },
                new TestObject
                {
                    Id         = 3,
                    Name       = "Michael",
                    Value      = 1234567,
                    Age        = 42,
                    IsMember   = true,
                    JoinDate   = new DateTime(2022, 12, 31),
                    Salary     = 10000,
                    Commission = 0.125
                },
                new TestObject
                {
                    Id         = 4,
                    Name       = "Sofia",
                    Value      = 789,
                    Age        = 35,
                    IsMember   = true,
                    JoinDate   = new DateTime(2025, 09, 30, 14, 45, 0),
                    Salary     = 3200.75,
                    Commission = 0.05
                },
                new TestObject
                {
                    Id         = 5,
                    Name       = "Liam",
                    Value      = 45678,
                    Age        = 29,
                    IsMember   = false,
                    JoinDate   = new DateTime(2021, 07, 01),
                    Salary     = 15000.99,
                    Commission = 0.20
                }
            };

            var columns = new List<ExcelColumn>
            {
                new ExcelColumn { Name = "Id"        , DataType = typeof(int)     , HeaderText = "ID"        , Format = ExcelFormats.Integer     , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "Name"      , DataType = typeof(string)  , HeaderText = "Full Name" , Format = ExcelFormats.Text        , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "Value"     , DataType = typeof(int)     , HeaderText = "Value"     , Format = ExcelFormats.Integer     , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "Age"       , DataType = typeof(int)     , HeaderText = "Age"       , Format = ExcelFormats.Integer     , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "IsMember"  , DataType = typeof(bool)    , HeaderText = "Membership", TrueText = "Yes", FalseText = "No", Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "JoinDate"  , DataType = typeof(DateTime), HeaderText = "Join Date" , Format = ExcelFormats.DateTime    , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "Salary"    , DataType = typeof(double)  , HeaderText = "Salary"    , Format = ExcelFormats.Currency    , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left },
                new ExcelColumn { Name = "Commission", DataType = typeof(double)  , HeaderText = "Commission", Format = ExcelFormats.Percent     , Width = 25, Alignment = ExcelAlignment.Left, HeaderAlignment = ExcelAlignment.Left }
            };

            // Act
            ExcelFx.WriteToExcel(data, columns, _tempFilePath, _tempFileName, opts => ApplyOptions(opts));

            // Assert
            string fullPath = Path.Combine(_tempFilePath, _tempFileName);
            Assert.IsTrue(File.Exists(fullPath));
        }

        /// <summary>
        /// Applies common Excel export options for the tests.
        /// </summary>
        /// <param name="opts">The <see cref="ExcelExportOptions"/> instance to configure.</param>
        private void ApplyOptions(ExcelExportOptions opts)
        {
            opts.AutoFitColumns     = false;
            opts.FreezeHeader       = true;
            opts.AlternateRowColors = true;
            opts.HeaderBackground   = Color.LightGray;
            opts.AlternateRowColor  = Color.LightYellow;
            opts.SheetName          = _sheetName;
        }

        [TestCleanup]
        public void Cleanup()
        {
            string fullPath = Path.Combine(_tempFilePath, _tempFileName);
            File.Delete(fullPath);
        }
    }
}
