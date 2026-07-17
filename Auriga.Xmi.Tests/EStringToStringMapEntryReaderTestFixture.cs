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

    using Auriga.Core;
    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

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
    }
}
