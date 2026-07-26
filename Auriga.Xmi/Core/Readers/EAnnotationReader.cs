// ------------------------------------------------------------------------------------------------
// <copyright file="EAnnotationReader.cs" company="Starion Group S.A.">
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
    /// The hand-written XMI reader for the inline <c>ecore:EAnnotation</c> elements EMF emits for an
    /// annotated model element — a <c>source</c>-keyed bag of <c>details</c> entries. Capella add-ons use
    /// the type as an extension point: the Requirements viewpoint stores its label and content queries in
    /// an <c>EAnnotation</c> held by a Sirius <c>DAnalysisCustomData</c> keyed
    /// <c>REQUIREMENTS_VP_QUERIES</c>, and GMF <c>Note</c> shapes carry one sourced <c>specificStyles</c>.
    /// Like the map-entry type it pairs with, <c>EAnnotation</c> is an Ecore built-in that belongs to no
    /// vendored metamodel package, so every generated reader facade routes its type key here instead of to
    /// a generated per-type reader.
    /// </summary>
    public sealed class EAnnotationReader : XmiElementReader<IEAnnotation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EAnnotationReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EAnnotationReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings? settings = null, ILoggerFactory? loggerFactory = null)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>EAnnotation</c> from the element at the cursor of the supplied reader: its identity,
        /// its <c>source</c> attribute and its contained <c>details</c> entries. A <c>details</c> child
        /// carrying an <c>href</c> is collected as an unresolved reference rather than read inline, matching
        /// the generated readers' behavior; any other child element is skipped (or rejected under strict
        /// reading).
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="IEAnnotation"/></returns>
        public IEAnnotation Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new EAnnotation();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading EAnnotation at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                poco.XsiType = xmlReader.GetAttribute("type", XsiNamespace);
                poco.XmiNamespaceUri = namespaceUri;

                poco.Id = xmlReader.GetAttribute("id") ?? xmlReader.GetAttribute("id", XmiNamespace) ?? xmlReader.GetAttribute("uid");
                poco.SourceDocument = documentName;
                poco.Source = xmlReader.GetAttribute("source");

                this.Cache.TryAdd(poco);

                if (!xmlReader.IsEmptyElement)
                {
                    while (xmlReader.Read())
                    {
                        if (xmlReader.NodeType != XmlNodeType.Element)
                        {
                            continue;
                        }

                        switch (xmlReader.LocalName)
                        {
                            case "details":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Details", href);
                                    this.SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Details.Add(this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }

                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"EAnnotationReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by EAnnotationReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                this.SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read EAnnotation but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}
