// ------------------------------------------------------------------------------------------------
// <copyright file="ExportCommandTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Tests.Commands
{
    using System;
    using System.Collections.Generic;
    using System.CommandLine;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Auriga.Reporting.Generators;
    using Auriga.Tools.Commands;
    using Auriga.Tools.Services;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Tests the export command against a mocked generator: that the parsed options arrive at the
    /// generator unchanged, that the version check runs, and that each way a user can be wrong ends
    /// in a reported failure rather than an exception.
    /// </summary>
    [TestFixture]
    public class ExportCommandTestFixture
    {
        private RootCommand root = null!;

        private Mock<IDiagramReportGenerator> generator = null!;

        private Mock<IVersionChecker> versionChecker = null!;

        private ExportCommand.Handler handler = null!;

        private CancellationTokenSource cancellation = null!;

        private string model = string.Empty;

        private string output = string.Empty;

        [SetUp]
        public void SetUp()
        {
            this.cancellation = new CancellationTokenSource();
            this.model = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird");
            this.output = Path.Combine(TestContext.CurrentContext.WorkDirectory, "export-command");

            this.root = new RootCommand();
            this.root.Add(new ExportCommand());

            this.generator = new Mock<IDiagramReportGenerator>();
            this.versionChecker = new Mock<IVersionChecker>();

            this.generator
                .Setup(generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()))
                .Returns(new List<FileInfo> { new(this.model) });

            this.handler = new ExportCommand.Handler(this.generator.Object, this.versionChecker.Object);
        }

        [TearDown]
        public void TearDown()
        {
            this.cancellation.Dispose();
        }

        [Test]
        public void Verify_that_the_handler_guards_its_arguments()
        {
            Assert.Multiple(() =>
            {
                Assert.That(() => new ExportCommand.Handler(null!, this.versionChecker.Object), Throws.ArgumentNullException);
                Assert.That(() => new ExportCommand.Handler(this.generator.Object, null!), Throws.ArgumentNullException);
                Assert.That(() => new ExportCommand(), Throws.Nothing);
            });
        }

        [Test]
        public async Task Verify_that_a_run_reaches_the_generator_and_returns_zero()
        {
            var result = await this.handler.InvokeAsync(this.Parse("--no-logo"), this.cancellation.Token);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(0));

                this.generator.Verify(
                    generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()),
                    Times.Once);

                this.versionChecker.Verify(checker => checker.ExecuteAsync(It.IsAny<CancellationToken>()), Times.Once);
            });
        }

        [Test]
        public async Task Verify_that_the_options_arrive_at_the_generator_as_given()
        {
            DiagramReportOptions? captured = null;

            this.generator
                .Setup(generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()))
                .Callback<FileInfo, DirectoryInfo, DiagramReportOptions?, IProgress<DiagramReportProgress>?>((_, _, options, _) => captured = options)
                .Returns(new List<FileInfo> { new(this.model) });

            await this.handler.InvokeAsync(
                this.Parse("--no-logo", "--format", "png,xlsx", "--dpi", "192", "--background", "#010203", "--quality", "55", "--name", "[SAB]*"),
                this.cancellation.Token);

            Assert.Multiple(() =>
            {
                Assert.That(captured, Is.Not.Null);
                Assert.That(captured!.Formats, Is.EqualTo(DiagramFormats.Png | DiagramFormats.Xlsx));
                Assert.That(captured.Raster.Scale, Is.EqualTo(2), "192 dpi is twice the nominal 96");
                Assert.That(captured.Raster.Quality, Is.EqualTo(55));
                Assert.That(captured.Raster.Background!.Value.ToHex(), Is.EqualTo("#010203"));
                Assert.That(captured.NameFilter, Is.EqualTo("[SAB]*"));
            });
        }

        [Test]
        public async Task Verify_that_scale_is_used_when_no_dpi_is_given()
        {
            DiagramReportOptions? captured = null;

            this.generator
                .Setup(generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()))
                .Callback<FileInfo, DirectoryInfo, DiagramReportOptions?, IProgress<DiagramReportProgress>?>((_, _, options, _) => captured = options)
                .Returns(new List<FileInfo> { new(this.model) });

            await this.handler.InvokeAsync(this.Parse("--no-logo", "--scale", "3"), this.cancellation.Token);

            Assert.That(captured!.Raster.Scale, Is.EqualTo(3));
        }

        [Test]
        public async Task Verify_that_a_model_that_is_not_there_returns_minus_one_without_calling_the_generator()
        {
            var parsed = this.root.Parse(new[] { "export", Path.Combine(TestContext.CurrentContext.TestDirectory, "nope.aird"), "--no-logo" });

            var result = await this.handler.InvokeAsync(parsed, this.cancellation.Token);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(-1));

                this.generator.Verify(
                    generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()),
                    Times.Never);
            });
        }

        [Test]
        public async Task Verify_that_an_unusable_option_returns_minus_one()
        {
            // MultipleAsync, not Multiple: an async lambda passed to Multiple binds to the Action
            // overload, runs as async void and is never awaited, so nothing inside it can fail.
            await Assert.MultipleAsync(async () =>
            {
                Assert.That(await this.handler.InvokeAsync(this.Parse("--no-logo", "--format", "bmp"), this.cancellation.Token), Is.EqualTo(-1));
                Assert.That(await this.handler.InvokeAsync(this.Parse("--no-logo", "--background", "puce"), this.cancellation.Token), Is.EqualTo(-1));
            });
        }

        [Test]
        public async Task Verify_that_a_failing_generator_is_reported_rather_than_thrown()
        {
            this.generator
                .Setup(generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()))
                .Throws(new IOException("the disk is full"));

            var result = await this.handler.InvokeAsync(this.Parse("--no-logo"), this.cancellation.Token);

            Assert.That(result, Is.EqualTo(-1));
        }

        [Test]
        public async Task Verify_that_writing_nothing_is_not_a_failure()
        {
            this.generator
                .Setup(generator => generator.Generate(It.IsAny<FileInfo>(), It.IsAny<DirectoryInfo>(), It.IsAny<DiagramReportOptions>(), It.IsAny<IProgress<DiagramReportProgress>>()))
                .Returns(new List<FileInfo>());

            var result = await this.handler.InvokeAsync(this.Parse("--no-logo", "--name", "matches nothing"), this.cancellation.Token);

            Assert.That(result, Is.EqualTo(0), "a filter that admits nothing is a choice, not an error");
        }

        /// <summary>
        /// Parses an export command line over the fixture's model and output directory.
        /// </summary>
        /// <param name="arguments">the arguments following the model</param>
        /// <returns>the parse result</returns>
        private ParseResult Parse(params string[] arguments)
        {
            var line = new List<string> { "export", this.model, "--output", this.output };
            line.AddRange(arguments);

            return this.root.Parse(line.ToArray());
        }
    }
}
