// ------------------------------------------------------------------------------------------------
// <copyright file="GroupingElementPkgReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Re
{
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>GroupingElementPkg</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class GroupingElementPkgReader : XmiElementReader<Auriga.Re.IGroupingElementPkg>, IXmiElementReader<Auriga.Re.IGroupingElementPkg>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingElementPkgReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public GroupingElementPkgReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>GroupingElementPkg</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Re.IGroupingElementPkg"/></returns>
        public Auriga.Re.IGroupingElementPkg Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Re.GroupingElementPkg();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            poco.Name = xmlReader.GetAttribute("name");

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
                        case "ownedElementPkgs":
                        poco.OwnedElementPkgs.Add((Auriga.Re.ICatalogElementPkg)this.Facade.QueryElement(xmlReader));
                        break;
                        case "ownedElements":
                        poco.OwnedElements.Add((Auriga.Re.ICatalogElement)this.Facade.QueryElement(xmlReader));
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
