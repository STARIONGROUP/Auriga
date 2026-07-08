// ------------------------------------------------------------------------------------------------
// <copyright file="HtmlReportGeneratorTestFixture.cs" company="Starion Group S.A.">
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
    using System.Text.RegularExpressions;

    using Auriga.Reporting;

    using NUnit.Framework;

    /// <summary>
    /// Smoke tests for <see cref="HtmlReportGenerator"/>: the generated site covers the whole metamodel,
    /// every internal link resolves, the output is self-contained and generation is deterministic.
    /// </summary>
    [TestFixture]
    public class HtmlReportGeneratorTestFixture
    {
        private const int ExpectedPackages = 25;
        private const int ExpectedClasses = 430;
        private const int ExpectedEnums = 35;

        private string ecoreDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new HtmlReportGenerator(this.ecoreDirectory).Generate();
        }

        [Test]
        public void Verify_that_the_site_covers_the_whole_metamodel()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.files.Keys, Contains.Item("index.html"));
                Assert.That(this.files.Keys, Contains.Item("styles.css"));
                Assert.That(this.Count("package."), Is.EqualTo(ExpectedPackages));
                Assert.That(this.Count("class."), Is.EqualTo(ExpectedClasses));
                Assert.That(this.Count("enum."), Is.EqualTo(ExpectedEnums));
            });
        }

        [Test]
        public void Verify_that_every_internal_link_targets_an_emitted_page()
        {
            var pages = new HashSet<string>(this.files.Keys);

            var brokenLinks = this.files
                .Where(f => f.Key.EndsWith(".html", System.StringComparison.Ordinal))
                .SelectMany(f => Hrefs(f.Value))
                .Where(href => !pages.Contains(href))
                .Distinct()
                .ToList();

            Assert.That(brokenLinks, Is.Empty, "every href must target an emitted page");
        }

        [Test]
        public void Verify_that_the_output_is_self_contained()
        {
            // No page may reference an external host — the report must render offline / hosted anywhere.
            var external = this.files.Values
                .SelectMany(html => Regex.Matches(html, "(href|src)=\"([^\"]+)\"").Select(m => m.Groups[2].Value))
                .Where(reference => reference.StartsWith("http:", System.StringComparison.Ordinal)
                    || reference.StartsWith("https:", System.StringComparison.Ordinal)
                    || reference.StartsWith("//", System.StringComparison.Ordinal))
                .Distinct()
                .ToList();

            Assert.That(external, Is.Empty, "the report must not reference external hosts");
        }

        [Test]
        public void Verify_that_generation_is_deterministic()
        {
            var second = new HtmlReportGenerator(this.ecoreDirectory).Generate();

            Assert.That(second, Is.EqualTo(this.files));
        }

        [Test]
        public void Verify_that_a_representative_class_page_is_rendered()
        {
            Assert.That(this.files.Keys, Contains.Item("class.pa.PhysicalComponent.html"));

            var page = this.files["class.pa.PhysicalComponent.html"];

            Assert.Multiple(() =>
            {
                Assert.That(page, Does.Contain("<code>PhysicalComponent</code>"));
                Assert.That(page, Does.Contain("Super-types"));
                Assert.That(page, Does.Contain("Features"));
                // a cross-link to another type's page
                Assert.That(page, Does.Contain("href=\"class.cs.Component.html\""));
                // an enum-typed feature links to the enum page
                Assert.That(page, Does.Contain("href=\"enum.pa.PhysicalComponentNature.html\""));
            });
        }

        private int Count(string prefix)
        {
            return this.files.Keys.Count(k => k.StartsWith(prefix, System.StringComparison.Ordinal) && k.EndsWith(".html", System.StringComparison.Ordinal));
        }

        private static IEnumerable<string> Hrefs(string html)
        {
            return Regex.Matches(html, "href=\"([^\"]+)\"").Select(m => m.Groups[1].Value);
        }
    }
}
