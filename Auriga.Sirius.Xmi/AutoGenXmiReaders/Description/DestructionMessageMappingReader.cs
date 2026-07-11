// ------------------------------------------------------------------------------------------------
// <copyright file="DestructionMessageMappingReader.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable disable

namespace Auriga.Sirius.Xmi.AutoGenXmiReaders.Sequence.Description
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>DestructionMessageMapping</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class DestructionMessageMappingReader : XmiElementReader<Auriga.Sirius.Sequence.Description.IDestructionMessageMapping>, IXmiElementReader<Auriga.Sirius.Sequence.Description.IDestructionMessageMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DestructionMessageMappingReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DestructionMessageMappingReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings settings, ILoggerFactory loggerFactory)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>DestructionMessageMapping</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Sirius.Sequence.Description.IDestructionMessageMapping"/></returns>
        public Auriga.Sirius.Sequence.Description.IDestructionMessageMapping Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.Sirius.Sequence.Description.DestructionMessageMapping();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading DestructionMessageMapping at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

                // The element's own namespace becomes the in-scope namespace threaded to its children. A
                // document root carries the document namespace; a nested element may narrow it.
                if (!string.IsNullOrEmpty(xmlReader.NamespaceURI))
                {
                    namespaceUri = xmlReader.NamespaceURI;
                }

                // Capture the declared xsi:type verbatim (null on a document root, whose type is fixed by
                // its element tag) as round-trip groundwork. Type-correctness is already guaranteed by the
                // facade's dispatch, so the reader does not re-validate it.
                poco.XsiType = xmlReader.GetAttribute("type", XsiNamespace);
                poco.XmiNamespaceUri = namespaceUri;

                poco.Id = xmlReader.GetAttribute("id");
                poco.SourceDocument = documentName;
                {
                    var raw = xmlReader.GetAttribute("createElements");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.CreateElements = parsed;
                    }
                }
                CollectSingleValueReference(poco, "DeletionDescription", xmlReader.GetAttribute("deletionDescription"));
                CollectMultiValueReferences(poco, "DetailDescriptions", xmlReader.GetAttribute("detailDescriptions"));
                poco.Documentation = xmlReader.GetAttribute("documentation");
                poco.DomainClass = xmlReader.GetAttribute("domainClass");
                CollectSingleValueReference(poco, "DoubleClickDescription", xmlReader.GetAttribute("doubleClickDescription"));
                poco.Label = xmlReader.GetAttribute("label");
                CollectSingleValueReference(poco, "LabelDirectEdit", xmlReader.GetAttribute("labelDirectEdit"));
                poco.Name = xmlReader.GetAttribute("name");
                CollectMultiValueReferences(poco, "NavigationDescriptions", xmlReader.GetAttribute("navigationDescriptions"));
                CollectMultiValueReferences(poco, "PasteDescriptions", xmlReader.GetAttribute("pasteDescriptions"));
                poco.PathExpression = xmlReader.GetAttribute("pathExpression");
                CollectMultiValueReferences(poco, "PathNodeMapping", xmlReader.GetAttribute("pathNodeMapping"));
                poco.PreconditionExpression = xmlReader.GetAttribute("preconditionExpression");
                poco.ReceivingEndFinderExpression = xmlReader.GetAttribute("receivingEndFinderExpression");
                CollectMultiValueReferences(poco, "Reconnections", xmlReader.GetAttribute("reconnections"));
                poco.SemanticCandidatesExpression = xmlReader.GetAttribute("semanticCandidatesExpression");
                poco.SemanticElements = xmlReader.GetAttribute("semanticElements");
                poco.SendingEndFinderExpression = xmlReader.GetAttribute("sendingEndFinderExpression");
                poco.SourceFinderExpression = xmlReader.GetAttribute("sourceFinderExpression");
                CollectMultiValueReferences(poco, "SourceMapping", xmlReader.GetAttribute("sourceMapping"));
                {
                    var raw = xmlReader.GetAttribute("synchronizationLock");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.SynchronizationLock = parsed;
                    }
                }
                poco.TargetExpression = xmlReader.GetAttribute("targetExpression");
                poco.TargetFinderExpression = xmlReader.GetAttribute("targetFinderExpression");
                CollectMultiValueReferences(poco, "TargetMapping", xmlReader.GetAttribute("targetMapping"));
                {
                    var raw = xmlReader.GetAttribute("useDomainElement");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.UseDomainElement = parsed;
                    }
                }

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
                            case "conditionnalStyles":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "ConditionnalStyles", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.ConditionnalStyles.Add((Auriga.Sirius.Diagram.Description.IConditionalEdgeStyleDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "deletionDescription":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "DeletionDescription", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "detailDescriptions":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "DetailDescriptions", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "doubleClickDescription":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "DoubleClickDescription", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "labelDirectEdit":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "LabelDirectEdit", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "navigationDescriptions":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "NavigationDescriptions", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "pasteDescriptions":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "PasteDescriptions", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "pathNodeMapping":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "PathNodeMapping", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "reconnections":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Reconnections", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "sourceMapping":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "SourceMapping", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "style":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Style", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Style = (Auriga.Sirius.Diagram.Description.Style.IEdgeStyleDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "targetMapping":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "TargetMapping", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"DestructionMessageMappingReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by DestructionMessageMappingReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read DestructionMessageMapping but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
