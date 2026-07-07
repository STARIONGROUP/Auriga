// ------------------------------------------------------------------------------------------------
// <copyright file="RecCatalogReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>RecCatalog</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class RecCatalogReader : XmiElementReader<Auriga.Re.IRecCatalog>, IXmiElementReader<Auriga.Re.IRecCatalog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecCatalogReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public RecCatalogReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>RecCatalog</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Re.IRecCatalog"/></returns>
        public Auriga.Re.IRecCatalog Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Re.RecCatalog();

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
                        case "ownedCompliancyDefinitionPkg":
                    {
                        var contained = (Auriga.Re.ICompliancyDefinitionPkg)this.Facade.QueryElement(xmlReader);
                        contained.Container = poco;
                        poco.OwnedCompliancyDefinitionPkg = contained;
                        break;
                    }
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
