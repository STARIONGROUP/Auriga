// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderGeneratorExpectedTestFixture.cs" company="Starion Group S.A.">
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
    /// Golden-file tests (the uml4net/SysML2.NET pattern) for the generated XMI readers: a representative
    /// subset covering every read case — enum and scalar attributes, single and multi-valued references,
    /// single and collection containment, a sub-package reader, plus the facade and namespace registry —
    /// is compared byte-for-byte against a hand-reviewed expected file under <c>Expected/</c>. Re-run
    /// <see cref="Regenerate_expected_readers"/> after an intended change to refresh the golden files.
    /// </summary>
    [TestFixture]
    public class XmiReaderGeneratorExpectedTestFixture
    {
        /// <summary>
        /// The representative generated files compared against golden copies. Each has a unique file name
        /// so it can be matched across the per-package folders.
        /// </summary>
        private static readonly string[] ExpectedReaders =
        {
            "ProjectReader.cs",                 // root, single + collection containment
            "PhysicalComponentReader.cs",       // enum + scalar attributes, references, containment
            "FunctionalExchangeReader.cs",      // single-valued references (source/target)
            "PhysicalLinkReader.cs",            // multi-valued reference (linkEnds)
            "PartReader.cs",                    // single-valued reference (abstractType) + containment
            "PartDeploymentLinkReader.cs",      // a sub-package (pa.deployment) reader
            "XmiReaderFacade.cs",               // the generated dispatch registry
            "AutoGenNamespaceRegistry.cs",      // the generated namespace map
        };

        private string expectedDirectory = string.Empty;

        private IReadOnlyDictionary<string, string> files = new Dictionary<string, string>();

        [OneTimeSetUp]
        public void SetUp()
        {
            var ecoreDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Data", "ecore");
            this.files = new XmiReaderGenerator(ecoreDirectory).Generate();
            this.expectedDirectory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Expected", "AutoGenXmiReaders");
        }

        [Test]
        [TestCaseSource(nameof(ExpectedReaders))]
        public void Verify_that_the_expected_reader_is_generated(string fileName)
        {
            var generated = this.Generated(fileName);
            var expected = File.ReadAllText(Path.Combine(this.expectedDirectory, fileName));

            Assert.That(Normalize(generated), Is.EqualTo(Normalize(expected)));
        }

        /// <summary>
        /// Rewrites the committed golden reader files from the current generator output. Run this
        /// explicitly after an intended template/generator change, review the diff and commit.
        /// </summary>
        [Test]
        [Explicit("Regenerates the committed Expected XMI-reader golden files.")]
        public void Regenerate_expected_readers()
        {
            // Anchor on the test project's .csproj (an ancestor of the bin output directory) so the golden
            // files are written into the source tree rather than the copied Expected folder under bin.
            var directory = new DirectoryInfo(TestContext.CurrentContext.TestDirectory);
            while (directory != null && !File.Exists(Path.Combine(directory.FullName, "Auriga.CodeGenerator.Tests.csproj")))
            {
                directory = directory.Parent;
            }

            Assert.That(directory, Is.Not.Null, "could not locate the test project directory");
            var target = Path.Combine(directory!.FullName, "Expected", "AutoGenXmiReaders");
            Directory.CreateDirectory(target);

            foreach (var fileName in ExpectedReaders)
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
