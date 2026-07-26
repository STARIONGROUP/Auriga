// ------------------------------------------------------------------------------------------------
// <copyright file="XmiElementReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Readers
{
    using Auriga.Core;
    using System;
    using System.Collections.Generic;
    using System.Xml;

    using Auriga.Xmi.Core.Cache;

    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Logging.Abstractions;

    /// <summary>
    /// The abstract base class from which every generated per-type XMI reader derives. It holds the
    /// shared <see cref="IXmiElementCache"/> and <see cref="IXmiReaderFacade"/> and provides the helpers
    /// that collect unresolved <c>#id</c> references into the element's deferred-reference dictionaries
    /// (resolved on the reader's second pass). This is the analogue of uml4net's
    /// <c>XmiElementReader&lt;T&gt;</c>.
    /// </summary>
    /// <typeparam name="T">the type of <see cref="IAurigaElement"/> the reader produces</typeparam>
    public abstract class XmiElementReader<T>
        where T : IAurigaElement
    {
        /// <summary>
        /// The XML Schema instance namespace, in which the <c>xsi:type</c> attribute is declared.
        /// </summary>
        protected const string XsiNamespace = "http://www.w3.org/2001/XMLSchema-instance";

        /// <summary>
        /// The OMG XMI namespace, in which the <c>xmi:id</c> identifier attribute is declared (as Sirius
        /// and GMF serialize it, where Capella instead uses a bare <c>id</c>).
        /// </summary>
        protected const string XmiNamespace = "http://www.omg.org/XMI";

        /// <summary>
        /// The characters used to split a whitespace-delimited attribute value — a reference list such as
        /// <c>linkEnds</c>, or a multi-valued primitive attribute.
        /// </summary>
        protected static readonly char[] WhitespaceSeparator = { ' ', '\t', '\r', '\n' };

        /// <summary>
        /// Initializes a new instance of the <see cref="XmiElementReader{T}"/> class.
        /// </summary>
        /// <param name="cache">the cache in which every read element is registered by <c>xmi:id</c></param>
        /// <param name="facade">the facade used to read contained elements</param>
        /// <param name="settings">the reader settings, or <c>null</c> for the lenient defaults</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        protected XmiElementReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings? settings = null, ILoggerFactory? loggerFactory = null)
        {
            this.Cache = cache ?? throw new ArgumentNullException(nameof(cache));
            this.Facade = facade ?? throw new ArgumentNullException(nameof(facade));
            this.XmiReaderSettings = settings ?? new XmiReaderSettings();
            this.Logger = (loggerFactory ?? NullLoggerFactory.Instance).CreateLogger(this.GetType());
        }

        /// <summary>
        /// Gets the cache in which every read element is registered by <c>xmi:id</c>.
        /// </summary>
        protected IXmiElementCache Cache { get; }

        /// <summary>
        /// Gets the facade used to read contained elements.
        /// </summary>
        protected IXmiReaderFacade Facade { get; }

        /// <summary>
        /// Gets the settings that tune how the reader behaves (e.g. strict vs. lenient reading).
        /// </summary>
        protected IXmiReaderSettings XmiReaderSettings { get; }

        /// <summary>
        /// Gets the logger used to report unexpected content (categorized by the concrete reader type).
        /// </summary>
        protected ILogger Logger { get; }

        /// <summary>
        /// Records a single-valued cross-reference, parsed from an attribute value of the form
        /// <c>#id</c>, in the element's <see cref="IAurigaElement.SingleValueReferencePropertyIdentifiers"/>.
        /// </summary>
        /// <param name="element">the element that owns the reference</param>
        /// <param name="propertyName">the (PascalCase) name of the reference property</param>
        /// <param name="attributeValue">the raw attribute value (a single <c>#id</c>)</param>
        protected static void CollectSingleValueReference(IAurigaElement element, string propertyName, string? attributeValue)
        {
            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                return;
            }

            element.SingleValueReferencePropertyIdentifiers[propertyName] = NormalizeIdentifier(attributeValue!);
        }

        /// <summary>
        /// Records a multi-valued cross-reference, parsed from a whitespace-delimited attribute value of
        /// <c>#id</c> tokens, in the element's
        /// <see cref="IAurigaElement.MultiValueReferencePropertyIdentifiers"/>.
        /// </summary>
        /// <param name="element">the element that owns the reference</param>
        /// <param name="propertyName">the (PascalCase) name of the reference property</param>
        /// <param name="attributeValue">the raw attribute value (whitespace-delimited <c>#id</c>s)</param>
        protected static void CollectMultiValueReferences(IAurigaElement element, string propertyName, string? attributeValue)
        {
            if (string.IsNullOrWhiteSpace(attributeValue))
            {
                return;
            }

            var tokens = attributeValue!.Split(WhitespaceSeparator, StringSplitOptions.RemoveEmptyEntries);
            if (tokens.Length == 0)
            {
                return;
            }

            // Append rather than replace: a multi-valued reference may be split across several sibling
            // href-proxy elements, each collected by a separate call, in addition to any attribute form.
            if (!element.MultiValueReferencePropertyIdentifiers.TryGetValue(propertyName, out var identifiers))
            {
                identifiers = new List<string>();
                element.MultiValueReferencePropertyIdentifiers[propertyName] = identifiers;
            }

            foreach (var token in tokens)
            {
                identifiers.Add(NormalizeIdentifier(token));
            }
        }

        /// <summary>
        /// Reports an enumeration literal the generated provider did not recognize. The metamodel declares
        /// the full set of literals, so an unrecognized one means the document was written against a
        /// different metamodel version or by a tool Auriga does not model — worth surfacing rather than
        /// silently leaving the property at its default, which is what the previous case-insensitive
        /// <c>Enum.TryParse</c> did.
        /// </summary>
        /// <param name="enumName">the Ecore name of the enumeration</param>
        /// <param name="featureName">the XML name of the feature carrying the value</param>
        /// <param name="value">the unrecognized literal</param>
        /// <param name="xmlLineInfo">the line info of the element being read, when available</param>
        /// <exception cref="NotSupportedException">thrown when reading strictly</exception>
        protected void HandleUnknownEnumLiteral(string enumName, string featureName, string? value, IXmlLineInfo? xmlLineInfo)
        {
            if (this.XmiReaderSettings.UseStrictReading)
            {
                throw new NotSupportedException($"'{value}' is not a valid {enumName} literal for '{featureName}' at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
            }

            this.Logger.LogWarning("'{Value}' is not a valid {EnumName} literal for the '{FeatureName}' feature at line:position {LineNumber}:{LinePosition} and was ignored", value, enumName, featureName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
        }

        /// <summary>
        /// Fully consumes the element (and its subtree) at the cursor, leaving the reader on its end tag,
        /// so an unrecognized child element does not derail the parent's child-element loop. The skipped
        /// element is logged at <see cref="LogLevel.Trace"/> so discarded content remains diagnosable.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element to skip</param>
        /// <summary>
        /// Reads the text content of the element at the cursor and returns it, leaving the cursor on that
        /// element's end tag — the same position <see cref="SkipElement"/> leaves it in, so the caller's
        /// <c>while (xmlReader.Read())</c> loop advances to the next sibling exactly once.
        /// </summary>
        /// <remarks>
        /// This is why the read goes through <see cref="XmlReader.ReadSubtree"/> rather than calling
        /// <see cref="XmlReader.ReadElementContentAsString()"/> on the outer reader: the latter advances
        /// past the end tag to the following node, which the enclosing loop would then skip — silently
        /// dropping the next sibling. That matters here because these features are multi-valued and their
        /// child elements are consecutive siblings.
        /// </remarks>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the element's text content; empty for an empty element</returns>
        protected static string ReadElementText(XmlReader xmlReader)
        {
            using var subReader = xmlReader.ReadSubtree();
            subReader.MoveToContent();

            return subReader.ReadElementContentAsString();
        }

        /// <summary>
        /// Captures the element at the cursor and its subtree verbatim onto <paramref name="element"/>'s
        /// <see cref="IAurigaElement.UninterpretedContent"/>, leaving the cursor on its end tag — the same
        /// position <see cref="SkipElement"/> leaves it in.
        /// </summary>
        /// <remarks>
        /// This is deliberately separate from <see cref="SkipElement"/>, which is also called for a
        /// <em>known</em> feature whose child carried an <c>href</c>: that child has already been recorded
        /// as an unresolved reference and the writer re-emits it as a proxy, so capturing it too would
        /// write it twice. Only a reader's <c>default</c> branch — a child the metamodel does not declare —
        /// captures.
        ///
        /// <para><see cref="XmlReader.ReadOuterXml"/> materializes the namespace declarations the fragment
        /// needs but inherits from an ancestor, so the captured text stands alone and can be written back
        /// with <c>WriteRaw</c> into a document whose prefixes differ.</para>
        /// </remarks>
        /// <param name="element">the element that owns the uninterpreted child</param>
        /// <param name="xmlReader">the reader positioned on the element to capture</param>
        protected void CaptureUninterpretedElement(IAurigaElement element, XmlReader xmlReader)
        {
            if (this.Logger.IsEnabled(LogLevel.Debug))
            {
                var lineInfo = xmlReader as IXmlLineInfo;
                this.Logger.LogDebug("Capturing the uninterpreted '{Element}' element and its subtree at line {Line}:{Position} so a write can re-emit it", xmlReader.LocalName, lineInfo?.LineNumber ?? -1, lineInfo?.LinePosition ?? -1);
            }

            element.UninterpretedContent.Add(xmlReader.ReadOuterXml());
        }

        /// <summary>
        /// Captures every attribute of the element at the cursor that the metamodel does not declare onto
        /// <paramref name="element"/>'s <see cref="IAurigaElement.UninterpretedAttributes"/>, leaving the
        /// cursor back on the element. Namespace declarations and the identity/type attributes the writer
        /// re-emits itself are never captured.
        /// </summary>
        /// <param name="element">the element that owns the uninterpreted attributes</param>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="knownAttributes">the XML names of the attributes the element's type declares</param>
        protected static void CaptureUninterpretedAttributes(IAurigaElement element, XmlReader xmlReader, ISet<string> knownAttributes)
        {
            if (!xmlReader.HasAttributes)
            {
                return;
            }

            if (xmlReader.MoveToFirstAttribute())
            {
                do
                {
                    if (IsCapturableAttribute(xmlReader, knownAttributes))
                    {
                        element.UninterpretedAttributes.Add(new UninterpretedAttribute(xmlReader.Name, xmlReader.NamespaceURI, xmlReader.Value));
                    }
                }
                while (xmlReader.MoveToNextAttribute());

                xmlReader.MoveToElement();
            }
        }

        /// <summary>
        /// Whether the attribute at the cursor is one the writer must re-emit verbatim: not a namespace
        /// declaration, not the identity or type attribute the writer produces from the element itself, and
        /// not a feature the metamodel declares.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on an attribute</param>
        /// <param name="knownAttributes">the XML names of the attributes the element's type declares</param>
        /// <returns>true when the attribute is uninterpreted and must be captured</returns>
        private static bool IsCapturableAttribute(XmlReader xmlReader, ISet<string> knownAttributes)
        {
            if (xmlReader.Prefix == "xmlns" || xmlReader.Name == "xmlns")
            {
                return false;
            }

            if (xmlReader.NamespaceURI == XsiNamespace || xmlReader.NamespaceURI == XmiNamespace)
            {
                return false;
            }

            return xmlReader.LocalName != "id"
                   && xmlReader.LocalName != "uid"
                   && !knownAttributes.Contains(xmlReader.LocalName);
        }

        protected void SkipElement(XmlReader xmlReader)
        {
            if (this.Logger.IsEnabled(LogLevel.Trace))
            {
                var xmlLineInfo = xmlReader as IXmlLineInfo;
                this.Logger.LogTrace("Skipping the '{Element}' element and its subtree at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            using var subReader = xmlReader.ReadSubtree();
            while (subReader.Read())
            {
            }
        }

        /// <summary>
        /// Strips the leading <c>#</c> of an intra-document reference so it matches the cache key
        /// (the bare <c>xmi:id</c>). A cross-document reference (<c>document#id</c>) is left intact.
        /// </summary>
        /// <param name="reference">the raw reference token</param>
        /// <returns>the normalized identifier</returns>
        private static string NormalizeIdentifier(string reference)
        {
            return reference.StartsWith("#", StringComparison.Ordinal) ? reference.Substring(1) : reference;
        }
    }
}
