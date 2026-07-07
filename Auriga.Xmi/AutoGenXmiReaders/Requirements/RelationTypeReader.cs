// ------------------------------------------------------------------------------------------------
// <copyright file="RelationTypeReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>RelationType</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class RelationTypeReader : XmiElementReader<Auriga.Requirements.IRelationType>, IXmiElementReader<Auriga.Requirements.IRelationType>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RelationTypeReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public RelationTypeReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>RelationType</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Requirements.IRelationType"/></returns>
        public Auriga.Requirements.IRelationType Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Requirements.RelationType();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
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
                        case "ownedAttributes":
                        poco.OwnedAttributes.Add((Auriga.Requirements.IAttributeDefinition)this.Facade.QueryElement(xmlReader));
                        break;
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
