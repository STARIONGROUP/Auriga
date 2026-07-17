// ------------------------------------------------------------------------------------------------
// <copyright file="EStringToStringMapEntryReaderTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml;

    using Auriga.Core;
    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Namespaces;
    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    using ModelReaders = Auriga.Xmi.Model.AutoGenXmiReaders;

    /// <summary>
    /// Tests that inline <c>ecore:EStringToStringMapEntry</c> elements — EMF's serialization of an
    /// <c>EMap&lt;String, String&gt;</c>-typed feature, e.g. a Sirius <c>DAnnotation</c>'s
    /// <c>details</c> — are read into <see cref="IEStringToStringMapEntry"/> key/value pairs retained
    /// on the owning element's containment feature (issue #66).
    /// </summary>
    [TestFixture]
    public class EStringToStringMapEntryReaderTestFixture
    {
        private const string Xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<description:DAnnotation xmi:version=\"2.0\" " +
            "xmlns:xmi=\"http://www.omg.org/XMI\" " +
            "xmlns:description=\"http://www.eclipse.org/sirius/description/1.1.0\" " +
            "xmlns:ecore=\"http://www.eclipse.org/emf/2002/Ecore\" " +
            "uid=\"ann-1\" source=\"https://example.org/annotation-source\">" +
            "<details xmi:type=\"ecore:EStringToStringMapEntry\" xmi:id=\"entry-1\" key=\"hide.filter\" value=\"true\"/>" +
            "<details xmi:type=\"ecore:EStringToStringMapEntry\" xmi:id=\"entry-2\" key=\"color\" value=\"245,245,245\"/>" +
            "</description:DAnnotation>";

        private XmiReaderResult result = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));
            this.result = XmiReaderBuilder.Create().Build().Read(stream, "map-entries");
        }

        [Test]
        public void Verify_that_map_entries_are_read_as_key_value_pairs()
        {
            var annotation = (Auriga.Diagram.Viewpoint.Description.IDAnnotation)this.result.Root;

            var entries = annotation.Details.OfType<IEStringToStringMapEntry>().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(entries, Has.Count.EqualTo(2), "every details child is materialized as a map entry");
                Assert.That(entries[0].Key, Is.EqualTo("hide.filter"));
                Assert.That(entries[0].Value, Is.EqualTo("true"));
                Assert.That(entries[1].Key, Is.EqualTo("color"));
                Assert.That(entries[1].Value, Is.EqualTo("245,245,245"));
            });
        }

        [Test]
        public void Verify_that_map_entries_are_contained_indexed_and_source_tracked()
        {
            var annotation = (Auriga.Diagram.Viewpoint.Description.IDAnnotation)this.result.Root;

            var entry = annotation.Details.OfType<IEStringToStringMapEntry>().First();

            Assert.Multiple(() =>
            {
                Assert.That(entry.Container, Is.SameAs(annotation), "the containment list re-parents the entry");
                Assert.That(this.result.Elements["entry-1"], Is.SameAs(entry), "the entry is cached and indexed by its xmi:id");
                Assert.That(entry.SourceDocument, Is.EqualTo("map-entries"));
                Assert.That(annotation.QueryContainedElements(), Contains.Item(entry), "the entry is a contained element of its annotation");
            });
        }

        [Test]
        public void Verify_that_read_guards_its_arguments()
        {
            var reader = CreateReader();
            using var xmlReader = XmlReader.Create(new StringReader("<details key=\"k\" value=\"v\"/>"));

            Assert.Multiple(() =>
            {
                Assert.That(() => reader.Read(null!, "document", "http://example.org/ns"), Throws.ArgumentNullException);
                Assert.That(() => reader.Read(xmlReader, string.Empty, "http://example.org/ns"), Throws.ArgumentException);
                Assert.That(() => reader.Read(xmlReader, "document", string.Empty), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_namespaced_entry_records_its_own_namespace()
        {
            using var xmlReader = XmlReader.Create(new StringReader(
                "<details xmlns=\"http://example.org/entry-ns\" key=\"k\" value=\"v\"/>"));

            var entry = CreateReader().Read(xmlReader, "document", "http://example.org/document-ns");

            Assert.Multiple(() =>
            {
                Assert.That(entry.XmiNamespaceUri, Is.EqualTo("http://example.org/entry-ns"), "the element's own namespace narrows the in-scope namespace");
                Assert.That(entry.Key, Is.EqualTo("k"));
                Assert.That(entry.Value, Is.EqualTo("v"));
            });
        }

        [Test]
        public void Verify_that_an_unexpected_child_is_skipped_under_lenient_reading()
        {
            using var xmlReader = XmlReader.Create(new StringReader(
                "<details key=\"k\" value=\"v\"> stray text <unexpected><nested/></unexpected></details>"));

            var entry = CreateReader().Read(xmlReader, "document", "http://example.org/ns");

            Assert.Multiple(() =>
            {
                Assert.That(entry.Key, Is.EqualTo("k"), "the entry is still populated when unknown content is skipped");
                Assert.That(entry.Value, Is.EqualTo("v"));
            });
        }

        [Test]
        public void Verify_that_an_unexpected_child_is_rejected_under_strict_reading()
        {
            var settings = new XmiReaderSettings { UseStrictReading = true };
            using var xmlReader = XmlReader.Create(new StringReader(
                "<details key=\"k\" value=\"v\"><unexpected/></details>"));

            Assert.That(
                () => CreateReader(settings).Read(xmlReader, "document", "http://example.org/ns"),
                Throws.InstanceOf<System.NotSupportedException>().With.Message.Contains("unexpected"));
        }

        [Test]
        public void Verify_that_a_cursor_not_on_an_element_yields_an_empty_entry()
        {
            // A fragment holding no element at all: MoveToContent runs to the end without finding one,
            // which the reader reports as a warning and answers with an unpopulated entry.
            using var xmlReader = XmlReader.Create(
                new StringReader("<!-- no element here -->"),
                new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment });

            var entry = CreateReader().Read(xmlReader, "document", "http://example.org/ns");

            Assert.Multiple(() =>
            {
                Assert.That(entry.Key, Is.Null);
                Assert.That(entry.Value, Is.Null);
                Assert.That(entry.Id, Is.Null);
            });
        }

        /// <summary>
        /// Creates an <see cref="EStringToStringMapEntryReader"/> wired to a fresh cache and facade, so
        /// the reader can be exercised directly against hand-rolled XML fragments.
        /// </summary>
        /// <param name="settings">the reader settings, or <c>null</c> for the lenient defaults</param>
        /// <returns>the reader</returns>
        private static EStringToStringMapEntryReader CreateReader(IXmiReaderSettings? settings = null)
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(ModelReaders.AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new ModelReaders.XmiReaderFacade(cache, namespaceResolver, settings);

            return new EStringToStringMapEntryReader(cache, facade, settings);
        }
    }
}
