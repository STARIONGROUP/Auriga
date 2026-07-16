// ------------------------------------------------------------------------------------------------
// <copyright file="BracketEdgeStyleDescriptionReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Sirius.Xmi.AutoGenXmiReaders.Diagram.Description.Style
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>BracketEdgeStyleDescription</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class BracketEdgeStyleDescriptionReader : XmiElementReader<Auriga.Sirius.Diagram.Description.Style.IBracketEdgeStyleDescription>, IXmiElementReader<Auriga.Sirius.Diagram.Description.Style.IBracketEdgeStyleDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BracketEdgeStyleDescriptionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public BracketEdgeStyleDescriptionReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings settings, ILoggerFactory loggerFactory)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>BracketEdgeStyleDescription</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Sirius.Diagram.Description.Style.IBracketEdgeStyleDescription"/></returns>
        public Auriga.Sirius.Diagram.Description.Style.IBracketEdgeStyleDescription Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.Sirius.Diagram.Description.Style.BracketEdgeStyleDescription();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading BracketEdgeStyleDescription at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

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
                CollectMultiValueReferences(poco, "CenteredSourceMappings", xmlReader.GetAttribute("centeredSourceMappings"));
                CollectMultiValueReferences(poco, "CenteredTargetMappings", xmlReader.GetAttribute("centeredTargetMappings"));
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.Description.CenteringStyle>(xmlReader.GetAttribute("endsCentering"), out var parsed))
                    {
                        poco.EndsCentering = parsed;
                    }
                }
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.Description.FoldingStyle>(xmlReader.GetAttribute("foldingStyle"), out var parsed))
                    {
                        poco.FoldingStyle = parsed;
                    }
                }
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.LineStyle>(xmlReader.GetAttribute("lineStyle"), out var parsed))
                    {
                        poco.LineStyle = parsed;
                    }
                }
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.EdgeRouting>(xmlReader.GetAttribute("routingStyle"), out var parsed))
                    {
                        poco.RoutingStyle = parsed;
                    }
                }
                poco.SizeComputationExpression = xmlReader.GetAttribute("sizeComputationExpression");
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.EdgeArrows>(xmlReader.GetAttribute("sourceArrow"), out var parsed))
                    {
                        poco.SourceArrow = parsed;
                    }
                }
                CollectSingleValueReference(poco, "StrokeColor", xmlReader.GetAttribute("strokeColor"));
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.EdgeArrows>(xmlReader.GetAttribute("targetArrow"), out var parsed))
                    {
                        poco.TargetArrow = parsed;
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
                            case "beginLabelStyleDescription":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "BeginLabelStyleDescription", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.BeginLabelStyleDescription = (Auriga.Sirius.Diagram.Description.Style.IBeginLabelStyleDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "centerLabelStyleDescription":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "CenterLabelStyleDescription", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.CenterLabelStyleDescription = (Auriga.Sirius.Diagram.Description.Style.ICenterLabelStyleDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "centeredSourceMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "CenteredSourceMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "centeredTargetMappings":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "CenteredTargetMappings", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "endLabelStyleDescription":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "EndLabelStyleDescription", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.EndLabelStyleDescription = (Auriga.Sirius.Diagram.Description.Style.IEndLabelStyleDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri);
                                }

                                break;
                            }
                            case "strokeColor":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "StrokeColor", href);
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
                                    throw new NotSupportedException($"BracketEdgeStyleDescriptionReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by BracketEdgeStyleDescriptionReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read BracketEdgeStyleDescription but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
