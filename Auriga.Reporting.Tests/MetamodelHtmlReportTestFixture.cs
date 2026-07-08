// ------------------------------------------------------------------------------------------------
// <copyright file="MetamodelHtmlReportTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Reporting.Tests
{
    using System.IO;

    using ECoreNetto.Reporting.Generators;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    /// <summary>
    /// Smoke tests for the Capella metamodel HTML report produced by the ECoreNetto
    /// <see cref="HtmlReportGenerator"/> (the same report generator the sibling projects use): the report
    /// file is produced, is self-contained HTML, and covers the metamodel.
    /// </summary>
    [TestFixture]
    public class MetamodelHtmlReportTestFixture
    {
        private string reportPath = string.Empty;

        private string report = string.Empty;

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.reportPath = Path.Combine(TestContext.CurrentContext.TestDirectory, "capella-metamodel-report.html");

            new HtmlReportGenerator(NullLoggerFactory.Instance)
                .GenerateCombinedReport(new DirectoryInfo(ecoreDirectory), new FileInfo(this.reportPath));

            this.report = File.ReadAllText(this.reportPath);
        }

        [Test]
        public void Verify_that_the_report_file_is_produced()
        {
            Assert.Multiple(() =>
            {
                Assert.That(File.Exists(this.reportPath), Is.True);
                Assert.That(this.report, Is.Not.Empty);
            });
        }

        [Test]
        public void Verify_that_the_report_is_self_contained_html()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.report, Does.Contain("<!DOCTYPE html>"));
                Assert.That(this.report, Does.Contain("<html>"));

                // Styles are embedded, so the report renders offline / hosted anywhere.
                Assert.That(this.report, Does.Contain("<style"));
                Assert.That(this.report, Does.Not.Contain("<link rel=\"stylesheet\" href=\"http"));
            });
        }

        [Test]
        public void Verify_that_the_report_covers_the_metamodel()
        {
            // A representative type from every architecture layer plus an enumeration must appear.
            Assert.Multiple(() =>
            {
                Assert.That(this.report, Does.Contain("OperationalAnalysis"));
                Assert.That(this.report, Does.Contain("SystemAnalysis"));
                Assert.That(this.report, Does.Contain("LogicalArchitecture"));
                Assert.That(this.report, Does.Contain("PhysicalComponent"));
                Assert.That(this.report, Does.Contain("ConfigurationItem"));
                Assert.That(this.report, Does.Contain("PhysicalComponentNature"));
            });
        }
    }
}
