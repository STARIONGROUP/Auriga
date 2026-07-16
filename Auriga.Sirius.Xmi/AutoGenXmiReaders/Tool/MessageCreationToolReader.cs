// ------------------------------------------------------------------------------------------------
// <copyright file="MessageCreationToolReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Xmi.AutoGenXmiReaders.Sequence.Description.Tool
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>MessageCreationTool</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class MessageCreationToolReader : XmiElementReader<Auriga.Sirius.Sequence.Description.Tool.IMessageCreationTool>, IXmiElementReader<Auriga.Sirius.Sequence.Description.Tool.IMessageCreationTool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MessageCreationToolReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public MessageCreationToolReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings settings, ILoggerFactory loggerFactory)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>MessageCreationTool</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Sirius.Sequence.Description.Tool.IMessageCreationTool"/></returns>
        public Auriga.Sirius.Sequence.Description.Tool.IMessageCreationTool Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.Sirius.Sequence.Description.Tool.MessageCreationTool();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading MessageCreationTool at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

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

                // The element identity is a bare id (as Capella serializes it), an xmi:id (as GMF notation
                // does) or a uid (as the Sirius representation model does); take the first present so every
                // element is cached and its cross-references resolve regardless of the serialization.
                poco.Id = xmlReader.GetAttribute("id") ?? xmlReader.GetAttribute("id", XmiNamespace) ?? xmlReader.GetAttribute("uid");
                poco.SourceDocument = documentName;
                poco.ConnectionStartPrecondition = xmlReader.GetAttribute("connectionStartPrecondition");
                poco.Documentation = xmlReader.GetAttribute("documentation");
                CollectMultiValueReferences(poco, "EdgeMappings", xmlReader.GetAttribute("edgeMappings"));
                poco.ElementsToSelect = xmlReader.GetAttribute("elementsToSelect");
                CollectMultiValueReferences(poco, "ExtraSourceMappings", xmlReader.GetAttribute("extraSourceMappings"));
                CollectMultiValueReferences(poco, "ExtraTargetMappings", xmlReader.GetAttribute("extraTargetMappings"));
                {
                    var raw = xmlReader.GetAttribute("forceRefresh");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.ForceRefresh = parsed;
                    }
                }
                poco.IconPath = xmlReader.GetAttribute("iconPath");
                {
                    var raw = xmlReader.GetAttribute("inverseSelectionOrder");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.InverseSelectionOrder = parsed;
                    }
                }
                poco.Label = xmlReader.GetAttribute("label");
                poco.Name = xmlReader.GetAttribute("name");
                poco.Precondition = xmlReader.GetAttribute("precondition");

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
                            case "edgeMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "EdgeMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "extraSourceMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "ExtraSourceMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "extraTargetMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "ExtraTargetMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "filters":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Filters", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Filters.Add((Auriga.Sirius.Viewpoint.Description.Tool.IToolFilterDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "finishingEndPredecessor":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "FinishingEndPredecessor", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.FinishingEndPredecessor = (Auriga.Sirius.Sequence.Description.IMessageEndVariable)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "initialOperation":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "InitialOperation", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.InitialOperation = (Auriga.Sirius.Viewpoint.Description.Tool.IInitEdgeCreationOperation)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "sourceVariable":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "SourceVariable", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.SourceVariable = (Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeCreationVariable)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "sourceViewVariable":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "SourceViewVariable", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.SourceViewVariable = (Auriga.Sirius.Diagram.Description.Tool.ISourceEdgeViewCreationVariable)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "startingEndPredecessor":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "StartingEndPredecessor", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.StartingEndPredecessor = (Auriga.Sirius.Sequence.Description.IMessageEndVariable)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "targetVariable":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "TargetVariable", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.TargetVariable = (Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeCreationVariable)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "targetViewVariable":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "TargetViewVariable", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.TargetViewVariable = (Auriga.Sirius.Diagram.Description.Tool.ITargetEdgeViewCreationVariable)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"MessageCreationToolReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by MessageCreationToolReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read MessageCreationTool but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
