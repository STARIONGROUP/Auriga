// ------------------------------------------------------------------------------------------------
// <copyright file="UnknownEnumLiteralTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.IO;
    using System.Text;

    using NUnit.Framework;

    /// <summary>
    /// Tests how the reader handles an enumeration literal the generated provider does not recognize
    /// (issue #129). The metamodel declares the full set of literals, so an unrecognized one means the
    /// document was written against a different metamodel version or by a tool Auriga does not model.
    /// It is reported rather than silently leaving the property at its default, which is what the
    /// previous case-insensitive <c>Enum.TryParse</c> did.
    /// </summary>
    [TestFixture]
    public class UnknownEnumLiteralTestFixture
    {
        private const string Xml =
            "<?xml version=\"1.0\" encoding=\"UTF-8\"?>" +
            "<org.polarsys.capella.core.data.pa:PhysicalComponent " +
            "xmlns:org.polarsys.capella.core.data.pa=\"http://www.polarsys.org/capella/core/pa/7.0.0\" " +
            "id=\"pc-1\" nature=\"NOT_A_NATURE\"/>";

        private static Stream Document() => new MemoryStream(Encoding.UTF8.GetBytes(Xml));

        [Test]
        public void Verify_that_an_unknown_literal_leaves_the_default_under_lenient_reading()
        {
            using var stream = Document();

            var result = XmiReaderBuilder.Create().Build().Read(stream, "unknown-enum");
            var component = (Auriga.Model.Pa.IPhysicalComponent)result.Root;

            Assert.Multiple(() =>
            {
                Assert.That(component.Id, Is.EqualTo("pc-1"), "the rest of the element is still read");
                Assert.That(component.Nature, Is.Null, "the feature is left unset rather than guessed at");
            });
        }

        [Test]
        public void Verify_that_an_unknown_literal_is_rejected_under_strict_reading()
        {
            using var stream = Document();

            var reader = XmiReaderBuilder.Create().UsingSettings(settings => settings.UseStrictReading = true).Build();

            Assert.That(
                () => reader.Read(stream, "unknown-enum"),
                Throws.InstanceOf<NotSupportedException>().With.Message.Contains("NOT_A_NATURE"),
                "strict reading surfaces the unrecognized literal instead of defaulting");
        }

        [Test]
        public void Verify_that_a_valid_literal_still_reads()
        {
            var xml = Xml.Replace("NOT_A_NATURE", "NODE", StringComparison.Ordinal);
            using var stream = new MemoryStream(Encoding.UTF8.GetBytes(xml));

            var result = XmiReaderBuilder.Create().Build().Read(stream, "unknown-enum");
            var component = (Auriga.Model.Pa.IPhysicalComponent)result.Root;

            Assert.That(component.Nature, Is.EqualTo(Auriga.Model.Pa.PhysicalComponentNature.NODE));
        }
    }
}
