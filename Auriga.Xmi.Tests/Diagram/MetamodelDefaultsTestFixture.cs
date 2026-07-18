// ------------------------------------------------------------------------------------------------
// <copyright file="MetamodelDefaultsTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests.Diagram
{
    using System.IO;
    using System.Text;

    using Auriga.Xmi.Core.Readers;

    using NUnit.Framework;

    /// <summary>
    /// Tests the metamodel-default semantics of issue #76: EMF omits attributes whose value equals
    /// the declared <c>defaultValueLiteral</c>, so an omitted attribute must read as the declared
    /// default (an <c>EdgeStyle</c> without <c>targetArrow</c> is an <c>InputArrow</c>, not the
    /// first enum literal), and a value equal to the declared default must be omitted again on
    /// write so a round-trip does not materialize attributes the original file never had.
    /// </summary>
    [TestFixture]
    public class MetamodelDefaultsTestFixture
    {
        private const string EdgeXml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<diagram:DEdge xmi:version=\"2.0\" " +
            "xmlns:xmi=\"http://www.omg.org/XMI\" " +
            "xmlns:diagram=\"http://www.eclipse.org/sirius/diagram/1.1.0\" " +
            "uid=\"edge-1\">" +
            "<ownedStyle xmi:type=\"diagram:EdgeStyle\" uid=\"style-1\"{0}/>" +
            "</diagram:DEdge>";

        [Test]
        public void Verify_that_an_omitted_attribute_reads_as_the_declared_default()
        {
            var edge = ReadEdge(string.Empty);

            Assert.Multiple(() =>
            {
                Assert.That(edge.OwnedStyle.TargetArrow, Is.EqualTo(Auriga.Diagram.Diagram.EdgeArrows.InputArrow), "the metamodel default, not the first literal");
                Assert.That(edge.OwnedStyle.SourceArrow, Is.EqualTo(Auriga.Diagram.Diagram.EdgeArrows.NoDecoration));
                Assert.That(edge.OwnedStyle.Size, Is.EqualTo(1), "EdgeStyle.size defaults to 1");
            });
        }

        [Test]
        public void Verify_that_an_explicit_non_default_value_still_wins()
        {
            var edge = ReadEdge(" targetArrow=\"FillDiamond\" size=\"3\"");

            Assert.Multiple(() =>
            {
                Assert.That(edge.OwnedStyle.TargetArrow, Is.EqualTo(Auriga.Diagram.Diagram.EdgeArrows.FillDiamond));
                Assert.That(edge.OwnedStyle.Size, Is.EqualTo(3));
            });
        }

        [Test]
        public void Verify_that_a_default_valued_attribute_is_omitted_on_write()
        {
            var edge = ReadEdge(string.Empty);

            var written = Write(edge);

            Assert.Multiple(() =>
            {
                Assert.That(written, Does.Not.Contain("targetArrow"), "a value equal to the declared default stays omitted");
                Assert.That(written, Does.Not.Contain("sourceArrow"));
                Assert.That(written, Does.Not.Contain("size="));
            });
        }

        [Test]
        public void Verify_that_a_non_default_value_round_trips()
        {
            var edge = ReadEdge(" targetArrow=\"FillDiamond\"");

            var written = Write(edge);

            Assert.That(written, Contains.Substring("targetArrow=\"FillDiamond\""));
        }

        /// <summary>
        /// Reads the one-edge document with the supplied extra <c>ownedStyle</c> attributes.
        /// </summary>
        /// <param name="styleAttributes">the extra attribute text, leading space included</param>
        /// <returns>the read edge</returns>
        private static Auriga.Diagram.Diagram.IDEdge ReadEdge(string styleAttributes)
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(string.Format(EdgeXml, styleAttributes)));
            var result = XmiReaderBuilder.Create().Build().Read(stream, "defaults");

            return (Auriga.Diagram.Diagram.IDEdge)result.Root;
        }

        /// <summary>
        /// Writes the edge back to XMI text.
        /// </summary>
        /// <param name="edge">the edge to write</param>
        /// <returns>the serialized document text</returns>
        private static string Write(Auriga.Diagram.Diagram.IDEdge edge)
        {
            // The document name must match the name the elements were read under ("defaults"), or the
            // fragment-preserving writer serializes the style as a cross-document href proxy.
            using var stream = new MemoryStream();
            XmiWriterBuilder.Create().Build().WriteDocument((Auriga.Core.IAurigaElement)edge, stream, "defaults");

            return Encoding.UTF8.GetString(stream.ToArray());
        }
    }
}
