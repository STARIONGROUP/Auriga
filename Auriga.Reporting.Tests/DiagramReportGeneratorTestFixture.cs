// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramReportGeneratorTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.Reporting.Drawing;
    using Auriga.Reporting.Generators;
    using Auriga.Reporting.Model;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    /// <summary>
    /// Tests the one call a consumer makes: that it loads a model and writes the formats asked for,
    /// that the name filter narrows what is written, that a workbook is produced only when the
    /// model holds tables, and that a run which could write nothing is refused rather than
    /// silently doing nothing.
    /// </summary>
    /// <remarks>
    /// That the generator resolves a model's own artwork against the model's directory is covered
    /// end to end by <see cref="SvgProjectExportTestFixture"/>, which runs it over the four fixture
    /// models — one of which serves an actor glyph from its own project folder.
    /// </remarks>
    [TestFixture]
    public class DiagramReportGeneratorTestFixture
    {
        private IDiagramReportGenerator generator = null!;

        private FileInfo coffeeMachine = null!;

        private FileInfo fragmented = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.generator = new DiagramReportGenerator(NullLoggerFactory.Instance);
            this.coffeeMachine = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird"));
            this.fragmented = new FileInfo(Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "fragmented-sysmodel", "sysmodel.aird"));
        }

        [Test]
        public void Verify_that_the_generator_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new DiagramReportGenerator(null!), Throws.ArgumentNullException);
                Assert.That(() => this.generator.Generate(null!, this.Output("guards")), Throws.ArgumentNullException);
                Assert.That(() => this.generator.Generate(this.coffeeMachine, null!), Throws.ArgumentNullException);
                Assert.That(() => this.generator.Query(null!), Throws.ArgumentNullException);
                Assert.That(() => DiagramReportGenerator.FileNameOf(null!), Throws.ArgumentNullException);

                Assert.That(
                    () => this.generator.Generate(this.coffeeMachine, this.Output("guards"), new DiagramReportOptions { Formats = DiagramFormats.None }),
                    Throws.ArgumentException,
                    "a run that would write nothing is a mistake, not an empty run");

                Assert.That(() => new DiagramReportOptions { Raster = null! }, Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_the_defaults_write_an_svg_and_a_png_of_every_representation()
        {
            var output = this.Output("defaults");

            var written = this.generator.Generate(this.coffeeMachine, output);
            var representations = this.generator.Query(this.coffeeMachine);

            Assert.Multiple(() =>
            {
                Assert.That(representations, Has.Count.EqualTo(6), "four diagrams and two sequence diagrams");
                Assert.That(written, Has.Count.EqualTo(12));
                Assert.That(written.Count(file => file.Extension == ".svg"), Is.EqualTo(6));
                Assert.That(written.Count(file => file.Extension == ".png"), Is.EqualTo(6));
                Assert.That(written, Has.All.Matches<FileInfo>(file => file.Exists && file.Length > 0));
                Assert.That(output.Exists, Is.True, "the output directory is created when absent");
            });
        }

        [Test]
        public void Verify_that_the_requested_formats_are_the_ones_written()
        {
            var written = this.generator.Generate(
                this.coffeeMachine,
                this.Output("jpeg-only"),
                new DiagramReportOptions { Formats = DiagramFormats.Jpeg, NameFilter = "*make coffee*" });

            Assert.Multiple(() =>
            {
                Assert.That(written, Is.Not.Empty);
                Assert.That(written, Has.All.Matches<FileInfo>(file => file.Extension == ".jpg"));
                Assert.That(File.ReadAllBytes(written[0].FullName).Take(3), Is.EqualTo(new byte[] { 0xFF, 0xD8, 0xFF }));
            });
        }

        [Test]
        public void Verify_that_the_name_filter_narrows_what_is_written()
        {
            var all = this.generator.Query(this.coffeeMachine);
            var filtered = this.generator.Query(this.coffeeMachine, new DiagramReportOptions { NameFilter = "[ES]*" });

            var written = this.generator.Generate(
                this.coffeeMachine,
                this.Output("filtered"),
                new DiagramReportOptions { Formats = DiagramFormats.Svg, NameFilter = "[ES]*" });

            Assert.Multiple(() =>
            {
                Assert.That(filtered, Is.Not.Empty);
                Assert.That(filtered.Count, Is.LessThan(all.Count), "the filter admits fewer than everything");
                Assert.That(filtered, Has.All.Matches<Diagram>(diagram => diagram.Name!.StartsWith("[ES]", StringComparison.Ordinal)));
                Assert.That(written, Has.Count.EqualTo(filtered.Count));
            });
        }

        [Test]
        public void Verify_that_a_filter_matching_nothing_writes_nothing()
        {
            var written = this.generator.Generate(
                this.coffeeMachine,
                this.Output("no-match"),
                new DiagramReportOptions { NameFilter = "there is no such diagram" });

            Assert.That(written, Is.Empty);
        }

        [Test]
        public void Verify_that_a_workbook_is_written_only_for_a_model_that_holds_tables()
        {
            var withTables = this.generator.Generate(
                this.fragmented,
                this.Output("tables"),
                new DiagramReportOptions { Formats = DiagramFormats.Xlsx });

            var withoutTables = this.generator.Generate(
                this.coffeeMachine,
                this.Output("no-tables"),
                new DiagramReportOptions { Formats = DiagramFormats.Xlsx });

            Assert.Multiple(() =>
            {
                Assert.That(withTables, Has.Count.EqualTo(1), "one workbook, a worksheet per table");
                Assert.That(withTables[0].Name, Is.EqualTo("tables.xlsx"));
                Assert.That(withTables[0].Length, Is.GreaterThan(0));

                Assert.That(withoutTables, Is.Empty, "a model with no table has no workbook to write");
            });
        }

        [Test]
        public void Verify_that_the_file_name_is_the_diagram_name_disambiguated_by_its_uid()
        {
            // Every character Windows rejects, so the assertion pins the same answer on a Linux
            // runner, where Path.GetInvalidFileNameChars would object to only the slash.
            var named = new Diagram("_abc123", new List<Box>(), new List<Edge>(), null, null) { Name = "A<b>c:d\"e/f\\g|h?i*j" };
            var unnamed = new Diagram("_def456", new List<Box>(), new List<Edge>(), null, null);

            Assert.Multiple(() =>
            {
                Assert.That(DiagramReportGenerator.FileNameOf(named), Is.EqualTo("A_b_c_d_e_f_g_h_i_j (abc123)"));
                Assert.That(DiagramReportGenerator.FileNameOf(unnamed), Is.EqualTo("def456"), "the uid alone when no descriptor named it");
            });
        }

        [Test]
        public void Verify_that_the_scale_reaches_the_raster()
        {
            var single = this.generator.Generate(
                this.coffeeMachine,
                this.Output("scale-1"),
                new DiagramReportOptions { Formats = DiagramFormats.Png, NameFilter = "*make coffee*" });

            var doubled = this.generator.Generate(
                this.coffeeMachine,
                this.Output("scale-2"),
                new DiagramReportOptions { Formats = DiagramFormats.Png, NameFilter = "*make coffee*", Raster = new RasterOptions { Scale = 2 } });

            Assert.That(doubled[0].Length, Is.GreaterThan(single[0].Length), "twice the size is more pixels, and more bytes");
        }

        /// <summary>
        /// A per-test output directory under the work directory.
        /// </summary>
        /// <param name="name">the test's own folder</param>
        /// <returns>the directory</returns>
        private DirectoryInfo Output(string name)
        {
            return new DirectoryInfo(Path.Combine(TestContext.CurrentContext.WorkDirectory, "generator", name));
        }
    }
}
