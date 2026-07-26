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

namespace Auriga.Xmi.Diagram.AutoGenXmiReaders.Diagram.Description.Style
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Core.Cache;
    using Auriga.Xmi.Core.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>GaugeCompositeStyleDescription</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class GaugeCompositeStyleDescriptionReader : XmiElementReader<Auriga.Diagram.Diagram.Description.Style.IGaugeCompositeStyleDescription>, IXmiElementReader<Auriga.Diagram.Diagram.Description.Style.IGaugeCompositeStyleDescription>
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
        /// The XML names of the attributes <c>GaugeCompositeStyleDescription</c> declares. An attribute outside this
        /// set is uninterpreted and is captured verbatim so a write can re-emit it (issue #127).
        /// </summary>
        private static readonly System.Collections.Generic.HashSet<string> KnownAttributes = new System.Collections.Generic.HashSet<string>(System.StringComparer.Ordinal)
        {
            "alignment",
            "borderColor",
            "borderLineStyle",
            "borderSizeComputationExpression",
            "forbiddenSides",
            "hideLabelByDefault",
            "iconPath",
            "labelAlignment",
            "labelColor",
            "labelExpression",
            "labelFormat",
            "labelPosition",
            "labelSize",
            "resizeKind",
            "showIcon",
            "sizeComputationExpression",
            "tooltipExpression",
        };

        /// <summary>
        /// Reads an <c>GaugeCompositeStyleDescription</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <param name="documentName">the document being read, relative to the model's main file</param>
        /// <param name="namespaceUri">the namespace URI in scope for the document being read</param>
        /// <returns>the populated <see cref="Auriga.Diagram.Diagram.Description.Style.IGaugeCompositeStyleDescription"/></returns>
        public Auriga.Diagram.Diagram.Description.Style.IGaugeCompositeStyleDescription Read(XmlReader xmlReader, string documentName, string namespaceUri)
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

            var poco = new Auriga.Diagram.Diagram.Description.Style.GaugeCompositeStyleDescription();

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

                // The element identity is a bare id (as Capella serializes it), an xmi:id (as GMF notation
                // does) or a uid (as the Sirius representation model does); take the first present so every
                // element is cached and its cross-references resolve regardless of the serialization.
                poco.Id = xmlReader.GetAttribute("id") ?? xmlReader.GetAttribute("id", XmiNamespace) ?? xmlReader.GetAttribute("uid");
                poco.SourceDocument = documentName;
                {
                    var raw = xmlReader.GetAttribute("alignment");
                    if (!string.IsNullOrEmpty(raw))
                    {
                        if (Auriga.Extensions.AlignmentKindProvider.TryParse(raw.AsSpan(), out var parsed))
                        {
                            poco.Alignment = parsed;
                        }
                        else
                        {
                            this.HandleUnknownEnumLiteral("AlignmentKind", "alignment", raw, xmlLineInfo);
                        }
                    }
                }
                CollectSingleValueReference(poco, "BorderColor", xmlReader.GetAttribute("borderColor"));
                {
                    var raw = xmlReader.GetAttribute("borderLineStyle");
                    if (!string.IsNullOrEmpty(raw))
                    {
                        if (Auriga.Extensions.LineStyleProvider.TryParse(raw.AsSpan(), out var parsed))
                        {
                            poco.BorderLineStyle = parsed;
                        }
                        else
                        {
                            this.HandleUnknownEnumLiteral("LineStyle", "borderLineStyle", raw, xmlLineInfo);
                        }
                    }
                }
                poco.BorderSizeComputationExpression = xmlReader.GetAttribute("borderSizeComputationExpression");
                foreach (var token in (xmlReader.GetAttribute("forbiddenSides") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Auriga.Extensions.SideProvider.TryParse(token.AsSpan(), out var parsed))
                    {
                        poco.ForbiddenSides.Add(parsed);
                    }
                    else
                    {
                        this.HandleUnknownEnumLiteral("Side", "forbiddenSides", token, xmlLineInfo);
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
                    var raw = xmlReader.GetAttribute("labelAlignment");
                    if (!string.IsNullOrEmpty(raw))
                    {
                        if (Auriga.Extensions.LabelAlignmentProvider.TryParse(raw.AsSpan(), out var parsed))
                        {
                            poco.LabelAlignment = parsed;
                        }
                        else
                        {
                            this.HandleUnknownEnumLiteral("LabelAlignment", "labelAlignment", raw, xmlLineInfo);
                        }
                    }
                }
                CollectSingleValueReference(poco, "LabelColor", xmlReader.GetAttribute("labelColor"));
                poco.LabelExpression = xmlReader.GetAttribute("labelExpression");
                foreach (var token in (xmlReader.GetAttribute("labelFormat") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries))
                {
                    if (Auriga.Extensions.FontFormatProvider.TryParse(token.AsSpan(), out var parsed))
                    {
                        poco.LabelFormat.Add(parsed);
                    }
                    else
                    {
                        this.HandleUnknownEnumLiteral("FontFormat", "labelFormat", token, xmlLineInfo);
                    }
                }
                {
                    var raw = xmlReader.GetAttribute("labelPosition");
                    if (!string.IsNullOrEmpty(raw))
                    {
                        if (Auriga.Extensions.LabelPositionProvider.TryParse(raw.AsSpan(), out var parsed))
                        {
                            poco.LabelPosition = parsed;
                        }
                        else
                        {
                            this.HandleUnknownEnumLiteral("LabelPosition", "labelPosition", raw, xmlLineInfo);
                        }
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
                    var raw = xmlReader.GetAttribute("resizeKind");
                    if (!string.IsNullOrEmpty(raw))
                    {
                        if (Auriga.Extensions.ResizeKindProvider.TryParse(raw.AsSpan(), out var parsed))
                        {
                            poco.ResizeKind = parsed;
                        }
                        else
                        {
                            this.HandleUnknownEnumLiteral("ResizeKind", "resizeKind", raw, xmlLineInfo);
                        }
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

                // Any attribute the metamodel does not declare is retained verbatim so a write can
                // re-emit it, rather than being silently dropped (issue #127).
                CaptureUninterpretedAttributes(poco, xmlReader, KnownAttributes);

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
                            case "forbiddenSides":
                            {
                                var text = ReadElementText(xmlReader);
                                if (Auriga.Extensions.SideProvider.TryParse(text.AsSpan(), out var parsed))
                                {
                                    poco.ForbiddenSides.Add(parsed);
                                }
                                else
                                {
                                    this.HandleUnknownEnumLiteral("Side", "forbiddenSides", text, xmlLineInfo);
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
                            case "labelFormat":
                            {
                                var text = ReadElementText(xmlReader);
                                if (Auriga.Extensions.FontFormatProvider.TryParse(text.AsSpan(), out var parsed))
                                {
                                    poco.LabelFormat.Add(parsed);
                                }
                                else
                                {
                                    this.HandleUnknownEnumLiteral("FontFormat", "labelFormat", text, xmlLineInfo);
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
                                    poco.Sections.Add((Auriga.Diagram.Diagram.Description.Style.IGaugeSectionDescription)this.Facade.QueryElement(xmlReader, documentName, namespaceUri));
                                }

                                break;
                            }
                            default:
                                if (this.XmiReaderSettings.UseStrictReading)
                                {
                                    throw new NotSupportedException($"GaugeCompositeStyleDescriptionReader: {xmlReader.LocalName} at line:position {xmlLineInfo?.LineNumber}:{xmlLineInfo?.LinePosition}");
                                }

                                // Not part of the metamodel — an element of a package Auriga does not
                                // vendor, say — so it is retained verbatim rather than discarded, and the
                                // writer re-emits it unchanged (issue #127).
                                this.CaptureUninterpretedElement(poco, xmlReader);
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
