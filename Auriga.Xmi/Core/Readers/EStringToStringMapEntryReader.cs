// ------------------------------------------------------------------------------------------------
// <copyright file="EStringToStringMapEntryReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Core.Readers
{
    using System;
    using System.Xml;

    using Auriga.Core;
    using Auriga.Xmi.Core.Cache;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The hand-written XMI reader for the inline <c>ecore:EStringToStringMapEntry</c> elements EMF
    /// emits for an <c>EMap&lt;String, String&gt;</c>-typed feature (e.g. a Sirius
    /// <c>DAnnotation</c>'s <c>details</c>). The map-entry type is an Ecore built-in that belongs to
    /// no vendored metamodel package, so every generated reader facade routes its type key here
    /// instead of to a generated per-type reader.
    /// </summary>
    public sealed class EStringToStringMapEntryReader : XmiElementReader<IEStringToStringMapEntry>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EStringToStringMapEntryReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EStringToStringMapEntryReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings? settings = null, ILoggerFactory? loggerFactory = null)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>EStringToStringMapEntry</c> from the element at the cursor of the supplied reader:
        /// its identity and its <c>key</c> / <c>value</c> attributes. A map entry carries no children of
        /// its own; any unexpected child element is skipped (or rejected under strict reading), matching
        /// the generated readers' behavior.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="IEStringToStringMapEntry"/></returns>
        public IEStringToStringMapEntry Read(XmlReader xmlReader, string documentName, string namespaceUri)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            if (string.IsNullOrEmpty(documentName))
            {
                throw new ArgumentException("The document name is required.", nameof(documentName));
            }

            if (string.IsNullOrEmpty(namespaceUri))
            {
                throw new ArgumentException("The namespace URI is required.", nameof(namespaceUri));
            }

            var poco = new EStringToStringMapEntry();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading EStringToStringMapEntry at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                poco.XsiType = xmlReader.GetAttribute("type", XsiNamespace);
                poco.XmiNamespaceUri = namespaceUri;

                poco.Id = xmlReader.GetAttribute("id") ?? xmlReader.GetAttribute("id", XmiNamespace) ?? xmlReader.GetAttribute("uid");
                poco.SourceDocument = documentName;
                poco.Key = xmlReader.GetAttribute("key");
                poco.Value = xmlReader.GetAttribute("value");

                this.Cache.TryAdd(poco);

                if (!xmlReader.IsEmptyElement)
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType != XmlNodeType.Element)
                        {
                            continue;
                        }

                        if (this.XmiReaderSettings.UseStrictReading)
                        {
                            throw new NotSupportedException($"EStringToStringMapEntryReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                        }

                        this.Logger.LogWarning("Not supported by EStringToStringMapEntryReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                        this.SkipElement(xmlReader);
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read EStringToStringMapEntry but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}
