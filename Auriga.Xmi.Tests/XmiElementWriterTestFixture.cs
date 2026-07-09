// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementWriterTestFixture.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Tests
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Numerics;
    using System.Text;
    using System.Xml;

    using Auriga.Xmi.Writers;

    using NUnit.Framework;

    /// <summary>
    /// Unit tests for the <see cref="XmiElementWriter{T}"/> base: the typed scalar / enum / reference /
    /// containment helpers that every generated writer relies on, including the branches the whole-model
    /// round-trip does not exercise (the numeric attribute writers, the object-fallback reference path and
    /// the cross-document <c>href</c> proxy).
    /// </summary>
    [TestFixture]
    public class XmiElementWriterTestFixture
    {
        private static readonly string[] AbcValues = { "a", "b", "c" };

        private ProbeWriter writer = null!;

        [SetUp]
        public void SetUp()
        {
            this.writer = new ProbeWriter(new FakeFacade());
        }

        [Test]
        public void Verify_that_the_constructor_guards_the_facade()
        {
            Assert.That(() => new ProbeWriter(null!), Throws.ArgumentNullException);
        }

        [Test]
        public void Verify_that_the_id_is_written_when_present_and_omitted_when_empty()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Fragment(w => ProbeWriter.Id(w, new FakeElement { Id = "x1" })), Does.Contain("id=\"x1\""));
                Assert.That(Fragment(w => ProbeWriter.Id(w, new FakeElement { Id = string.Empty })), Does.Not.Contain("id="));
            });
        }

        [Test]
        public void Verify_that_scalar_attributes_are_written_when_present()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Fragment(w => ProbeWriter.String(w, "s", "hi")), Does.Contain("s=\"hi\""));
                Assert.That(Fragment(w => ProbeWriter.Boolean(w, "b", true)), Does.Contain("b=\"true\""));
                Assert.That(Fragment(w => ProbeWriter.Byte(w, "n", (sbyte)-5)), Does.Contain("n=\"-5\""));
                Assert.That(Fragment(w => ProbeWriter.Short(w, "n", (short)7)), Does.Contain("n=\"7\""));
                Assert.That(Fragment(w => ProbeWriter.Integer(w, "n", 42)), Does.Contain("n=\"42\""));
                Assert.That(Fragment(w => ProbeWriter.Long(w, "n", 9000000000L)), Does.Contain("n=\"9000000000\""));
                Assert.That(Fragment(w => ProbeWriter.Float(w, "n", 1.5f)), Does.Contain("n=\"1.5\""));
                Assert.That(Fragment(w => ProbeWriter.Double(w, "n", 2.5d)), Does.Contain("n=\"2.5\""));
                Assert.That(Fragment(w => ProbeWriter.Decimal(w, "n", 3.5m)), Does.Contain("n=\"3.5\""));
                Assert.That(Fragment(w => ProbeWriter.BigInteger(w, "n", new BigInteger(1234))), Does.Contain("n=\"1234\""));
                Assert.That(Fragment(w => ProbeWriter.DateTime(w, "n", new DateTime(2026, 7, 8, 9, 30, 0, DateTimeKind.Utc))), Does.Contain("n=\"2026-07-08T09:30:00Z\""));
                Assert.That(Fragment(w => ProbeWriter.Char(w, "n", 'A')), Does.Contain("n=\"A\""));
                Assert.That(Fragment(w => ProbeWriter.Enum<Probe>(w, "e", Probe.Second)), Does.Contain("e=\"Second\""));
            });
        }

        [Test]
        public void Verify_that_scalar_attributes_are_omitted_when_null()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Fragment(w => ProbeWriter.String(w, "s", null)), Does.Not.Contain("s="));
                Assert.That(Fragment(w => ProbeWriter.Boolean(w, "b", null)), Does.Not.Contain("b="));
                Assert.That(Fragment(w => ProbeWriter.Byte(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Short(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Integer(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Long(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Float(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Double(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Decimal(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.BigInteger(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.DateTime(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Char(w, "n", null)), Does.Not.Contain("n="));
                Assert.That(Fragment(w => ProbeWriter.Enum<Probe>(w, "e", null)), Does.Not.Contain("e="));
            });
        }

        [Test]
        public void Verify_that_a_string_list_attribute_joins_with_spaces_and_omits_when_empty()
        {
            Assert.Multiple(() =>
            {
                Assert.That(Fragment(w => ProbeWriter.StringList(w, "l", AbcValues)), Does.Contain("l=\"a b c\""));
                Assert.That(Fragment(w => ProbeWriter.StringList(w, "l", Array.Empty<string>())), Does.Not.Contain("l="));
                Assert.That(Fragment(w => ProbeWriter.StringList(w, "l", null)), Does.Not.Contain("l="));
            });
        }

        [Test]
        public void Verify_that_a_single_reference_prefers_the_collected_token()
        {
            var owner = new FakeElement();
            owner.SingleValueReferencePropertyIdentifiers["Ref"] = "abc";

            Assert.That(Fragment(w => this.writer.Reference(w, "r", null, owner, "Ref")), Does.Contain("r=\"#abc\""));
        }

        [Test]
        public void Verify_that_a_single_reference_re_emits_a_qualified_token_verbatim()
        {
            var owner = new FakeElement();
            owner.SingleValueReferencePropertyIdentifiers["Ref"] = "fragments/SA.capellafragment#abc";

            Assert.That(Fragment(w => this.writer.Reference(w, "r", null, owner, "Ref")), Does.Contain("r=\"fragments/SA.capellafragment#abc\""));
        }

        [Test]
        public void Verify_that_a_single_reference_falls_back_to_the_resolved_target()
        {
            var owner = new FakeElement { SourceDocument = "sysmodel.capella" };
            var target = new FakeElement { Id = "t1", SourceDocument = "sysmodel.capella" };

            Assert.That(Fragment(w => this.writer.Reference(w, "r", target, owner, "Ref", "sysmodel.capella")), Does.Contain("r=\"#t1\""));
        }

        [Test]
        public void Verify_that_a_single_reference_to_another_document_is_a_relative_href()
        {
            var owner = new FakeElement();
            var target = new FakeElement { Id = "t1", SourceDocument = "fragments/SA.capellafragment" };

            Assert.That(Fragment(w => this.writer.Reference(w, "r", target, owner, "Ref", "sysmodel.capella")), Does.Contain("r=\"fragments/SA.capellafragment#t1\""));
        }

        [Test]
        public void Verify_that_a_single_reference_is_omitted_when_unresolved_and_untracked()
        {
            var owner = new FakeElement();

            Assert.That(Fragment(w => this.writer.Reference(w, "r", null, owner, "Ref")), Does.Not.Contain("r="));
        }

        [Test]
        public void Verify_that_a_reference_list_prefers_the_collected_tokens()
        {
            var owner = new FakeElement();
            owner.MultiValueReferencePropertyIdentifiers["Refs"] = new List<string> { "a", "b" };

            Assert.That(Fragment(w => this.writer.ReferenceList(w, "l", new List<IAurigaElement>(), owner, "Refs")), Does.Contain("l=\"#a #b\""));
        }

        [Test]
        public void Verify_that_a_reference_list_falls_back_to_resolved_targets()
        {
            var owner = new FakeElement();
            var targets = new List<IAurigaElement>
            {
                new FakeElement { Id = "t1" },
                new FakeElement { Id = "t2" },
            };

            Assert.That(Fragment(w => this.writer.ReferenceList(w, "l", targets, owner, "Refs")), Does.Contain("l=\"#t1 #t2\""));
        }

        [Test]
        public void Verify_that_an_empty_reference_list_is_omitted()
        {
            var owner = new FakeElement();

            Assert.That(Fragment(w => this.writer.ReferenceList(w, "l", new List<IAurigaElement>(), owner, "Refs")), Does.Not.Contain("l="));
        }

        [Test]
        public void Verify_that_a_contained_element_is_written_inline_when_in_the_same_document()
        {
            var owner = new FakeElement();
            var child = new FakeElement { Id = "c1" };

            Assert.That(Fragment(w => this.writer.ContainedElement(w, "child", child, owner, "Child")), Does.Contain("<child inline=\"c1\""));
        }

        [Test]
        public void Verify_that_a_contained_element_in_another_document_is_written_as_an_href_proxy()
        {
            var owner = new FakeElement();
            var child = new FakeElement { Id = "c1", SourceDocument = "fragments/SA.capellafragment" };

            var xml = Fragment(w => this.writer.ContainedElement(w, "child", child, owner, "Child", "sysmodel.capella"));

            Assert.That(xml, Does.Contain("<child href=\"fragments/SA.capellafragment#c1\""));
        }

        [Test]
        public void Verify_that_a_null_contained_element_falls_back_to_a_tracked_href_proxy()
        {
            var owner = new FakeElement();
            owner.SingleValueReferencePropertyIdentifiers["Child"] = "fragments/SA.capellafragment#c1";

            var xml = Fragment(w => this.writer.ContainedElement(w, "child", null, owner, "Child"));

            Assert.That(xml, Does.Contain("<child href=\"fragments/SA.capellafragment#c1\""));
        }

        [Test]
        public void Verify_that_a_null_untracked_contained_element_writes_nothing()
        {
            var owner = new FakeElement();

            Assert.That(Fragment(w => this.writer.ContainedElement(w, "child", null, owner, "Child")), Does.Not.Contain("child"));
        }

        [Test]
        public void Verify_that_contained_elements_are_written_inline()
        {
            var owner = new FakeElement();
            var children = new List<IAurigaElement>
            {
                new FakeElement { Id = "c1" },
                new FakeElement { Id = "c2" },
            };

            var xml = Fragment(w => this.writer.ContainedElements(w, "child", children, owner, "Children"));

            Assert.Multiple(() =>
            {
                Assert.That(xml, Does.Contain("inline=\"c1\""));
                Assert.That(xml, Does.Contain("inline=\"c2\""));
            });
        }

        [Test]
        public void Verify_that_contained_elements_fall_back_to_tracked_href_proxies()
        {
            var owner = new FakeElement();
            owner.MultiValueReferencePropertyIdentifiers["Children"] = new List<string> { "fragments/SA.capellafragment#c1" };

            var xml = Fragment(w => this.writer.ContainedElements(w, "child", new List<IAurigaElement>(), owner, "Children"));

            Assert.That(xml, Does.Contain("<child href=\"fragments/SA.capellafragment#c1\""));
        }

        [Test]
        public void Verify_that_write_emits_the_role_tag_and_the_xsi_type()
        {
            var xml = Fragment(w => this.writer.Write(w, new FakeElement { Id = "e1" }, "ownedThing", new XmiWriteContext("sysmodel.capella")), startRoot: false);

            Assert.Multiple(() =>
            {
                Assert.That(xml, Does.Contain("<ownedThing"));
                Assert.That(xml, Does.Contain("xsi:type=\"probe:Probe\""));
                Assert.That(xml, Does.Contain("id=\"e1\""));
            });
        }

        /// <summary>
        /// Serializes into a throw-away element and returns the resulting XML fragment. When
        /// <paramref name="startRoot"/> is <c>true</c> (the default) the callback writes attributes/children
        /// inside a wrapping <c>&lt;e&gt;</c>; when <c>false</c> the callback writes the whole element itself.
        /// </summary>
        private static string Fragment(Action<XmlWriter> write, bool startRoot = true)
        {
            var builder = new StringBuilder();
            var settings = new XmlWriterSettings { OmitXmlDeclaration = true, ConformanceLevel = ConformanceLevel.Fragment };

            using (var xmlWriter = XmlWriter.Create(builder, settings))
            {
                if (startRoot)
                {
                    xmlWriter.WriteStartElement("e");
                    write(xmlWriter);
                    xmlWriter.WriteEndElement();
                }
                else
                {
                    write(xmlWriter);
                }
            }

            return builder.ToString();
        }

        private enum Probe
        {
            First,

            Second,
        }

        /// <summary>
        /// A concrete <see cref="XmiElementWriter{T}"/> that exposes the protected helpers for direct testing.
        /// </summary>
        private sealed class ProbeWriter : XmiElementWriter<FakeElement>
        {
            public ProbeWriter(IXmiElementWriterFacade facade)
                : base(facade)
            {
            }

            public override string NamespacePrefix => "probe";

            public override string TypeName => "Probe";

            public override string NamespaceUri => "urn:probe";

            public static void Id(XmlWriter w, IAurigaElement e) => WriteId(w, e);

            public static void String(XmlWriter w, string n, string? v) => WriteStringAttribute(w, n, v);

            public static void Boolean(XmlWriter w, string n, bool? v) => WriteBooleanAttribute(w, n, v);

            public static void Byte(XmlWriter w, string n, sbyte? v) => WriteByteAttribute(w, n, v);

            public static void Short(XmlWriter w, string n, short? v) => WriteShortAttribute(w, n, v);

            public static void Integer(XmlWriter w, string n, int? v) => WriteIntegerAttribute(w, n, v);

            public static void Long(XmlWriter w, string n, long? v) => WriteLongAttribute(w, n, v);

            public static void Float(XmlWriter w, string n, float? v) => WriteFloatAttribute(w, n, v);

            public static void Double(XmlWriter w, string n, double? v) => WriteDoubleAttribute(w, n, v);

            public static void Decimal(XmlWriter w, string n, decimal? v) => WriteDecimalAttribute(w, n, v);

            public static void BigInteger(XmlWriter w, string n, BigInteger? v) => WriteBigIntegerAttribute(w, n, v);

            public static void DateTime(XmlWriter w, string n, DateTime? v) => WriteDateTimeAttribute(w, n, v);

            public static void Char(XmlWriter w, string n, char? v) => WriteCharAttribute(w, n, v);

            public static void Enum<TEnum>(XmlWriter w, string n, TEnum? v)
                where TEnum : struct => WriteEnumAttribute(w, n, v);

            public static void StringList(XmlWriter w, string n, IEnumerable<string>? v) => WriteStringListAttribute(w, n, v);

            public void Reference(XmlWriter w, string n, IAurigaElement? target, IAurigaElement owner, string property, string document = "doc")
                => this.WriteReferenceAttribute(w, n, target, owner, property, new XmiWriteContext(document));

            public void ReferenceList(XmlWriter w, string n, IEnumerable targets, IAurigaElement owner, string property, string document = "doc")
                => this.WriteReferenceListAttribute(w, n, targets, owner, property, new XmiWriteContext(document));

            public void ContainedElement(XmlWriter w, string role, IAurigaElement? child, IAurigaElement owner, string property, string document = "doc")
                => this.WriteContainedElement(w, role, child, owner, property, new XmiWriteContext(document));

            public void ContainedElements(XmlWriter w, string role, IEnumerable children, IAurigaElement owner, string property, string document = "doc")
                => this.WriteContainedElements(w, role, children, owner, property, new XmiWriteContext(document));

            protected override void WriteBody(XmlWriter xmlWriter, FakeElement poco, IXmiWriteContext context)
            {
                WriteId(xmlWriter, poco);
            }
        }

        /// <summary>
        /// A facade stub that writes a contained element inline as <c>&lt;role inline="id"/&gt;</c> so the
        /// inline-versus-proxy decision is observable in the output.
        /// </summary>
        private sealed class FakeFacade : IXmiElementWriterFacade
        {
            public void WriteElement(XmlWriter xmlWriter, IAurigaElement element, string roleName, IXmiWriteContext context)
            {
                xmlWriter.WriteStartElement(roleName);
                xmlWriter.WriteAttributeString("inline", element.Id);
                xmlWriter.WriteEndElement();
            }

            public IXmiElementWriter ResolveWriter(IAurigaElement element)
            {
                throw new NotSupportedException();
            }
        }

        /// <summary>
        /// A minimal in-memory <see cref="IAurigaElement"/> for exercising the writer helpers.
        /// </summary>
        private sealed class FakeElement : IAurigaElement
        {
            public string? Id { get; set; }

            public IAurigaElement? Container { get; set; }

            public string? SourceDocument { get; set; }

            public string? XsiType { get; set; }

            public string? XmiNamespaceUri { get; set; }

            public IDictionary<string, string> SingleValueReferencePropertyIdentifiers { get; } = new Dictionary<string, string>();

            public IDictionary<string, List<string>> MultiValueReferencePropertyIdentifiers { get; } = new Dictionary<string, List<string>>();

            public IEnumerable<IAurigaElement> QueryContainedElements() => Array.Empty<IAurigaElement>();

            public IEnumerable<IAurigaElement> QueryAllContainedElements() => Array.Empty<IAurigaElement>();
        }
    }
}
