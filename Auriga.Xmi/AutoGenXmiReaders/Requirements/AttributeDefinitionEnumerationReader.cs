// ------------------------------------------------------------------------------------------------
// <copyright file="AttributeDefinitionEnumerationReader.cs" company="Starion Group S.A.">
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
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>AttributeDefinitionEnumeration</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class AttributeDefinitionEnumerationReader : XmiElementReader<Auriga.Requirements.IAttributeDefinitionEnumeration>, IXmiElementReader<Auriga.Requirements.IAttributeDefinitionEnumeration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeDefinitionEnumerationReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public AttributeDefinitionEnumerationReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>AttributeDefinitionEnumeration</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Requirements.IAttributeDefinitionEnumeration"/></returns>
        public Auriga.Requirements.IAttributeDefinitionEnumeration Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Requirements.AttributeDefinitionEnumeration();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectSingleValueReference(poco, "DefinitionType", xmlReader.GetAttribute("definitionType"));
            { var raw = xmlReader.GetAttribute("multiValued"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.MultiValued = parsed; } }
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
                        var contained = (Auriga.Requirements.IAttribute)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.DefaultValue = contained;
                        break;
                    }
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        default:
                            SkipElement(xmlReader);
                            break;
                    }
                }
            }

            return poco;
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
