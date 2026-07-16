// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderGeneratorTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.CodeGenerator.Tests.Generators
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    using Auriga.CodeGenerator.Generators;

    using NUnit.Framework;

    /// <summary>
    /// Tests for the <see cref="XmiReaderGenerator"/>, which generates the <c>Auriga.Xmi</c> per-type XMI
    /// readers, the reader facade and the namespace registry (issue #10). A reader is emitted for each of
    /// the 275 concrete classes, plus the two aggregate files.
    /// </summary>
    [TestFixture]
    public class XmiReaderGeneratorTestFixture
    {
        private const int ExpectedConcreteReaderCount = 275;

        private string ecoreDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new XmiReaderGenerator(this.ecoreDirectory).Generate();
        }

        [Test]
        public void Verify_that_generation_is_deterministic()
        {
            var second = new XmiReaderGenerator(this.ecoreDirectory).Generate();

            Assert.That(second, Is.EqualTo(this.files));
        }

        [Test]
        public void Verify_that_a_reader_is_generated_for_every_concrete_class()
        {
            var readerCount = this.files.Keys.Count(k =>
                k.StartsWith("AutoGenXmiReaders/", System.StringComparison.Ordinal)
                && k.EndsWith("Reader.cs", System.StringComparison.Ordinal));

            Assert.That(readerCount, Is.EqualTo(ExpectedConcreteReaderCount));
        }

        [Test]
        public void Verify_that_the_facade_and_registry_are_generated()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.files.Keys, Contains.Item("AutoGenXmiReaders/Model/XmiReaderFacade.cs"));
                Assert.That(this.files.Keys, Contains.Item("AutoGenXmiReaders/Model/AutoGenNamespaceRegistry.cs"));
            });
        }

        [Test]
        public void Verify_that_the_namespace_registry_maps_the_physical_architecture_namespace()
        {
            var registry = this.files["AutoGenXmiReaders/Model/AutoGenNamespaceRegistry.cs"];

            Assert.That(registry, Does.Contain("[\"http://www.polarsys.org/capella/core/pa/7.0.0\"] = \"pa\","));
        }

        /// <summary>
        /// Regenerates the committed XMI readers into the <c>Auriga.Xmi</c> project. Run this explicitly
        /// after changing the reader generator or a template, then review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed XMI readers in the Auriga.Xmi project.")]
        public void Regenerate_xmi_readers()
        {
            var xmiProject = Path.Combine(SolutionRoot(), "Auriga.Xmi");
            new XmiReaderGenerator(this.ecoreDirectory).Write(xmiProject);
        }

        private static string SolutionRoot()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.sln")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the solution root");
            return directory!.FullName;
        }
    }
}
