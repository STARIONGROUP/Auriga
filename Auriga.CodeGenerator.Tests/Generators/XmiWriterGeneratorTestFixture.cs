// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterGeneratorTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests for the <see cref="XmiWriterGenerator"/>, which generates the <c>Auriga.Xmi</c> per-type XMI
    /// writers and the writer facade (issue #17) — the inverse of the reader generator. A writer is emitted
    /// for each of the 275 concrete classes, plus the facade.
    /// </summary>
    [TestFixture]
    public class XmiWriterGeneratorTestFixture
    {
        private const int ExpectedConcreteWriterCount = 275;

        private string ecoreDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            this.ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new XmiWriterGenerator(this.ecoreDirectory).Generate();
        }

        [Test]
        public void Verify_that_generation_is_deterministic()
        {
            var second = new XmiWriterGenerator(this.ecoreDirectory).Generate();

            Assert.That(second, Is.EqualTo(this.files));
        }

        [Test]
        public void Verify_that_a_writer_is_generated_for_every_concrete_class()
        {
            var writerCount = this.files.Keys.Count(k =>
                k.StartsWith("AutoGenXmiWriters/", System.StringComparison.Ordinal)
                && k.EndsWith("Writer.cs", System.StringComparison.Ordinal));

            Assert.That(writerCount, Is.EqualTo(ExpectedConcreteWriterCount));
        }

        [Test]
        public void Verify_that_the_facade_is_generated()
        {
            Assert.That(this.files.Keys, Contains.Item("AutoGenXmiWriters/XmiElementWriterFacade.cs"));
        }

        [Test]
        public void Verify_that_the_physical_function_writer_declares_its_namespace()
        {
            var writer = this.files["AutoGenXmiWriters/Pa/PhysicalFunctionWriter.cs"];

            Assert.Multiple(() =>
            {
                Assert.That(writer, Does.Contain("NamespacePrefix => \"org.polarsys.capella.core.data.pa\""));
                Assert.That(writer, Does.Contain("NamespaceUri => \"http://www.polarsys.org/capella/core/pa/7.0.0\""));
                Assert.That(writer, Does.Contain("TypeName => \"PhysicalFunction\""));
            });
        }

        /// <summary>
        /// Regenerates the committed XMI writers into the <c>Auriga.Xmi</c> project. Run this explicitly
        /// after changing the writer generator or a template, then review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed XMI writers in the Auriga.Xmi project.")]
        public void Regenerate_xmi_writers()
        {
            var xmiProject = Path.Combine(SolutionRoot(), "Auriga.Xmi");
            new XmiWriterGenerator(this.ecoreDirectory).Write(xmiProject);
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
