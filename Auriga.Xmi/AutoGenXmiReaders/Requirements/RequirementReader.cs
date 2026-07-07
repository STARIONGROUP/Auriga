// ------------------------------------------------------------------------------------------------
// <copyright file="RequirementReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>Requirement</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class RequirementReader : XmiElementReader<Auriga.Requirements.IRequirement>, IXmiElementReader<Auriga.Requirements.IRequirement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public RequirementReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>Requirement</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Requirements.IRequirement"/></returns>
        public Auriga.Requirements.IRequirement Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Requirements.Requirement();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            poco.ReqIFChapterName = xmlReader.GetAttribute("ReqIFChapterName");
            poco.ReqIFDescription = xmlReader.GetAttribute("ReqIFDescription");
            { var raw = xmlReader.GetAttribute("ReqIFForeignID"); if (!string.IsNullOrEmpty(raw) && System.Numerics.BigInteger.TryParse(raw, System.Globalization.NumberStyles.Integer, System.Globalization.CultureInfo.InvariantCulture, out var parsed)) { poco.ReqIFForeignID = parsed; } }
            poco.ReqIFIdentifier = xmlReader.GetAttribute("ReqIFIdentifier");
            poco.ReqIFLongName = xmlReader.GetAttribute("ReqIFLongName");
            poco.ReqIFName = xmlReader.GetAttribute("ReqIFName");
            poco.ReqIFPrefix = xmlReader.GetAttribute("ReqIFPrefix");
            poco.ReqIFText = xmlReader.GetAttribute("ReqIFText");
            CollectSingleValueReference(poco, "RequirementType", xmlReader.GetAttribute("requirementType"));
            poco.RequirementTypeProxy = xmlReader.GetAttribute("requirementTypeProxy");

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
                        poco.OwnedAttributes.Add((Auriga.Requirements.IAttribute)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedExtensions":
                        poco.OwnedExtensions.Add((Auriga.Emde.IElementExtension)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedRelations":
                        poco.OwnedRelations.Add((Auriga.Requirements.IAbstractRelation)this.Facade.QueryElement(xmlReader));
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
