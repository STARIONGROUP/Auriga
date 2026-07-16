// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderBuilderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;

    using Auriga.Diagram.Viewpoint;
    using Auriga.Model.Capellamodeller;

    using Microsoft.Extensions.Logging.Abstractions;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="XmiReaderBuilder"/> fluent factory: that it builds a usable reader
    /// and that the single built reader reads both metamodels' documents — a Capella <c>.capella</c>
    /// semantic model and a Sirius <c>.aird</c> diagram file — through the unioned dispatch tables.
    /// </summary>
    [TestFixture]
    public class XmiReaderBuilderTestFixture
    {
        [Test]
        public void Verify_that_the_fluent_methods_return_the_same_builder()
        {
            var builder = XmiReaderBuilder.Create();

            Assert.Multiple(() =>
            {
                Assert.That(builder.WithLogger(NullLoggerFactory.Instance), Is.SameAs(builder));
                Assert.That(builder.UsingSettings(settings => settings.UseStrictReading = false), Is.SameAs(builder));
            });
        }

        [Test]
        public void Verify_that_one_reader_reads_both_a_capella_and_an_aird_document()
        {
            var reader = XmiReaderBuilder.Create().Build();

            var semantic = reader.Read(TestDataPath("coffee-machine-demo.capella"));
            var diagram = reader.Read(TestDataPath("coffee-machine-demo.aird"));

            Assert.Multiple(() =>
            {
                Assert.That(semantic.Root, Is.InstanceOf<IProject>(), "the .capella root is a Capella project");
                Assert.That(diagram.Root, Is.InstanceOf<IDAnalysis>(), "the .aird root is a Sirius analysis");
            });
        }

        private static string TestDataPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }
    }
}
