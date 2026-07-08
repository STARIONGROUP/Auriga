// ------------------------------------------------------------------------------------------------
// <copyright file="XmiWriterGeneratorExpectedTestFixture.cs" company="Starion Group S.A.">
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
    /// Golden-file tests for the generated XMI writers: a representative subset covering every write case —
    /// enum and scalar attributes, single and multi-valued references, single and collection containment, a
    /// sub-package writer, plus the facade — is compared byte-for-byte against a hand-reviewed expected file
    /// under <c>Expected/</c>. Re-run <see cref="Regenerate_expected_writers"/> after an intended change to
    /// refresh the golden files.
    /// </summary>
    [TestFixture]
    public class XmiWriterGeneratorExpectedTestFixture
    {
        private static readonly string[] ExpectedWriters =
        {
            "ProjectWriter.cs",                 // root, single + collection containment
            "PhysicalComponentWriter.cs",       // enum + scalar attributes, references, containment
            "FunctionalExchangeWriter.cs",      // single-valued references (source/target)
            "PhysicalLinkWriter.cs",            // multi-valued reference (linkEnds)
            "PartWriter.cs",                    // single-valued reference (abstractType) + containment
            "PartDeploymentLinkWriter.cs",      // a sub-package (pa.deployment) writer
            "XmiElementWriterFacade.cs",        // the generated dispatch registry
        };

        private string expectedDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new XmiWriterGenerator(ecoreDirectory).Generate();
            this.expectedDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Expected", "AutoGenXmiWriters");
        }

        [Test]
        [TestCaseSource(nameof(ExpectedWriters))]
        public void Verify_that_the_expected_writer_is_generated(string fileName)
        {
            var generated = this.Generated(fileName);
            var expected = File.ReadAllText(Path.Combine(this.expectedDirectory, fileName));

            Assert.That(Normalize(generated), Is.EqualTo(Normalize(expected)));
        }

        /// <summary>
        /// Rewrites the committed golden writer files from the current generator output. Run this
        /// explicitly after an intended template/generator change, review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed Expected XMI-writer golden files.")]
        public void Regenerate_expected_writers()
        {
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.CodeGenerator.Tests.csproj")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the test project directory");
            var target = Path.Combine(directory!.FullName, "Expected", "AutoGenXmiWriters");
            Directory.CreateDirectory(target);

            foreach (var fileName in ExpectedWriters)
            {
                File.WriteAllText(Path.Combine(target, fileName), this.Generated(fileName));
            }
        }

        private string Generated(string fileName)
        {
            var key = this.files.Keys.Single(k => Path.GetFileName(k) == fileName);
            return this.files[key];
        }

        private static string Normalize(string text)
        {
            return text.Replace("\r\n", "\n");
        }
    }
}
