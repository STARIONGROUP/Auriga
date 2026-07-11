// ------------------------------------------------------------------------------------------------
// <copyright file="UnsupportedContentTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;
    using System.Xml;

    using Auriga.Xmi.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Pins down how the v1 library treats content outside its scope (issue #20, Phase 6): the vendored
    /// metamodel is core Capella + the Requirements viewpoint + Kitalpha at version 7.0.0, and this fixture
    /// proves the two boundary behaviors documented in <c>docs/validation.md</c> — a model saved by a
    /// different Capella version still <b>reads</b> (the namespace resolver is version-tolerant), while a
    /// model that uses an add-on viewpoint outside the vendored metamodel is <b>rejected</b> up front with a
    /// clear, actionable error rather than silently dropping the unknown content.
    /// </summary>
    [TestFixture]
    public class UnsupportedContentTestFixture
    {
        /// <summary>
        /// The coffee-machine fixture is saved by Capella 6.0.0, yet the reader must still load it into a
        /// fully resolved graph: the resolver falls back to a version-stripped namespace match, so a
        /// structurally-compatible model of another minor version reads. (It is nonetheless out of
        /// round-trip scope because the writer emits 7.0.0 namespaces — see <c>docs/validation.md</c>.)
        /// </summary>
        [Test]
        public void Verify_that_a_model_from_a_different_capella_version_still_reads()
        {
            var path = ModelPath("coffee-machine-demo.capella");

            // Guard the premise: this fixture really is a different metamodel version, so the assertion
            // below exercises the version-tolerant fallback and not an exact 7.0.0 match.
            Assert.That(RootNamespace(path), Does.Not.EndWith("/7.0.0"), "the coffee-machine fixture is expected to be a non-7.0.0 model");

            var result = XmiReaderBuilder.Create().Build().Read(path);

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Capellamodeller.IProject>());
                Assert.That(result.Elements, Is.Not.Empty);
                Assert.That(result.UnresolvedReferences, Is.Empty, "a structurally-compatible model of another version resolves fully");
            });
        }

        /// <summary>
        /// The Crowd Surveillance sample uses the Cybersecurity add-on viewpoint, a package the v1 reader
        /// does not vendor. The reader must refuse the whole model with a clear <see cref="InvalidDataException"/>
        /// that names the offending type, rather than silently skipping the unknown content.
        /// </summary>
        [Test]
        public void Verify_that_an_add_on_viewpoint_model_is_rejected_with_a_clear_error()
        {
            var path = ModelPath("Crowd_Surveillance_System_in_DARC.capella");

            var exception = Assert.Throws<InvalidDataException>(() => XmiReaderBuilder.Create().Build().Read(path));

            Assert.That(exception!.Message, Does.Contain("known package"), "the error must explain that the package is not part of the vendored metamodel");
        }

        private static string ModelPath(string fileName)
        {
            return Path.Combine(TestContext.CurrentContext.TestDirectory, "TestData", fileName);
        }

        private static string RootNamespace(string path)
        {
            using var reader = XmlReader.Create(path);
            reader.MoveToContent();
            return reader.NamespaceURI;
        }
    }
}
