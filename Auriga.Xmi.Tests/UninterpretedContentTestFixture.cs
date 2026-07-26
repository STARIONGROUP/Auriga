// ------------------------------------------------------------------------------------------------
// <copyright file="UninterpretedContentTestFixture.cs" company="Starion Group S.A.">
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
    using System.Xml.Linq;

    using NUnit.Framework;

    /// <summary>
    /// Tests that content Auriga cannot interpret survives a read-write unchanged: an
    /// element whose type belongs to a package that is not vendored — an add-on viewpoint, say — and an
    /// attribute the metamodel does not declare. Without this, a read-write of a model Auriga only
    /// partly understands silently destroys the parts it does not model, which the Capella tool itself
    /// would never do.
    /// </summary>
    [TestFixture]
    public class UninterpretedContentTestFixture
    {
        private const string Xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<org.polarsys.capella.core.data.capellamodeller:Project " +
            "xmlns:org.polarsys.capella.core.data.capellamodeller=\"http://www.polarsys.org/capella/core/modeller/7.0.0\" " +
            "xmlns:vp=\"http://example.org/unvendored/viewpoint/1.0\" " +
            "id=\"project-1\" name=\"Demo\" vp:customField=\"kept\">" +
            "<vp:AddOnConfiguration id=\"cfg-1\" mode=\"strict\">" +
            "<vp:setting key=\"threshold\" value=\"42\"/>" +
            "<vp:note>text &amp; markup</vp:note>" +
            "</vp:AddOnConfiguration>" +
            "</org.polarsys.capella.core.data.capellamodeller:Project>";

        private Auriga.Core.IAurigaElement root = null!;

        [OneTimeSetUp]
        public void SetUp()
        {
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(Xml));
            this.root = XmiReaderBuilder.Create().Build().Read(stream, "uninterpreted").Root;
        }

        [Test]
        public void Verify_that_an_unvendored_element_is_captured_verbatim()
        {
            Assert.Multiple(() =>
            {
                Assert.That(this.root.UninterpretedContent, Has.Count.EqualTo(1));
                Assert.That(this.root.UninterpretedContent[0], Does.Contain("AddOnConfiguration").And.Contain("threshold").And.Contain("text &amp; markup"));

                // ReadOuterXml materialises the prefix declaration the fragment inherits from the root,
                // so the capture stands alone and can be written into a document that declares nothing.
                Assert.That(this.root.UninterpretedContent[0], Does.Contain("xmlns:vp="));
            });
        }

        [Test]
        public void Verify_that_an_undeclared_attribute_is_captured_verbatim()
        {
            var captured = this.root.UninterpretedAttributes.SingleOrDefault(a => a.Name == "vp:customField");

            Assert.Multiple(() =>
            {
                Assert.That(captured, Is.Not.Null, "the attribute of an unvendored package is captured");
                Assert.That(captured!.Value, Is.EqualTo("kept"));
                Assert.That(captured.NamespaceUri, Is.EqualTo("http://example.org/unvendored/viewpoint/1.0"));

                // The modelled attributes are not swept up as uninterpreted.
                Assert.That(this.root.UninterpretedAttributes.Select(a => a.Name), Does.Not.Contain("name"));
                Assert.That(this.root.UninterpretedAttributes.Select(a => a.Name), Does.Not.Contain("id"));
            });
        }

        [Test]
        public void Verify_that_uninterpreted_content_survives_a_write()
        {
            var written = Write(this.root);
            var document = XDocument.Parse(written);

            XNamespace vp = "http://example.org/unvendored/viewpoint/1.0";
            var configuration = document.Descendants(vp + "AddOnConfiguration").SingleOrDefault();

            Assert.Multiple(() =>
            {
                Assert.That(configuration, Is.Not.Null, "the unvendored element is re-emitted");
                Assert.That(configuration!.Attribute("mode")?.Value, Is.EqualTo("strict"));
                Assert.That(configuration.Elements(vp + "setting").Single().Attribute("value")?.Value, Is.EqualTo("42"));
                Assert.That(configuration.Elements(vp + "note").Single().Value, Is.EqualTo("text & markup"));
                Assert.That(document.Root!.Attribute(vp + "customField")?.Value, Is.EqualTo("kept"), "the undeclared attribute is re-emitted");
            });
        }

        [Test]
        public void Verify_that_repeated_read_write_cycles_are_stable()
        {
            // A capture that grew or drifted on each cycle would still pass a single round-trip, so the
            // second pass is what proves the content is neither duplicated nor progressively mangled.
            var first = Write(this.root);

            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(first));
            var reread = XmiReaderBuilder.Create().Build().Read(stream, "uninterpreted").Root;
            var second = Write(reread);

            Assert.Multiple(() =>
            {
                Assert.That(reread.UninterpretedContent, Has.Count.EqualTo(1), "the capture is not duplicated on re-read");
                Assert.That(reread.UninterpretedAttributes, Has.Count.EqualTo(1));
                Assert.That(second, Is.EqualTo(first), "a second read-write produces identical output");
            });
        }

        /// <summary>
        /// Writes the element to a string through the standard writer pipeline.
        /// </summary>
        /// <param name="element">the element to write</param>
        /// <returns>the written document</returns>
        private static string Write(Auriga.Core.IAurigaElement element)
        {
            var directory = Path.Combine(Path.GetTempPath(), "auriga-uninterpreted-" + System.Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(directory);

            try
            {
                var path = Path.Combine(directory, "uninterpreted");
                XmiWriterBuilder.Create().Build().Write(element, path);

                return File.ReadAllText(path);
            }
            finally
            {
                Directory.Delete(directory, recursive: true);
            }
        }
    }
}
