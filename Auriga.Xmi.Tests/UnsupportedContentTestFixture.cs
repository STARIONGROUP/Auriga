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
    using System.Text;
    using System.Xml;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Pins down how the v1 library treats content outside its scope (Phase 6): the vendored
    /// metamodel is core Capella + the Requirements, Mass, Basic Requirement and Cybersecurity viewpoints +
    /// Kitalpha at version 7.0.0, and this fixture proves the two boundary behaviors documented in
    /// <c>docs/validation.md</c> — a model saved by a different Capella version still <b>reads</b> (the
    /// namespace resolver is version-tolerant), while a model that uses an add-on viewpoint outside the
    /// vendored metamodel is <b>rejected</b> up front with a clear, actionable error rather than silently
    /// dropping the unknown content.
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
                Assert.That(result.Root, Is.InstanceOf<Auriga.Model.Capellamodeller.IProject>());
                Assert.That(result.Elements, Is.Not.Empty);
                Assert.That(result.UnresolvedReferences, Is.Empty, "a structurally-compatible model of another version resolves fully");
            });
        }

        /// <summary>
        /// A model that carries an <c>ownedExtensions</c> element from an add-on viewpoint whose package the
        /// reader does not vendor must be refused with a clear <see cref="InvalidDataException"/> that names
        /// the offending type, rather than silently skipping the unknown content. (The Cybersecurity, Mass
        /// and Basic Requirement viewpoints are now vendored — the Crowd Surveillance sample they came from
        /// reads and round-trips — so a fabricated, genuinely-unknown viewpoint namespace stands in here.)
        /// </summary>
        [Test]
        public void Verify_that_an_add_on_viewpoint_model_is_rejected_with_a_clear_error()
        {
            var model =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>\n" +
                "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" " +
                "xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller=\"http://www.polarsys.org/capella/core/modeller/7.0.0\" " +
                "xmlns:unknownvp=\"http://www.example.org/capella/unknown/viewpoint\" " +
                "id=\"_project\" name=\"Unsupported\">\n" +
                "  <ownedExtensions xsi:type=\"unknownvp:SomeExtension\" id=\"_ext\"/>\n" +
                "</org.polarsys.capella.core.data.capellamodeller:Project>\n";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(model));

            var exception = Assert.Throws<InvalidDataException>(() => XmiReaderBuilder.Create().Build().Read(stream, "unsupported.capella"));

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
