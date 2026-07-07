// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElementLinkReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>CatalogElementLink</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class CatalogElementLinkReader : XmiElementReader<Auriga.Re.ICatalogElementLink>, IXmiElementReader<Auriga.Re.ICatalogElementLink>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogElementLinkReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public CatalogElementLinkReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>CatalogElementLink</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Re.ICatalogElementLink"/></returns>
        public Auriga.Re.ICatalogElementLink Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Re.CatalogElementLink();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectSingleValueReference(poco, "Origin", xmlReader.GetAttribute("origin"));
            CollectSingleValueReference(poco, "Source", xmlReader.GetAttribute("source"));
            { var raw = xmlReader.GetAttribute("suffixed"); if (!string.IsNullOrEmpty(raw) && bool.TryParse(raw, out var parsed)) { poco.Suffixed = parsed; } }
            CollectSingleValueReference(poco, "Target", xmlReader.GetAttribute("target"));
            foreach (var token in (xmlReader.GetAttribute("unsynchronizedFeatures") ?? string.Empty).Split(WhitespaceSeparator, System.StringSplitOptions.RemoveEmptyEntries)) { poco.UnsynchronizedFeatures.Add(token); }

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
