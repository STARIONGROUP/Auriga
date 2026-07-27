// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Writers
{
    using Auriga.Core;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Numerics;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The abstract base from which every generated per-type XMI writer derives. It writes the shared
    /// element scaffolding (start tag, type and identity attributes) and provides the typed helpers that
    /// serialize scalar, enumeration, reference and containment features — the inverse of
    /// <c>XmiElementReader&lt;T&gt;</c>. The type and identity attributes follow the element's family:
    /// Capella uses <c>xsi:type</c> and a bare <c>id</c>; the EMF-native Eclipse trees (Sirius, GMF,
    /// Ecore) use <c>xmi:type</c>, with GMF notation identified by <c>xmi:id</c> and Sirius by its domain
    /// <c>uid</c>. Non-containment references are encoded as <c>#id</c> attributes and containment as
    /// child elements; a reference into another document becomes a relative <c>href</c>.
    /// </summary>
    /// <typeparam name="T">the type of <see cref="IAurigaElement"/> the writer serializes</typeparam>
    public abstract class XmiElementWriter<T> : IXmiElementWriter
        where T : IAurigaElement
    {
        /// <summary>
        /// The XML Schema instance namespace, in which the <c>xsi:type</c> attribute is declared.
        /// </summary>
        protected const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// The XMI namespace, in which the <c>xmi:type</c> and <c>xmi:id</c> attributes the EMF-native
        /// Sirius / GMF trees use are declared.
        /// </summary>
        protected const string XmiNamespace = "http://www.omg.org/XMI";

        /// <summary>
        /// The namespace-URI prefix shared by the Eclipse-hosted metamodels (Sirius, GMF and Ecore),
        /// which serialize a contained element's type as <c>xmi:type</c> rather than Capella's
        /// <c>xsi:type</c> and identify an element without a domain <c>uid</c> by <c>xmi:id</c>.
        /// </summary>
        private const string EclipseNamespacePrefix = "http://www.eclipse.org/";

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementWriter{T}"/> class.
        /// </summary>
        /// <param name="facade">the facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        protected XmiElementWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory = null)
        {
            this.Facade = facade ?? throw new ArgumentNullException(nameof(facade));
            this.Logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger(this.GetType());
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix of the element's package (e.g.
        /// <c>org.polarsys.capella.core.data.pa</c>).
        /// </summary>
        public abstract string NamespacePrefix { get; }

        /// <summary>
        /// Gets the element's XMI type name, unqualified (e.g. <c>PhysicalFunction</c>).
        /// </summary>
        public abstract string TypeName { get; }

        /// <summary>
        /// Gets the namespace URI of the element's package (e.g.
        /// <c>http://www.polarsys.org/capella/core/pa/7.0.0</c>).
        /// </summary>
        public abstract string NamespaceUri { get; }

        /// <summary>
        /// Gets the facade used to write contained elements.
        /// </summary>
        protected IXmiElementWriterFacade Facade { get; }

        /// <summary>
        /// Gets the logger.
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Writes the element as a contained child under <paramref name="roleName"/>: the role-named start
        /// tag, the <c>xsi:type</c>, then the body (id, attributes and children).
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element to write</param>
        /// <param name="roleName">the containment feature's XML name (e.g. <c>ownedFunctions</c>)</param>
        /// <param name="context">the write context</param>
        public void Write(XmlWriter xmlWriter, IAurigaElement element, string roleName, IXmiWriteContext context)
        {
            xmlWriter.WriteStartElement(roleName);

            // Capella serializes a contained element's type as xsi:type; the EMF-native Eclipse trees
            // (Sirius, GMF, Ecore) use xmi:type. EMF treats the two as interchangeable on read.
            if (this.IsEclipseHosted)
            {
                xmlWriter.WriteAttributeString("xmi", "type", XmiNamespace, this.NamespacePrefix + ":" + this.TypeName);
            }
            else
            {
                xmlWriter.WriteAttributeString("xsi", "type", XsiNamespace, this.NamespacePrefix + ":" + this.TypeName);
            }

            this.WriteBody(xmlWriter, (T)element, context);
            xmlWriter.WriteEndElement();
        }

        /// <summary>
        /// Writes the element's body only — its <c>id</c>, attributes and contained children — without the
        /// enclosing start/end tag. Used for a document root, whose tag the <see cref="IXmiWriter"/> writes
        /// with the package prefix and namespace declarations.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element whose body to write</param>
        /// <param name="context">the write context</param>
        public void WriteBody(XmlWriter xmlWriter, IAurigaElement element, IXmiWriteContext context)
        {
            this.WriteBody(xmlWriter, (T)element, context);
        }

        /// <summary>
        /// Writes the element's <c>id</c>, attributes and contained children. Implemented by each generated
        /// writer.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected abstract void WriteBody(XmlWriter xmlWriter, T poco, IXmiWriteContext context);

        /// <summary>
        /// Gets whether the element belongs to an Eclipse-hosted metamodel (Sirius, GMF or Ecore), which
        /// serialize a contained element's type as <c>xmi:type</c> rather than Capella's <c>xsi:type</c>.
        /// Derived from the writer's own package <see cref="NamespaceUri"/>, the authoritative signal (a
        /// contained element's own XML namespace is empty, so the reader-captured namespace is unreliable).
        /// </summary>
        private bool IsEclipseHosted => this.NamespaceUri.StartsWith(EclipseNamespacePrefix, StringComparison.Ordinal);

        /// <summary>
        /// Writes the element's identity attribute when present, in the family's serialization: a Sirius
        /// element that models a domain <c>uid</c> (an <see cref="Auriga.Diagram.Viewpoint.IIdentifiedElement"/>)
        /// carries its identity there — the generated writer emits that <c>uid</c> separately, so nothing is
        /// written here to avoid a duplicate. The remaining EMF-native Eclipse elements (GMF notation and the
        /// Sirius style / description trees without a <c>uid</c>) are identified by <c>xmi:id</c>; Capella by a
        /// bare <c>id</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element</param>
        protected void WriteId(XmlWriter xmlWriter, IAurigaElement element)
        {
            if (string.IsNullOrEmpty(element.Id))
            {
                return;
            }

            if (element is Auriga.Diagram.Viewpoint.IIdentifiedElement identified && !string.IsNullOrEmpty(identified.Uid))
            {
                return;
            }

            if (this.IsEclipseHosted)
            {
                xmlWriter.WriteAttributeString("xmi", "id", XmiNamespace, element.Id);
                return;
            }

            xmlWriter.WriteAttributeString("id", element.Id);
        }

        /// <summary>
        /// Writes a string attribute when the value is not <c>null</c> and differs from the feature's
        /// declared default (EMF omits attributes equal to the metamodel's <c>defaultValueLiteral</c>).
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteStringAttribute(XmlWriter xmlWriter, string name, string? value, string? defaultValue = null)
        {
            if (value != null && !string.Equals(value, defaultValue, StringComparison.Ordinal))
            {
                xmlWriter.WriteAttributeString(name, value);
            }
        }

        /// <summary>
        /// Writes a boolean attribute, as <c>true</c>/<c>false</c>, when the value is present and
        /// differs from the feature's declared default.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteBooleanAttribute(XmlWriter xmlWriter, string name, bool? value, bool? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, XmlConvert.ToString(value.Value));
            }
        }

        /// <summary>
        /// Writes an enumeration attribute, by its Ecore literal name, when the value is present and
        /// differs from the feature's declared default. The literal name is supplied by the enumeration's
        /// generated provider rather than derived from the C# member name, which does not always reproduce
        /// it — Sirius declares lower-case literals such as <c>italic</c>, generated as <c>Italic</c>.
        /// </summary>
        /// <typeparam name="TEnum">the enumeration type</typeparam>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="toLiteralString">the generated provider's <c>ToLiteralString</c>, which maps the value to its Ecore literal name</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteEnumAttribute<TEnum>(XmlWriter xmlWriter, string name, TEnum? value, Func<TEnum, string> toLiteralString, TEnum? defaultValue = null)
            where TEnum : struct
        {
            if (value.HasValue && !value.Equals(defaultValue))
            {
                xmlWriter.WriteAttributeString(name, toLiteralString(value.Value));
            }
        }

        /// <summary>
        /// Writes a signed-byte attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteByteAttribute(XmlWriter xmlWriter, string name, sbyte? value, sbyte? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Writes a short-integer attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteShortAttribute(XmlWriter xmlWriter, string name, short? value, short? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Writes an integer attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteIntegerAttribute(XmlWriter xmlWriter, string name, int? value, int? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Writes a long-integer attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteLongAttribute(XmlWriter xmlWriter, string name, long? value, long? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Writes a single-precision attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteFloatAttribute(XmlWriter xmlWriter, string name, float? value, float? defaultValue = null)
        {
            if (value.HasValue && !value.Equals(defaultValue))
            {
                xmlWriter.WriteAttributeString(name, XmlConvert.ToString(value.Value));
            }
        }

        /// <summary>
        /// Writes a double-precision attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteDoubleAttribute(XmlWriter xmlWriter, string name, double? value, double? defaultValue = null)
        {
            if (value.HasValue && !value.Equals(defaultValue))
            {
                xmlWriter.WriteAttributeString(name, XmlConvert.ToString(value.Value));
            }
        }

        /// <summary>
        /// Writes a decimal attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteDecimalAttribute(XmlWriter xmlWriter, string name, decimal? value, decimal? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, XmlConvert.ToString(value.Value));
            }
        }

        /// <summary>
        /// Writes a big-integer attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        protected static void WriteBigIntegerAttribute(XmlWriter xmlWriter, string name, BigInteger? value)
        {
            if (value.HasValue)
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString(CultureInfo.InvariantCulture));
            }
        }

        /// <summary>
        /// Writes a date-time attribute when present, in round-trippable ISO-8601.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        protected static void WriteDateTimeAttribute(XmlWriter xmlWriter, string name, DateTime? value)
        {
            if (value.HasValue)
            {
                xmlWriter.WriteAttributeString(name, XmlConvert.ToString(value.Value, XmlDateTimeSerializationMode.RoundtripKind));
            }
        }

        /// <summary>
        /// Writes a character attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteCharAttribute(XmlWriter xmlWriter, string name, char? value, char? defaultValue = null)
        {
            if (value.HasValue && value != defaultValue)
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString());
            }
        }

        /// <summary>
        /// Writes a whitespace-delimited list of a multi-valued string attribute when non-empty.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="values">the values</param>
        protected static void WriteStringListAttribute(XmlWriter xmlWriter, string name, IEnumerable<string>? values)
        {
            if (values == null)
            {
                return;
            }

            var joined = string.Join(" ", values);
            if (joined.Length > 0)
            {
                xmlWriter.WriteAttributeString(name, joined);
            }
        }

        /// <summary>
        /// Writes a multi-valued enumeration attribute as a whitespace-delimited list of literal names when
        /// non-empty (the inverse of the reader's multi-valued enum parse).
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="values">the enumeration values</param>
        /// <param name="toLiteralString">the generated provider's <c>ToLiteralString</c>, which maps each value to its Ecore literal name</param>
        protected static void WriteEnumListAttribute<TEnum>(XmlWriter xmlWriter, string name, IEnumerable<TEnum>? values, Func<TEnum, string> toLiteralString)
            where TEnum : struct
        {
            if (values == null)
            {
                return;
            }

            var joined = string.Join(" ", values.Select(toLiteralString));
            if (joined.Length > 0)
            {
                xmlWriter.WriteAttributeString(name, joined);
            }
        }

        /// <summary>
        /// Writes the attributes the reader could not interpret, verbatim, after the modeled ones — the
        /// attributes of a package Auriga does not vendor, which would otherwise be lost on write
        ///.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose uninterpreted attributes to write</param>
        protected static void WriteUninterpretedAttributes(XmlWriter xmlWriter, IAurigaElement poco)
        {
            foreach (var attribute in poco.UninterpretedAttributes)
            {
                var separator = attribute.Name.IndexOf(':');

                if (separator < 0 || string.IsNullOrEmpty(attribute.NamespaceUri))
                {
                    xmlWriter.WriteAttributeString(attribute.Name, attribute.Value);
                    continue;
                }

                // A prefixed attribute keeps its prefix and its namespace; the writer declares the prefix
                // when the document does not already, which is the common case here — the package is
                // uninterpreted precisely because Auriga does not vendor it.
                xmlWriter.WriteAttributeString(
                    attribute.Name.Substring(0, separator),
                    attribute.Name.Substring(separator + 1),
                    attribute.NamespaceUri,
                    attribute.Value);
            }
        }

        /// <summary>
        /// Writes the child elements the reader could not interpret, verbatim, after the modeled children.
        /// The captured text carries the namespace declarations it needs, so it stands alone regardless of
        /// what the surrounding document declares.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose uninterpreted content to write</param>
        protected static void WriteUninterpretedContent(XmlWriter xmlWriter, IAurigaElement poco)
        {
            foreach (var content in poco.UninterpretedContent)
            {
                xmlWriter.WriteRaw(content);
            }
        }

        /// <summary>
        /// Writes a multi-valued simple attribute as one child element per value — the form EMF uses for a
        /// multi-valued <c>EAttribute</c> (e.g. a <c>DAnalysis</c>'s <c>semanticResources</c>), and the only
        /// form the Capella and Sirius files in circulation use. An empty value is still written, because
        /// EMF distinguishes an empty entry from an absent one.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML element name of the feature</param>
        /// <param name="values">the values, one child element each</param>
        protected static void WriteStringListElements(XmlWriter xmlWriter, string name, IEnumerable<string>? values)
        {
            if (values == null)
            {
                return;
            }

            foreach (var value in values)
            {
                xmlWriter.WriteElementString(name, value ?? string.Empty);
            }
        }

        /// <summary>
        /// Writes a multi-valued primitive attribute as one child element per value, formatted
        /// culture-invariantly (and, for a boolean, in the XML <c>true</c>/<c>false</c> spelling rather
        /// than .NET's <c>True</c>/<c>False</c>) — e.g. a <c>DDiagramElement</c>'s <c>hiddenLabels</c>.
        /// </summary>
        /// <typeparam name="TValue">the primitive value type</typeparam>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML element name of the feature</param>
        /// <param name="values">the values, one child element each</param>
        protected static void WritePrimitiveListElements<TValue>(XmlWriter xmlWriter, string name, IEnumerable<TValue>? values)
            where TValue : struct
        {
            if (values == null)
            {
                return;
            }

            foreach (var value in values)
            {
                // bool is not IFormattable, and its .NET spelling ('True') is not the XML one.
                var text = value switch
                {
                    bool flag => XmlConvert.ToString(flag),
                    IFormattable formattable => formattable.ToString(null, CultureInfo.InvariantCulture),
                    _ => value.ToString()!,
                };

                xmlWriter.WriteElementString(name, text);
            }
        }

        /// <summary>
        /// Writes a multi-valued enumeration attribute as one child element per literal — the element form
        /// EMF uses for a multi-valued <c>EAttribute</c> whose type is an <c>EEnum</c> (e.g. a
        /// <c>DDiagramElement</c>'s <c>arrangeConstraints</c>).
        /// </summary>
        /// <typeparam name="TEnum">the enumeration type</typeparam>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML element name of the feature</param>
        /// <param name="values">the enumeration values, one child element each</param>
        /// <param name="toLiteralString">the generated provider's <c>ToLiteralString</c>, which maps each value to its Ecore literal name</param>
        protected static void WriteEnumListElements<TEnum>(XmlWriter xmlWriter, string name, IEnumerable<TEnum>? values, Func<TEnum, string> toLiteralString)
            where TEnum : struct
        {
            if (values == null)
            {
                return;
            }

            foreach (var value in values)
            {
                xmlWriter.WriteElementString(name, toLiteralString(value));
            }
        }

        /// <summary>
        /// Writes a single-valued non-containment reference as an <c>#id</c> (or cross-document
        /// <c>href</c>) attribute. Prefers the resolved target; falls back to the raw identifier collected
        /// on read for a reference that never resolved.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="target">the resolved reference target, or <c>null</c></param>
        /// <param name="owner">the element that owns the reference (source of the fallback identifier)</param>
        /// <param name="propertyName">the PascalCase reference property name</param>
        /// <param name="context">the write context</param>
        protected static void WriteReferenceAttribute(XmlWriter xmlWriter, string name, IAurigaElement? target, IAurigaElement owner, string propertyName, IXmiWriteContext context)
        {
            // Prefer the reference token collected on read: it is the verbatim original (including a
            // cross-document path and, for a genuinely external target, the unresolved reference), so
            // writing it round-trips faithfully. The resolved target is the fallback for an element built
            // in memory that was never read.
            if (owner.SingleValueReferencePropertyIdentifiers.TryGetValue(propertyName, out var identifier))
            {
                xmlWriter.WriteAttributeString(name, FormatIdentifier(identifier));
                return;
            }

            if (target != null)
            {
                xmlWriter.WriteAttributeString(name, Href(target, context));
            }
        }

        /// <summary>
        /// Writes a multi-valued non-containment reference as a whitespace-delimited list of <c>#id</c> (or
        /// cross-document <c>href</c>) tokens. Prefers the resolved targets; falls back to the raw
        /// identifiers collected on read when nothing resolved.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="targets">the resolved reference targets, or <c>null</c> when the feature is unset</param>
        /// <param name="owner">the element that owns the reference</param>
        /// <param name="propertyName">the PascalCase reference property name</param>
        /// <param name="context">the write context</param>
        protected static void WriteReferenceListAttribute(XmlWriter xmlWriter, string name, IEnumerable? targets, IAurigaElement owner, string propertyName, IXmiWriteContext context)
        {
            var hrefs = new List<string>();

            // Prefer the reference tokens collected on read (the verbatim originals, resolved or not); fall
            // back to the resolved targets for an element built in memory that was never read.
            if (owner.MultiValueReferencePropertyIdentifiers.TryGetValue(propertyName, out var identifiers))
            {
                foreach (var identifier in identifiers)
                {
                    hrefs.Add(FormatIdentifier(identifier));
                }
            }
            else if (targets != null)
            {
                foreach (var candidate in targets)
                {
                    if (candidate is IAurigaElement element)
                    {
                        hrefs.Add(Href(element, context));
                    }
                }
            }

            if (hrefs.Count > 0)
            {
                xmlWriter.WriteAttributeString(name, string.Join(" ", hrefs));
            }
        }

        /// <summary>
        /// Writes a single-valued containment feature: the child inline when it belongs to the current
        /// document, otherwise an <c>href</c> proxy into the document that holds it.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="roleName">the containment feature's XML name</param>
        /// <param name="child">the contained child, or <c>null</c></param>
        /// <param name="owner">the element that owns the feature</param>
        /// <param name="propertyName">the PascalCase feature property name</param>
        /// <param name="context">the write context</param>
        protected void WriteContainedElement(XmlWriter xmlWriter, string roleName, IAurigaElement? child, IAurigaElement owner, string propertyName, IXmiWriteContext context)
        {
            if (child != null)
            {
                this.WriteChild(xmlWriter, roleName, child, context);
                return;
            }

            if (owner.SingleValueReferencePropertyIdentifiers.TryGetValue(propertyName, out var identifier))
            {
                WriteProxy(xmlWriter, roleName, FormatIdentifier(identifier));
            }
        }

        /// <summary>
        /// Writes a multi-valued containment feature, each child inline when it belongs to the current
        /// document, otherwise as an <c>href</c> proxy.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="roleName">the containment feature's XML name</param>
        /// <param name="children">the contained children, or <c>null</c> when the feature is unset</param>
        /// <param name="owner">the element that owns the feature</param>
        /// <param name="propertyName">the PascalCase feature property name</param>
        /// <param name="context">the write context</param>
        protected void WriteContainedElements(XmlWriter xmlWriter, string roleName, IEnumerable? children, IAurigaElement owner, string propertyName, IXmiWriteContext context)
        {
            var any = false;

            if (children != null)
            {
                foreach (var candidate in children)
                {
                    if (candidate is IAurigaElement child)
                    {
                        this.WriteChild(xmlWriter, roleName, child, context);
                        any = true;
                    }
                }
            }

            if (!any && owner.MultiValueReferencePropertyIdentifiers.TryGetValue(propertyName, out var identifiers))
            {
                foreach (var identifier in identifiers)
                {
                    WriteProxy(xmlWriter, roleName, FormatIdentifier(identifier));
                }
            }
        }

        private void WriteChild(XmlWriter xmlWriter, string roleName, IAurigaElement child, IXmiWriteContext context)
        {
            if (IsSameDocument(child, context))
            {
                this.Facade.WriteElement(xmlWriter, child, roleName, context);
            }
            else
            {
                WriteProxy(xmlWriter, roleName, Href(child, context));
            }
        }

        private static void WriteProxy(XmlWriter xmlWriter, string roleName, string href)
        {
            xmlWriter.WriteStartElement(roleName);
            xmlWriter.WriteAttributeString("href", href);
            xmlWriter.WriteEndElement();
        }

        private static bool IsSameDocument(IAurigaElement element, IXmiWriteContext context)
        {
            return string.IsNullOrEmpty(element.SourceDocument) || element.SourceDocument == context.DocumentName;
        }

        private static string FormatIdentifier(string identifier)
        {
            // The collected identifier is either a bare intra-document id or an already-qualified
            // cross-document 'path#id'; only the former needs the leading '#' re-added.
            return identifier.IndexOf('#') >= 0 ? identifier : "#" + identifier;
        }

        private static string Href(IAurigaElement target, IXmiWriteContext context)
        {
            if (IsSameDocument(target, context))
            {
                return "#" + target.Id;
            }

            return HrefReference.Relativize(context.DocumentName, target.SourceDocument!) + "#" + target.Id;
        }
    }
}
