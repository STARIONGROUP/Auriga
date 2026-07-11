// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramImportDescriptionReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Xmi.AutoGenXmiReaders.Diagram.Description
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>DiagramImportDescription</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class DiagramImportDescriptionReader : XmiElementReader<Auriga.Sirius.Diagram.Description.IDiagramImportDescription>, IXmiElementReader<Auriga.Sirius.Diagram.Description.IDiagramImportDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramImportDescriptionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DiagramImportDescriptionReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings settings, ILoggerFactory loggerFactory)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>DiagramImportDescription</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Sirius.Diagram.Description.IDiagramImportDescription"/></returns>
        public Auriga.Sirius.Diagram.Description.IDiagramImportDescription Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.Sirius.Diagram.Description.DiagramImportDescription();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading DiagramImportDescription at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

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
                CollectSingleValueReference(poco, "BackgroundColor", xmlReader.GetAttribute("backgroundColor"));
                CollectSingleValueReference(poco, "DefaultConcern", xmlReader.GetAttribute("defaultConcern"));
                poco.Documentation = xmlReader.GetAttribute("documentation");
                poco.DomainClass = xmlReader.GetAttribute("domainClass");
                CollectMultiValueReferences(poco, "DropDescriptions", xmlReader.GetAttribute("dropDescriptions"));
                {
                    var raw = xmlReader.GetAttribute("enablePopupBars");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.EnablePopupBars = parsed;
                    }
                }
                poco.EndUserDocumentation = xmlReader.GetAttribute("endUserDocumentation");
                CollectSingleValueReference(poco, "ImportedDiagram", xmlReader.GetAttribute("importedDiagram"));
                CollectSingleValueReference(poco, "Init", xmlReader.GetAttribute("init"));
                {
                    var raw = xmlReader.GetAttribute("initialisation");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.Initialisation = parsed;
                    }
                }
                poco.Label = xmlReader.GetAttribute("label");
                CollectMultiValueReferences(poco, "Metamodel", xmlReader.GetAttribute("metamodel"));
                poco.Name = xmlReader.GetAttribute("name");
                CollectMultiValueReferences(poco, "PasteDescriptions", xmlReader.GetAttribute("pasteDescriptions"));
                poco.PreconditionExpression = xmlReader.GetAttribute("preconditionExpression");
                CollectMultiValueReferences(poco, "ReusedMappings", xmlReader.GetAttribute("reusedMappings"));
                CollectMultiValueReferences(poco, "ReusedTools", xmlReader.GetAttribute("reusedTools"));
                poco.RootExpression = xmlReader.GetAttribute("rootExpression");
                {
                    var raw = xmlReader.GetAttribute("showOnStartup");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.ShowOnStartup = parsed;
                    }
                }
                poco.TitleExpression = xmlReader.GetAttribute("titleExpression");

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
                            case "additionalLayers":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "AdditionalLayers", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.AdditionalLayers.Add((Auriga.Sirius.Diagram.Description.IAdditionalLayer)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "backgroundColor":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "BackgroundColor", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "concerns":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Concerns", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Concerns = (Auriga.Sirius.Diagram.Description.Concern.IConcernSet)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "containerMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "ContainerMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.ContainerMappings.Add((Auriga.Sirius.Diagram.Description.IContainerMapping)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "defaultConcern":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "DefaultConcern", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "defaultLayer":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "DefaultLayer", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.DefaultLayer = (Auriga.Sirius.Diagram.Description.ILayer)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "diagramInitialisation":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "DiagramInitialisation", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.DiagramInitialisation = (Auriga.Sirius.Viewpoint.Description.Tool.IInitialOperation)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "dropDescriptions":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "DropDescriptions", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "edgeMappingImports":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "EdgeMappingImports", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.EdgeMappingImports.Add((Auriga.Sirius.Diagram.Description.IEdgeMappingImport)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
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
                                    poco.EdgeMappings.Add((Auriga.Sirius.Diagram.Description.IEdgeMapping)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                                    poco.Filters.Add((Auriga.Sirius.Diagram.Description.Filter.IFilterDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            case "importedDiagram":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "ImportedDiagram", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "init":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Init", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "layout":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "Layout", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Layout = (Auriga.Sirius.Diagram.Description.ILayout)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "metamodel":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Metamodel", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "nodeMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "NodeMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.NodeMappings.Add((Auriga.Sirius.Diagram.Description.INodeMapping)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
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
                            case "reusedMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "ReusedMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "reusedTools":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "ReusedTools", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "toolSection":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "ToolSection", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.ToolSection = (Auriga.Sirius.Diagram.Description.Tool.IToolSection)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "validationSet":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "ValidationSet", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.ValidationSet = (Auriga.Sirius.Viewpoint.Description.Validation.IValidationSet)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"DiagramImportDescriptionReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by DiagramImportDescriptionReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read DiagramImportDescription but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
