// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaOutgoingRelationReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.CapellaRequirements
{
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>CapellaOutgoingRelation</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class CapellaOutgoingRelationReader : XmiElementReader<Auriga.CapellaRequirements.ICapellaOutgoingRelation>, IXmiElementReader<Auriga.CapellaRequirements.ICapellaOutgoingRelation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapellaOutgoingRelationReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public CapellaOutgoingRelationReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>CapellaOutgoingRelation</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.CapellaRequirements.ICapellaOutgoingRelation"/></returns>
        public Auriga.CapellaRequirements.ICapellaOutgoingRelation Read(XmlReader xmlReader)
        {
            var poco = new Auriga.CapellaRequirements.CapellaOutgoingRelation();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectSingleValueReference(poco, "RelationType", xmlReader.GetAttribute("relationType"));
            poco.RelationTypeProxy = xmlReader.GetAttribute("relationTypeProxy");
            poco.ReqIFDescription = xmlReader.GetAttribute("ReqIFDescription");
            poco.ReqIFIdentifier = xmlReader.GetAttribute("ReqIFIdentifier");
            poco.ReqIFLongName = xmlReader.GetAttribute("ReqIFLongName");
            CollectSingleValueReference(poco, "Source", xmlReader.GetAttribute("source"));
            CollectSingleValueReference(poco, "Target", xmlReader.GetAttribute("target"));

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
