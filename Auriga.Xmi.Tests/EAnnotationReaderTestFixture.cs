// ------------------------------------------------------------------------------------------------
// <copyright file="EAnnotationReaderTestFixture.cs" company="Starion Group S.A.">
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
    /// Tests that inline <c>ecore:EAnnotation</c> elements are read into <see cref="IEAnnotation"/>
    /// instances carrying their <c>source</c> and their contained <c>details</c> entries (issue #125).
    /// The shape under test is the one the Requirements viewpoint writes into a Sirius
    /// <c>DAnalysisCustomData</c> keyed <c>REQUIREMENTS_VP_QUERIES</c>, which previously failed the read
    /// with "No XMI reader is registered for the type 'ecore:EAnnotation'".
    /// </summary>
    [TestFixture]
    public class EAnnotationReaderTestFixture
    {
        private const string Xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<viewpoint:DAnalysisCustomData xmi:version=\"2.0\" " +
            "xmlns:xmi=\"http://www.omg.org/XMI\" " +
            "xmlns:viewpoint=\"http://www.eclipse.org/sirius/1.1.0\" " +
            "xmlns:ecore=\"http://www.eclipse.org/emf/2002/Ecore\" " +
            "uid=\"custom-data-1\" key=\"REQUIREMENTS_VP_QUERIES\">" +
            "<data xmi:type=\"ecore:EAnnotation\" xmi:id=\"annotation-1\">" +
            "<details xmi:type=\"ecore:EStringToStringMapEntry\" xmi:id=\"entry-1\" key=\"REQUIREMENTS_VP_LABEL_LENGTH\" value=\"80\"/>" +
            "<details xmi:type=\"ecore:EStringToStringMapEntry\" xmi:id=\"entry-2\" key=\"REQUIREMENTS_VP_CONTENT_LENGTH\" value=\"300\"/>" +
            "</data>" +
            "</viewpoint:DAnalysisCustomData>";

        private XmiReaderResult result = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));
            this.result = XmiReaderBuilder.Create().Build().Read(stream, "annotations");
        }

        [Test]
        public void Verify_that_an_annotation_payload_is_read_with_its_details()
        {
            var customData = (Auriga.Diagram.Viewpoint.IDAnalysisCustomData)this.result.Root;

            var annotation = (IEAnnotation)customData.Data!;
            var entries = annotation.Details.OfType<IEStringToStringMapEntry>().ToList();

            Assert.Multiple(() =>
            {
                Assert.That(customData.Key, Is.EqualTo("REQUIREMENTS_VP_QUERIES"));
                Assert.That(entries, Has.Count.EqualTo(2), "every details child is materialized as a map entry");
                Assert.That(entries[0].Key, Is.EqualTo("REQUIREMENTS_VP_LABEL_LENGTH"));
                Assert.That(entries[0].Value, Is.EqualTo("80"));
                Assert.That(entries[1].Key, Is.EqualTo("REQUIREMENTS_VP_CONTENT_LENGTH"));
                Assert.That(entries[1].Value, Is.EqualTo("300"));
            });
        }

        [Test]
        public void Verify_that_the_annotation_is_contained_indexed_and_source_tracked()
        {
            var customData = (Auriga.Diagram.Viewpoint.IDAnalysisCustomData)this.result.Root;
            var annotation = (IEAnnotation)customData.Data!;
            var entry = annotation.Details.OfType<IEStringToStringMapEntry>().First();

            Assert.Multiple(() =>
            {
                Assert.That(this.result.Elements["annotation-1"], Is.SameAs(annotation), "the annotation is cached and indexed by its xmi:id");
                Assert.That(entry.Container, Is.SameAs(annotation), "the containment list re-parents the entry onto the annotation");
                Assert.That(annotation.QueryContainedElements(), Contains.Item(entry), "the entry is a contained element of its annotation");
                Assert.That(annotation.SourceDocument, Is.EqualTo("annotations"));
            });
        }

        [Test]
        public void Verify_that_the_source_attribute_is_read()
        {
            using var xmlReader = XmlReader.Create(new StringReader(
                "<eAnnotations source=\"specificStyles\" />"));

            var annotation = CreateReader().Read(xmlReader, "document", "http://example.org/ns");

            Assert.That(annotation.Source, Is.EqualTo("specificStyles"), "the GMF Note annotation shape carries its source");
        }

        [Test]
        public void Verify_that_read_guards_its_arguments()
        {
            var reader = CreateReader();
            using var xmlReader = XmlReader.Create(new StringReader("<eAnnotations source=\"s\"/>"));

            Assert.Multiple(() =>
            {
                Assert.That(() => reader.Read(null!, "document", "http://example.org/ns"), Throws.ArgumentNullException);
                Assert.That(() => reader.Read(xmlReader, string.Empty, "http://example.org/ns"), Throws.ArgumentException);
                Assert.That(() => reader.Read(xmlReader, "document", string.Empty), Throws.ArgumentException);
            });
        }

        [Test]
        public void Verify_that_a_namespaced_annotation_records_its_own_namespace()
        {
            using var xmlReader = XmlReader.Create(new StringReader(
                "<eAnnotations xmlns=\"http://example.org/annotation-ns\" source=\"s\"/>"));

            var annotation = CreateReader().Read(xmlReader, "document", "http://example.org/document-ns");

            Assert.Multiple(() =>
            {
                Assert.That(annotation.XmiNamespaceUri, Is.EqualTo("http://example.org/annotation-ns"), "the element's own namespace narrows the in-scope namespace");
                Assert.That(annotation.Source, Is.EqualTo("s"));
            });
        }

        [Test]
        public void Verify_that_an_unexpected_child_is_skipped_under_lenient_reading()
        {
            using var xmlReader = XmlReader.Create(new StringReader(
                "<eAnnotations source=\"s\"> stray text <unexpected><nested/></unexpected></eAnnotations>"));

            var annotation = CreateReader().Read(xmlReader, "document", "http://example.org/ns");

            Assert.Multiple(() =>
            {
                Assert.That(annotation.Source, Is.EqualTo("s"), "the annotation is still populated when unknown content is skipped");
                Assert.That(annotation.Details, Is.Empty);
            });
        }

        [Test]
        public void Verify_that_an_unexpected_child_is_rejected_under_strict_reading()
        {
            var settings = new XmiReaderSettings { UseStrictReading = true };
            using var xmlReader = XmlReader.Create(new StringReader(
                "<eAnnotations source=\"s\"><unexpected/></eAnnotations>"));

            Assert.That(
                () => CreateReader(settings).Read(xmlReader, "document", "http://example.org/ns"),
                Throws.InstanceOf<System.NotSupportedException>().With.Message.Contains("unexpected"));
        }

        [Test]
        public void Verify_that_a_cursor_not_on_an_element_yields_an_empty_annotation()
        {
            // A fragment holding no element at all: MoveToContent runs to the end without finding one,
            // which the reader reports as a warning and answers with an unpopulated annotation.
            using var xmlReader = XmlReader.Create(
                new StringReader("<!-- no element here -->"),
                new XmlReaderSettings { ConformanceLevel = ConformanceLevel.Fragment });

            var annotation = CreateReader().Read(xmlReader, "document", "http://example.org/ns");

            Assert.Multiple(() =>
            {
                Assert.That(annotation.Source, Is.Null);
                Assert.That(annotation.Id, Is.Null);
                Assert.That(annotation.Details, Is.Empty);
            });
        }

        /// <summary>
        /// Creates an <see cref="EAnnotationReader"/> wired to a fresh cache and facade, so the reader can
        /// be exercised directly against hand-rolled XML fragments.
        /// </summary>
        /// <param name="settings">the reader settings, or <c>null</c> for the lenient defaults</param>
        /// <returns>the reader</returns>
        private static EAnnotationReader CreateReader(IXmiReaderSettings? settings = null)
        {
            var cache = new XmiElementCache();
            var namespaceResolver = new NamespaceResolver(ModelReaders.AutoGenNamespaceRegistry.NamespaceToPackage);
            var facade = new ModelReaders.XmiReaderFacade(cache, namespaceResolver, settings);

            return new EAnnotationReader(cache, facade, settings);
        }
    }
}
