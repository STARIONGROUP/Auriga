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
    using System.Numerics;
    using System.Xml;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The abstract base from which every generated per-type XMI writer derives. It writes the shared
    /// element scaffolding (start tag, <c>xsi:type</c>, <c>id</c>) and provides the typed helpers that
    /// serialize scalar, enumeration, reference and containment features — the inverse of
    /// <c>XmiElementReader&lt;T&gt;</c>. Capella encodes non-containment references as <c>#id</c>
    /// attributes and containment as child elements carrying an <c>xsi:type</c>; a reference into another
    /// document becomes a relative <c>href</c>.
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
            xmlWriter.WriteAttributeString("xsi", "type", XsiNamespace, this.NamespacePrefix + ":" + this.TypeName);
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
        /// Writes the element's <c>id</c> attribute when present.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="element">the element</param>
        protected static void WriteId(XmlWriter xmlWriter, IAurigaElement element)
        {
            if (!string.IsNullOrEmpty(element.Id))
            {
                xmlWriter.WriteAttributeString("id", element.Id);
            }
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
        /// Writes an enumeration attribute, by its literal name, when the value is present and differs
        /// from the feature's declared default. Capella's enumeration literals are upper-case, so the
        /// C# member name round-trips verbatim.
        /// </summary>
        /// <typeparam name="TEnum">the enumeration type</typeparam>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="name">the XML attribute name</param>
        /// <param name="value">the value, or <c>null</c> to omit the attribute</param>
        /// <param name="defaultValue">the declared default the attribute is suppressed for, or <c>null</c> when the feature declares none</param>
        protected static void WriteEnumAttribute<TEnum>(XmlWriter xmlWriter, string name, TEnum? value, TEnum? defaultValue = null)
            where TEnum : struct
        {
            if (value.HasValue && !value.Equals(defaultValue))
            {
                xmlWriter.WriteAttributeString(name, value.Value.ToString());
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
        protected static void WriteEnumListAttribute<TEnum>(XmlWriter xmlWriter, string name, IEnumerable<TEnum>? values)
            where TEnum : struct
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
        protected void WriteReferenceAttribute(XmlWriter xmlWriter, string name, IAurigaElement? target, IAurigaElement owner, string propertyName, IXmiWriteContext context)
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
                xmlWriter.WriteAttributeString(name, this.Href(target, context));
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
        protected void WriteReferenceListAttribute(XmlWriter xmlWriter, string name, IEnumerable? targets, IAurigaElement owner, string propertyName, IXmiWriteContext context)
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
                        hrefs.Add(this.Href(element, context));
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
                WriteProxy(xmlWriter, roleName, this.Href(child, context));
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

        private string Href(IAurigaElement target, IXmiWriteContext context)
        {
            if (IsSameDocument(target, context))
            {
                return "#" + target.Id;
            }

            return HrefReference.Relativize(context.DocumentName, target.SourceDocument!) + "#" + target.Id;
        }
    }
}
