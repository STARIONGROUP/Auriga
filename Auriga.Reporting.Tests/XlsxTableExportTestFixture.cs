// ------------------------------------------------------------------------------------------------
// <copyright file="XlsxTableExportTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Tests
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.Reporting.Builders;
    using Auriga.Reporting.Generators;
    using Auriga.Reporting.Model;

    using Auriga.Diagram.Table;
    using Auriga.Xmi;

    using ClosedXML.Excel;

    using NUnit.Framework;

    /// <summary>
    /// Excel export of Sirius table representations: a <c>DTable</c> writes to an <c>.xlsx</c> workbook
    /// with a header row of column labels, a header column of line labels indented by nesting, and one
    /// cell per intersection. Every assertion reads the written workbook back through ClosedXML, so the
    /// output is verified as a real spreadsheet rather than by inspecting the writer's intentions — no
    /// manual Excel step is needed.
    /// </summary>
    [TestFixture]
    public class XlsxTableExportTestFixture : ReportingTestFixtureBase
    {
        /// <summary>
        /// The Capella name of the table representation in the fragmented-sysmodel fixture.
        /// </summary>
        private const string TableName = "New System Functions - Operational Activities";

        /// <summary>
        /// The uid of that table representation.
        /// </summary>
        private const string TableUid = "_HE6X0MNpEeCmUclACW4KLw";

        [Test]
        public void Verify_that_the_grid_is_written_with_its_headers_and_intersections()
        {
            using var workbook = this.Export(SampleTable(), "Sample");
            var sheet = workbook.Worksheet(1);

            Assert.Multiple(() =>
            {
                Assert.That(sheet.Name, Is.EqualTo("Sample"), "the worksheet takes the table name");
                Assert.That(sheet.Cell(1, 1).GetString(), Is.Empty, "the top-left corner stays empty");

                Assert.That(sheet.Cell(1, 2).GetString(), Is.EqualTo("A"), "the first column header");
                Assert.That(sheet.Cell(1, 3).GetString(), Is.EqualTo("B"), "the second column header");

                Assert.That(sheet.Cell(2, 1).GetString(), Is.EqualTo("Row1"), "the first line header");
                Assert.That(sheet.Cell(3, 1).GetString(), Is.EqualTo("Sub"), "the nested line header");

                // The marks land at their own intersections and nowhere else.
                Assert.That(sheet.Cell(2, 2).GetString(), Is.EqualTo("X"), "(Row1, A)");
                Assert.That(sheet.Cell(3, 3).GetString(), Is.EqualTo("Y"), "(Sub, B)");
                Assert.That(sheet.Cell(2, 3).GetString(), Is.Empty, "(Row1, B) is blank");
                Assert.That(sheet.Cell(3, 2).GetString(), Is.Empty, "(Sub, A) is blank");
            });
        }

        [Test]
        public void Verify_that_nesting_is_written_as_an_indent_level()
        {
            using var workbook = this.Export(SampleTable(), "Sample");
            var sheet = workbook.Worksheet(1);

            Assert.Multiple(() =>
            {
                Assert.That(sheet.Cell(2, 1).Style.Alignment.Indent, Is.EqualTo(0), "a top-level line is not indented");
                Assert.That(sheet.Cell(3, 1).Style.Alignment.Indent, Is.EqualTo(1), "a nested line is indented one level");
            });
        }

        [Test]
        public void Verify_that_the_persisted_cell_style_is_carried_across()
        {
            using var workbook = this.Export(SampleTable(), "Sample");
            var styled = workbook.Worksheet(1).Cell(2, 2);

            Assert.Multiple(() =>
            {
                Assert.That(styled.Style.Fill.BackgroundColor, Is.EqualTo(XLColor.FromArgb(255, 0, 0)), "the persisted background");
                Assert.That(styled.Style.Font.FontColor, Is.EqualTo(XLColor.FromArgb(0, 0, 255)), "the persisted foreground");
                Assert.That(styled.Style.Font.Bold, Is.True, "the persisted bold label format");

                // A cell with no persisted style keeps the default font.
                Assert.That(workbook.Worksheet(1).Cell(3, 3).Style.Font.Bold, Is.False);
            });
        }

        [Test]
        public void Verify_that_the_header_row_and_column_are_frozen_and_shaded()
        {
            using var workbook = this.Export(SampleTable(), "Sample");
            var sheet = workbook.Worksheet(1);

            Assert.Multiple(() =>
            {
                Assert.That(sheet.SheetView.SplitRow, Is.EqualTo(1), "the header row is frozen");
                Assert.That(sheet.SheetView.SplitColumn, Is.EqualTo(1), "the header column is frozen");
                Assert.That(sheet.Cell(1, 2).Style.Fill.BackgroundColor, Is.EqualTo(XLColor.FromArgb(240, 240, 240)));
                Assert.That(sheet.Cell(1, 2).Style.Font.Bold, Is.True);
            });
        }

        [Test]
        public void Verify_that_an_invisible_or_collapsed_line_follows_the_svg_grid()
        {
            // The traversal is shared with TableBuilder, so the workbook shows exactly the lines the SVG
            // grid draws: an invisible line is omitted and a collapsed line hides its descendants.
            var table = SampleTable();
            table.Lines[0].Collapsed = true;

            using var workbook = this.Export(table, "Sample");
            var sheet = workbook.Worksheet(1);

            Assert.Multiple(() =>
            {
                Assert.That(sheet.Cell(2, 1).GetString(), Is.EqualTo("Row1"), "the collapsed line is still shown");
                Assert.That(sheet.Cell(3, 1).GetString(), Is.Empty, "its descendants are not");
            });
        }

        [Test]
        public void Verify_that_several_tables_write_one_worksheet_each_with_unique_names()
        {
            var tables = new[]
            {
                new KeyValuePair<string, IDTable>("Shared", SampleTable()),
                new KeyValuePair<string, IDTable>("Shared", SampleTable()),
                new KeyValuePair<string, IDTable>("Has:illegal/chars?", SampleTable()),
            };

            var path = Path.Combine(TestContext.CurrentContext.WorkDirectory, "tables-batch.xlsx");
            this.XlsxTableExporter.Export(tables, path);

            using var workbook = new XLWorkbook(path);

            Assert.Multiple(() =>
            {
                Assert.That(workbook.Worksheets, Has.Count.EqualTo(3));
                Assert.That(workbook.Worksheet(1).Name, Is.EqualTo("Shared"));
                Assert.That(workbook.Worksheet(2).Name, Is.EqualTo("Shared (2)"), "a duplicate name is suffixed");
                Assert.That(workbook.Worksheet(3).Name, Does.Not.Contain(":").And.Not.Contain("/").And.Not.Contain("?"), "illegal characters are replaced");
            });
        }

        [Test]
        public void Verify_that_a_long_name_is_trimmed_to_excels_limit()
        {
            var name = new string('N', 60);

            using var workbook = this.Export(SampleTable(), name);

            Assert.That(workbook.Worksheet(1).Name, Has.Length.EqualTo(31), "Excel caps a worksheet name at 31 characters");
        }

        [Test]
        public void Verify_that_the_real_table_fixture_exports_to_a_readable_workbook()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "fragmented-sysmodel", "sysmodel.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var table = result.Elements.Values.OfType<IDTable>().Single(candidate => candidate.Uid == TableUid);

            var file = Path.Combine(TestContext.CurrentContext.WorkDirectory, "table-export.xlsx");
            this.XlsxTableExporter.Export(table, file, TableName);

            using var workbook = new XLWorkbook(file);
            var sheet = workbook.Worksheet(1);
            var used = sheet.RangeUsed()!;
            var values = used.Cells().Select(cell => cell.GetString()).ToList();

            Assert.Multiple(() =>
            {
                // The real name is 45 characters, so this fixture also exercises Excel's 31-character
                // worksheet-name limit rather than only the synthetic case.
                Assert.That(TableName, Has.Length.GreaterThan(31), "the fixture name exceeds Excel's limit");
                Assert.That(sheet.Name, Is.EqualTo(TableName.Substring(0, 31)), "the worksheet is named from the descriptor, trimmed");

                Assert.That(used.RowCount(), Is.GreaterThan(1), "the header row plus line rows");
                Assert.That(used.ColumnCount(), Is.GreaterThan(1), "the header column plus data columns");

                Assert.That(values.Any(value => value.Contains("OA1")), Is.True, "a column header is written");
                Assert.That(values.Any(value => value.Contains("SysOA1_1")), Is.True, "a line header is written");
                Assert.That(values.Any(value => value.Trim() == "X"), Is.True, "an intersection mark is written");
            });
        }

        /// <summary>
        /// Exports a table and reads the workbook straight back, so every assertion is made against a
        /// real spreadsheet rather than the writer's in-memory state.
        /// </summary>
        /// <param name="table">the table to export</param>
        /// <param name="name">the worksheet name</param>
        /// <returns>the reloaded workbook, which the caller disposes</returns>
        private XLWorkbook Export(DTable table, string name)
        {
            var stream = new MemoryStream();
            this.XlsxTableExporter.Export(table, stream, name);
            stream.Position = 0;

            return new XLWorkbook(stream);
        }

        /// <summary>
        /// Builds the same small synthetic table the SVG table tests use: two columns (A, B), a top line
        /// "Row1" with a nested "Sub" line, a red/blue/bold-styled cell "X" at (Row1, A) and a plain cell
        /// "Y" at (Sub, B); every other intersection blank.
        /// </summary>
        /// <returns>the synthetic table</returns>
        private static DTable SampleTable()
        {
            var columnA = new DTargetColumn { Id = "column-a", Uid = "column-a", Label = "A", Width = 50 };
            var columnB = new DTargetColumn { Id = "column-b", Uid = "column-b", Label = "B", Width = 60 };

            var cellX = new DCell
            {
                Id = "cell-x",
                Uid = "cell-x",
                Label = "X",
                Column = columnA,
                CurrentStyle = new DCellStyle
                {
                    BackgroundColor = "255,0,0",
                    ForegroundColor = "0,0,255",
                    LabelFormat = { Auriga.Diagram.Viewpoint.FontFormat.Bold },
                },
            };

            var topLine = new DLine { Id = "line-1", Uid = "line-1", Label = "Row1" };
            topLine.Cells.Add(cellX);

            var cellY = new DCell { Id = "cell-y", Uid = "cell-y", Label = "Y", Column = columnB };
            var subLine = new DLine { Id = "line-1a", Uid = "line-1a", Label = "Sub" };
            subLine.Cells.Add(cellY);
            topLine.Lines.Add(subLine);

            var table = new DTable { Id = "table-1", Uid = "table-1", HeaderColumnWidth = 100 };
            table.Columns.Add(columnA);
            table.Columns.Add(columnB);
            table.Lines.Add(topLine);

            return table;
        }
    }
}
