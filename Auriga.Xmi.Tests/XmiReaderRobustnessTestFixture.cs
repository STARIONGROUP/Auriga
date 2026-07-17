// ------------------------------------------------------------------------------------------------
// <copyright file="XmiReaderRobustnessTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Namespaces;
    using Auriga.Xmi.Core.Readers;
    using Auriga.Xmi.Core.ReferenceResolver;

    using NUnit.Framework;

    using ModelReaders = Auriga.Xmi.Model.AutoGenXmiReaders;

    /// <summary>
    /// Tests the <see cref="XmiReader"/>'s guard clauses and its behavior on malformed input: null or
    /// empty arguments, an empty or element-free <c>xmi:XMI</c> wrapper, a root element in an unknown
    /// namespace, a referenced fragment that exists but fails to parse, and the constructor-configured
    /// fragment-extension override of the per-call family derivation.
    /// </summary>
    [TestFixture]
    public class XmiReaderRobustnessTestFixture
    {
        private const string Modeller = "http://www.polarsys.org/capella/core/modeller/7.0.0";

        private static readonly string[] CapellaFragmentExtension = { ".capellafragment" };

        private static readonly string[] MainOnlyElementKeys = { "proj-1" };

        private static readonly string[] MainAndFragmentElementKeys = { "proj-1", "se-1" };

        private string directory = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            this.directory = Path.Combine(Path.GetTempPath(), "auriga-reader-robustness-" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(this.directory);
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            if (Directory.Exists(this.directory))
            {
                Directory.Delete(this.directory, recursive: true);
            }
        }

        [Test]
        public void Verify_that_the_constructor_guards_its_collaborators()
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(ModelReaders.AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new ModelReaders.XmiReaderFacade(cache, namespaceResolver);
            var referenceResolver = new ReferenceResolver();

            Assert.Multiple(() =>
            {
                Assert.That(() => new XmiReader(null!, facade, namespaceResolver, referenceResolver), Throws.ArgumentNullException);
                Assert.That(() => new XmiReader(cache, null!, namespaceResolver, referenceResolver), Throws.ArgumentNullException);
                Assert.That(() => new XmiReader(cache, facade, null!, referenceResolver), Throws.ArgumentNullException);
                Assert.That(() => new XmiReader(cache, facade, namespaceResolver, null!), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_read_guards_its_arguments()
        {
            var reader = CreateReader();

            Assert.Multiple(() =>
            {
                Assert.That(() => reader.Read(null!), Throws.ArgumentException);
                Assert.That(() => reader.Read(string.Empty), Throws.ArgumentException);
                Assert.That(() => reader.Read(null!, CapellaFragmentExtension), Throws.ArgumentException);
                Assert.That(() => reader.Read(string.Empty, CapellaFragmentExtension), Throws.ArgumentException);
                Assert.That(() => reader.Read("model.capella", null!), Throws.ArgumentNullException);
                Assert.That(() => reader.Read((Stream)null!, "document"), Throws.ArgumentNullException);
            });
        }

        [Test]
        public void Verify_that_an_empty_xmi_wrapper_is_rejected()
        {
            const string Xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<xmi:XMI xmi:version=\"2.0\" xmlns:xmi=\"http://www.omg.org/XMI\"/>";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));

            Assert.That(
                () => CreateReader().Read(stream, "empty-wrapper"),
                Throws.InstanceOf<InvalidDataException>().With.Message.Contains("no top-level elements"));
        }

        [Test]
        public void Verify_that_a_wrapper_without_element_children_is_rejected()
        {
            // A non-empty wrapper whose only content is text: the reader must skip the non-element node
            // and still conclude that the document carries no top-level elements.
            const string Xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<xmi:XMI xmi:version=\"2.0\" xmlns:xmi=\"http://www.omg.org/XMI\">stray text</xmi:XMI>";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));

            Assert.That(
                () => CreateReader().Read(stream, "text-only-wrapper"),
                Throws.InstanceOf<InvalidDataException>().With.Message.Contains("no top-level elements"));
        }

        [Test]
        public void Verify_that_an_unknown_root_namespace_is_rejected()
        {
            const string Xml =
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<unknown:Root xmlns:unknown=\"http://example.com/unknown/1.0.0\" id=\"x-1\"/>";

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));

            Assert.That(
                () => CreateReader().Read(stream, "unknown-namespace"),
                Throws.InstanceOf<InvalidDataException>().With.Message.Contains("not a known package"));
        }

        [Test]
        public void Verify_that_a_corrupt_fragment_is_skipped_and_its_reference_reported_unresolved()
        {
            var main = Path.Combine(this.directory, "corrupt-chain.capella");
            File.WriteAllText(main, MainDocumentReferencing("bad.capellafragment#se-1"));
            File.WriteAllText(Path.Combine(this.directory, "bad.capellafragment"), "<<< this is not xml");

            var result = XmiReaderBuilder.Create().Build().Read(main);

            Assert.Multiple(() =>
            {
                Assert.That(result.Root, Is.InstanceOf<Auriga.Model.Capellamodeller.IProject>());
                Assert.That(result.Elements.Keys, Is.EquivalentTo(MainOnlyElementKeys));
                Assert.That(result.UnresolvedReferences, Has.One.Property("TargetIdentifier").EqualTo("bad.capellafragment#se-1"));
            });
        }

        [Test]
        public void Verify_that_configured_fragment_extensions_override_the_family_derivation()
        {
            var main = Path.Combine(this.directory, "configured.capella");
            File.WriteAllText(main, MainDocumentReferencing("configured-frag.capellafragment#se-1"));
            File.WriteAllText(
                Path.Combine(this.directory, "configured-frag.capellafragment"),
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<org.polarsys.capella.core.data.capellamodeller:SystemEngineering xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller=\"" + Modeller + "\" id=\"se-1\" name=\"SE\"/>");

            // An empty configured set suppresses the .capellafragment following the main document's
            // family would otherwise derive; a configured set naming the extension restores it.
            var suppressed = CreateReader(Array.Empty<string>()).Read(main);
            var followed = CreateReader(CapellaFragmentExtension).Read(main);

            Assert.Multiple(() =>
            {
                Assert.That(suppressed.Elements.Keys, Is.EquivalentTo(MainOnlyElementKeys));
                Assert.That(suppressed.UnresolvedReferences, Has.Count.EqualTo(1));
                Assert.That(followed.Elements.Keys, Is.EquivalentTo(MainAndFragmentElementKeys));
                Assert.That(followed.UnresolvedReferences, Is.Empty);
            });
        }

        /// <summary>
        /// Builds a minimal <c>.capella</c> main document whose single <c>ownedModelRoots</c> containment
        /// is an href proxy to the supplied cross-document target.
        /// </summary>
        /// <param name="href">the cross-document href the main document references</param>
        /// <returns>the main document's XML text</returns>
        private static string MainDocumentReferencing(string href)
        {
            return
                "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
                "<org.polarsys.capella.core.data.capellamodeller:Project xmi:version=\"2.0\" " +
                "xmlns:xmi=\"http://www.omg.org/XMI\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" " +
                "xmlns:org.polarsys.capella.core.data.capellamodeller=\"" + Modeller + "\" id=\"proj-1\" name=\"Main\">" +
                "<ownedModelRoots xsi:type=\"org.polarsys.capella.core.data.capellamodeller:SystemEngineering\" " +
                "href=\"" + href + "\"/>" +
                "</org.polarsys.capella.core.data.capellamodeller:Project>";
        }

        /// <summary>
        /// Creates an <see cref="XmiReader"/> wired to a fresh Capella-metamodel graph — its own cache,
        /// namespace resolver, generated facade and reference resolver — optionally with a configured
        /// fragment-extension set overriding the per-call family derivation.
        /// </summary>
        /// <param name="fragmentExtensions">
        /// the fragment extensions the reader follows, or <c>null</c> to derive them per call from the
        /// main document's family
        /// </param>
        /// <returns>the reader</returns>
        private static XmiReader CreateReader(IReadOnlyCollection<string>? fragmentExtensions = null)
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(ModelReaders.AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new ModelReaders.XmiReaderFacade(cache, namespaceResolver);
            var referenceResolver = new ReferenceResolver();

            return new XmiReader(cache, facade, namespaceResolver, referenceResolver, fragmentExtensions: fragmentExtensions);
        }
    }
}
