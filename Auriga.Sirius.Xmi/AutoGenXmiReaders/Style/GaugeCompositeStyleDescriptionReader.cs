// ------------------------------------------------------------------------------------------------
// <copyright file="GaugeCompositeStyleDescriptionReader.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>GaugeCompositeStyleDescription</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class GaugeCompositeStyleDescriptionReader : XmiElementReader<Auriga.Sirius.Diagram.Description.Style.IGaugeCompositeStyleDescription>, IXmiElementReader<Auriga.Sirius.Diagram.Description.Style.IGaugeCompositeStyleDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GaugeCompositeStyleDescriptionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="settings">the reader settings (e.g. strict vs. lenient reading)</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public GaugeCompositeStyleDescriptionReader(IXmiElementCache cache, IXmiReaderFacade facade, IXmiReaderSettings settings, ILoggerFactory loggerFactory)
            : base(cache, facade, settings, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>GaugeCompositeStyleDescription</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Sirius.Diagram.Description.Style.IGaugeCompositeStyleDescription"/></returns>
        public Auriga.Sirius.Diagram.Description.Style.IGaugeCompositeStyleDescription Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.Sirius.Diagram.Description.Style.GaugeCompositeStyleDescription();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                this.Logger.LogTrace("reading GaugeCompositeStyleDescription at line:position {LineNumber}:{LinePosition}", xmlLineInfo?.LineNumber, xmlLineInfo?.LinePosition);

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
                    if (TryParseEnum<Auriga.Sirius.Diagram.AlignmentKind>(xmlReader.GetAttribute("alignment"), out var parsed))
                    {
                        poco.Alignment = parsed;
                    }
                }
                CollectSingleValueReference(poco, "BorderColor", xmlReader.GetAttribute("borderColor"));
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.LineStyle>(xmlReader.GetAttribute("borderLineStyle"), out var parsed))
                    {
                        poco.BorderLineStyle = parsed;
                    }
                }
                poco.BorderSizeComputationExpression = xmlReader.GetAttribute("borderSizeComputationExpression");
                foreach (var token in (xmlReader.GetAttribute("forbiddenSides") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.Description.Style.Side>(token, out var parsed))
                    {
                        poco.ForbiddenSides.Add(parsed);
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("hideLabelByDefault");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.HideLabelByDefault = parsed;
                    }
                }
                poco.IconPath = xmlReader.GetAttribute("iconPath");
                {
                    if (TryParseEnum<Auriga.Sirius.Viewpoint.LabelAlignment>(xmlReader.GetAttribute("labelAlignment"), out var parsed))
                    {
                        poco.LabelAlignment = parsed;
                    }
                }
                CollectSingleValueReference(poco, "LabelColor", xmlReader.GetAttribute("labelColor"));
                poco.LabelExpression = xmlReader.GetAttribute("labelExpression");
                foreach (var token in (xmlReader.GetAttribute("labelFormat") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    if (TryParseEnum<Auriga.Sirius.Viewpoint.FontFormat>(token, out var parsed))
                    {
                        poco.LabelFormat.Add(parsed);
                    }
                }
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.LabelPosition>(xmlReader.GetAttribute("labelPosition"), out var parsed))
                    {
                        poco.LabelPosition = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("labelSize");
                    if (!string.IsNullOrEmpty(raw) && int.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed))
                    {
                        poco.LabelSize = parsed;
                    }
                }
                {
                    if (TryParseEnum<Auriga.Sirius.Diagram.ResizeKind>(xmlReader.GetAttribute("resizeKind"), out var parsed))
                    {
                        poco.ResizeKind = parsed;
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("showIcon");
                    if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed))
                    {
                        poco.ShowIcon = parsed;
                    }
                }
                poco.SizeComputationExpression = xmlReader.GetAttribute("sizeComputationExpression");
                poco.TooltipExpression = xmlReader.GetAttribute("tooltipExpression");

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
                            case "borderColor":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "BorderColor", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "labelColor":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectSingleValueReference(poco, "LabelColor", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    SkipElement(xmlReader);
                                }

                                break;
                            }
                            case "sections":
                            {
                                var href = xmlReader.GetAttribute("href");
                                if (!string.IsNullOrEmpty(href))
                                {
                                    CollectMultiValueReferences(poco, "Sections", href);
                                    SkipElement(xmlReader);
                                }
                                else
                                {
                                    poco.Sections.Add((Auriga.Sirius.Diagram.Description.Style.IGaugeSectionDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"GaugeCompositeStyleDescriptionReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                this.Logger.LogWarning("Not supported by GaugeCompositeStyleDescriptionReader: the '{LocalName}' element at line:position {LineNumber}:{LinePosition} is not part of the metamodel and was skipped", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read GaugeCompositeStyleDescription but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
