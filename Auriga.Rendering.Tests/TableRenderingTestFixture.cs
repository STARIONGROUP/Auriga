// ------------------------------------------------------------------------------------------------
// <copyright file="TableRenderingTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Rendering.Tests
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Xml.Linq;

    using Auriga.Diagram.Table;
    using Auriga.Xmi;

    using NUnit.Framework;

    /// <summary>
    /// Table representation rendering (issue #58): a Sirius <c>DTable</c> cross-table builds into the
    /// intermediate <see cref="Diagram"/> model as a grid of boxes and exports to well-formed SVG. The
    /// synthetic tests pin the grid geometry, header/line/cell placement, nesting indent and per-cell
    /// styling; the end-to-end test exports the real <c>fragmented-sysmodel</c> table — the one
    /// table-bearing fixture — through the same <see cref="DiagramBuilder.BuildAll"/> path the diagrams
    /// use, and confirms it is well-formed SVG carrying the header and cell text.
    /// </summary>
    [TestFixture]
    public class TableRenderingTestFixture
    {
        /// <summary>
        /// The Capella name of the table representation in the fragmented-sysmodel fixture (from its
        /// <c>DRepresentationDescriptor</c>).
        /// </summary>
        private const string TableName = "New System Functions - Operational Activities";

        /// <summary>
        /// The uid of that table representation.
        /// </summary>
        private const string TableUid = "_HE6X0MNpEeCmUclACW4KLw";

        private readonly TableBuilder tableBuilder = new();

        [Test]
        public void Verify_that_a_table_builds_a_full_grid_of_boxes()
        {
            var diagram = this.tableBuilder.Build(SampleTable(), "Sample");

            var boxes = diagram.QueryAllBoxes().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(diagram.Identifier, Is.EqualTo("table-1"));
                Assert.That(diagram.Name, Is.EqualTo("Sample"));
                Assert.That(diagram.Edges, Is.Empty, "a table has no edges");

                // 1 corner + 2 column headers + 2 rows * (1 line header + 2 data cells) = 9 boxes: the
                // grid is complete, blank intersections included.
                Assert.That(boxes, Has.Count.EqualTo(9));
            });
        }

        [Test]
        public void Verify_that_the_header_row_carries_the_corner_and_column_labels()
        {
            var boxes = this.tableBuilder.Build(SampleTable()).QueryAllBoxes().ToList();

            var corner = boxes.Single(box => box.Identifier == "table-1-corner");
            var columnA = boxes.Single(box => box.Identifier == "col-column-a");
            var columnB = boxes.Single(box => box.Identifier == "col-column-b");

            Assert.Multiple(() =>
            {
                // The corner cell is empty; the column headers carry their labels and persisted widths.
                Assert.That(corner.Label, Is.Null);
                Assert.That(corner.Position.X, Is.EqualTo(0));
                Assert.That(corner.Width, Is.EqualTo(100), "the persisted headerColumnWidth");

                Assert.That(columnA.Label!.Text, Is.EqualTo("A"));
                Assert.That(columnA.Position.X, Is.EqualTo(100), "the first column starts after the header column");
                Assert.That(columnA.Width, Is.EqualTo(50));

                Assert.That(columnB.Label!.Text, Is.EqualTo("B"));
                Assert.That(columnB.Position.X, Is.EqualTo(150), "the second column follows the first");
                Assert.That(columnB.Width, Is.EqualTo(60));
            });
        }

        [Test]
        public void Verify_that_a_nested_line_is_an_indented_row_header()
        {
            var boxes = this.tableBuilder.Build(SampleTable()).QueryAllBoxes().ToList();

            var topLine = boxes.Single(box => box.Identifier == "row-line-1");
            var subLine = boxes.Single(box => box.Identifier == "row-line-1a");

            Assert.Multiple(() =>
            {
                Assert.That(topLine.Label!.Text, Is.EqualTo("Row1"));
                Assert.That(topLine.Position.Y, Is.EqualTo(24), "the first data row is below the header row");

                // Both line headers are left-aligned (a persisted position), the nested one indented.
                Assert.That(subLine.Label!.Text, Is.EqualTo("Sub"));
                Assert.That(subLine.Position.Y, Is.EqualTo(44), "the sub-line is the second data row");
                Assert.That(subLine.Label.Position!.Value.X, Is.GreaterThan(topLine.Label.Position!.Value.X), "the nested row header is indented");
            });
        }

        [Test]
        public void Verify_that_cells_place_their_label_in_the_right_column_and_blanks_stay_empty()
        {
            var boxes = this.tableBuilder.Build(SampleTable()).QueryAllBoxes().ToList();

            // Row1 has a cell in column A ("X") and a blank in column B.
            var row1ColumnA = boxes.Single(box => box.Identifier == "cell-x");
            var row1ColumnB = boxes.Single(box => box.Identifier == "line-1-column-b");

            Assert.Multiple(() =>
            {
                Assert.That(row1ColumnA.Label!.Text, Is.EqualTo("X"));
                Assert.That(row1ColumnA.Position, Is.EqualTo(new Point(100, 24)), "the cell sits at column A, row 1");
                Assert.That(row1ColumnB.Label, Is.Null, "the blank intersection carries no text");
            });
        }

        [Test]
        public void Verify_that_a_persisted_cell_style_colors_the_cell()
        {
            var boxes = this.tableBuilder.Build(SampleTable()).QueryAllBoxes().ToList();

            var styledCell = boxes.Single(box => box.Identifier == "cell-x").Style.Resolved;

            Assert.Multiple(() =>
            {
                Assert.That(styledCell.FillColor, Is.EqualTo(new Color(255, 0, 0)), "the cell background is the persisted red");
                Assert.That(styledCell.FontColor, Is.EqualTo(new Color(0, 0, 255)), "the cell foreground is the persisted blue");
                Assert.That(styledCell.Bold, Is.True, "the persisted Bold label format is applied");
            });
        }

        [Test]
        public void Verify_that_an_invisible_line_is_omitted()
        {
            var table = SampleTable();
            ((IDLine)table.Lines[0]).Visible = false;

            var boxes = this.tableBuilder.Build(table).QueryAllBoxes().ToList();

            // Hiding the top line drops it and its sub-line: only the header row (corner + 2 columns)
            // remains.
            Assert.That(boxes, Has.Count.EqualTo(3));
        }

        [Test]
        public void Verify_that_the_real_table_fixture_exports_to_well_formed_svg()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "fragmented-sysmodel", "sysmodel.aird");
            using var scope = XmiReaderBuilder.Create();
            var result = scope.BuildAirdModelLoader().Load(path);

            var table = new DiagramBuilder().BuildAll(result.Elements.Values).Single(diagram => diagram.Identifier == TableUid);

            var file = Path.Combine(TestContext.CurrentContext.WorkDirectory, "table-export.svg");
            new SvgExporter().ExportToFile(table, file);

            var document = XDocument.Load(file);
            var texts = document.Descendants().Where(element => element.Name.LocalName == "text").ToList();
            var rects = document.Descendants().Where(element => element.Name.LocalName == "rect").ToList();

            Assert.Multiple(() =>
            {
                Assert.That(table.Name, Is.EqualTo(TableName), "the table is named from its descriptor");
                Assert.That(document.Root!.Name.LocalName, Is.EqualTo("svg"), "the export is well-formed SVG");

                // A grid: many cell rectangles, and the header/line/cell text carried through.
                Assert.That(rects, Has.Count.GreaterThan(20), "the grid draws a rectangle per cell");
                Assert.That(texts.Any(text => text.Value.Contains("OA1")), Is.True, "a column header is rendered");
                Assert.That(texts.Any(text => text.Value.Contains("SysOA1_1")), Is.True, "a line header is rendered");
                Assert.That(texts.Any(text => text.Value.Trim() == "X"), Is.True, "an intersection mark is rendered");
            });
        }

        /// <summary>
        /// Builds a small synthetic table: two columns (A width 50, B width 60), a top line "Row1" with
        /// a nested "Sub" line, a red/blue/bold-styled cell "X" at (Row1, A) and a plain cell "Y" at
        /// (Sub, B); every other intersection blank. Header column width 100.
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
