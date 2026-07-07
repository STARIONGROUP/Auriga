// ------------------------------------------------------------------------------------------------
// <copyright file="AttributeDefinitionReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Requirements
{
    using System;
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>AttributeDefinition</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class AttributeDefinitionReader : XmiElementReader<Auriga.Requirements.IAttributeDefinition>, IXmiElementReader<Auriga.Requirements.IAttributeDefinition>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeDefinitionReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public AttributeDefinitionReader(IXmiElementCache cache, IXmiReaderFacade facade, ILoggerFactory loggerFactory)
            : base(cache, facade, loggerFactory)
        {
        }

        /// <summary>
        /// Reads an <c>AttributeDefinition</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Requirements.IAttributeDefinition"/></returns>
        public Auriga.Requirements.IAttributeDefinition Read(XmlReader xmlReader)
        {
            if (xmlReader == null)
            {
                throw new ArgumentNullException(nameof(xmlReader));
            }

            var poco = new Auriga.Requirements.AttributeDefinition();

            var xmlLineInfo = xmlReader as IXmlLineInfo;

            if (xmlReader.MoveToContent() == XmlNodeType.Element)
            {
                poco.Id = xmlReader.GetAttribute("id");
                CollectSingleValueReference(poco, "DefinitionType", xmlReader.GetAttribute("definitionType"));
                poco.ReqIFDescription = xmlReader.GetAttribute("ReqIFDescription");
                poco.ReqIFIdentifier = xmlReader.GetAttribute("ReqIFIdentifier");
                poco.ReqIFLongName = xmlReader.GetAttribute("ReqIFLongName");

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
                            case "defaultValue":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "DefaultValue", href); SkipElement(xmlReader); }
                            else { var contained = (Auriga.Requirements.IAttribute)this.Facade.QueryElement(xmlReader); contained.Container = poco; poco.DefaultValue = contained; }
                            break;
                        }
                            case "definitionType":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectSingleValueReference(poco, "DefinitionType", href); SkipElement(xmlReader); }
                            else { SkipElement(xmlReader); }
                            break;
                        }
                            case "ownedExtensions":
                        {
                            var href = xmlReader.GetAttribute("href");
                            if (!string.IsNullOrEmpty(href)) { CollectMultiValueReferences(poco, "OwnedExtensions", href); SkipElement(xmlReader); }
                            else { poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader)); }
                            break;
                        }
                            default:
                                this.Logger.LogTrace("Skipping unmapped element '{Element}' of AttributeDefinition at line {Line}:{Position}", xmlReader.LocalName, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
                                SkipElement(xmlReader);
                                break;
                        }
                    }
                }
            }
            else
            {
                this.Logger.LogWarning("Expected an element to read AttributeDefinition but found {NodeType} at line {Line}:{Position}", xmlReader.NodeType, xmlLineInfo?.LineNumber ?? -1, xmlLineInfo?.LinePosition ?? -1);
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
