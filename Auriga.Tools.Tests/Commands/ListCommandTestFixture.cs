// ------------------------------------------------------------------------------------------------
// <copyright file="ListCommandTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Tools.Tests.Commands
{
    using System.Collections.Generic;
    using System.CommandLine;
    using System.IO;
    using System.Threading;
    using System.Threading.Tasks;

    using Auriga.Reporting.Generators;
    using Auriga.Reporting.Model;
    using Auriga.Tools.Commands;
    using Auriga.Tools.Services;

    using Moq;

    using NUnit.Framework;

    /// <summary>
    /// Tests the list command against a mocked generator: that it queries rather than writes, that
    /// the filter is passed on, and that a model which is not there is reported.
    /// </summary>
    [TestFixture]
    public class ListCommandTestFixture
    {
        private RootCommand root = null!;

        private Mock<IDiagramReportGenerator> generator = null!;

        private Mock<IVersionChecker> versionChecker = null!;

        private ListCommand.Handler handler = null!;

        private CancellationTokenSource cancellation = null!;

        private string model = string.Empty;

        [SetUp]
        public void SetUp()
        {
            this.cancellation = new CancellationTokenSource();
            this.model = Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", "coffee-machine-demo.aird");

            this.root = new RootCommand();
            this.root.Add(new ListCommand());

            this.generator = new Mock<IDiagramReportGenerator>();
            this.versionChecker = new Mock<IVersionChecker>();

            this.generator
                .Setup(generator => generator.Query(It.IsAny<FileInfo>(), It.IsAny<DiagramReportOptions>()))
                .Returns(new List<Diagram>
                {
                    new("_one", new List<Box>(), new List<Edge>(), null, null) { Name = "[SAB] Overview" },
                    new("_two", new List<Box>(), new List<Edge>(), null, null),
                });

            this.handler = new ListCommand.Handler(this.generator.Object, this.versionChecker.Object);
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
                Assert.That(() => new ListCommand.Handler(null!, this.versionChecker.Object), Throws.ArgumentNullException);
                Assert.That(() => new ListCommand.Handler(this.generator.Object, null!), Throws.ArgumentNullException);
                Assert.That(() => new ListCommand(), Throws.Nothing);
            });
        }

        [Test]
        public async Task Verify_that_listing_queries_the_model_and_writes_nothing()
        {
            var result = await this.handler.InvokeAsync(this.root.Parse(new[] { "list", this.model, "--no-logo" }), this.cancellation.Token);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(0));
                this.generator.Verify(generator => generator.Query(It.IsAny<FileInfo>(), It.IsAny<DiagramReportOptions>()), Times.Once);
                this.versionChecker.Verify(checker => checker.ExecuteAsync(It.IsAny<CancellationToken>()), Times.Once);
            });
        }

        [Test]
        public async Task Verify_that_the_filter_is_passed_on()
        {
            DiagramReportOptions? captured = null;

            this.generator
                .Setup(generator => generator.Query(It.IsAny<FileInfo>(), It.IsAny<DiagramReportOptions>()))
                .Callback<FileInfo, DiagramReportOptions?>((_, options) => captured = options)
                .Returns(new List<Diagram>());

            await this.handler.InvokeAsync(this.root.Parse(new[] { "list", this.model, "--no-logo", "--name", "[ES]*" }), this.cancellation.Token);

            Assert.That(captured!.NameFilter, Is.EqualTo("[ES]*"));
        }

        [Test]
        public async Task Verify_that_a_model_holding_nothing_is_reported_but_is_not_a_failure()
        {
            this.generator
                .Setup(generator => generator.Query(It.IsAny<FileInfo>(), It.IsAny<DiagramReportOptions>()))
                .Returns(new List<Diagram>());

            var result = await this.handler.InvokeAsync(this.root.Parse(new[] { "list", this.model, "--no-logo" }), this.cancellation.Token);

            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public async Task Verify_that_a_model_that_is_not_there_returns_minus_one()
        {
            var parsed = this.root.Parse(new[] { "list", Path.Combine(TestContext.CurrentContext.TestDirectory, "nope.aird"), "--no-logo" });

            var result = await this.handler.InvokeAsync(parsed, this.cancellation.Token);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.EqualTo(-1));
                this.generator.Verify(generator => generator.Query(It.IsAny<FileInfo>(), It.IsAny<DiagramReportOptions>()), Times.Never);
            });
        }

        [Test]
        public async Task Verify_that_a_failing_read_is_reported_rather_than_thrown()
        {
            this.generator
                .Setup(generator => generator.Query(It.IsAny<FileInfo>(), It.IsAny<DiagramReportOptions>()))
                .Throws(new InvalidDataException("that is not a Sirius model"));

            var result = await this.handler.InvokeAsync(this.root.Parse(new[] { "list", this.model, "--no-logo" }), this.cancellation.Token);

            Assert.That(result, Is.EqualTo(-1));
        }
    }
}
