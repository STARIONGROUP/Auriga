// ------------------------------------------------------------------------------------------------
// <copyright file="FolderReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>Folder</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class FolderReader : XmiElementReader<Auriga.Requirements.IFolder>, IXmiElementReader<Auriga.Requirements.IFolder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public FolderReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>Folder</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Requirements.IFolder"/></returns>
        public Auriga.Requirements.IFolder Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Requirements.Folder();

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
                        case "ownedRequirements":
                        poco.OwnedRequirements.Add((Auriga.Requirements.IRequirement)this.Facade.QueryElement(xmlReader));
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
