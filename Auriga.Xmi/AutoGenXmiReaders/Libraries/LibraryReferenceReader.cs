// ------------------------------------------------------------------------------------------------
// <copyright file="LibraryReferenceReader.cs" company="Starion Group S.A.">
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

namespace Auriga.Xmi.AutoGenXmiReaders.Libraries
{
    using System.Xml;

    using Auriga.Xmi.Cache;
    using Auriga.Xmi.Readers;

    /// <summary>
    /// The generated XMI reader that instantiates and populates an <c>LibraryReference</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class LibraryReferenceReader : XmiElementReader<Auriga.Libraries.ILibraryReference>, IXmiElementReader<Auriga.Libraries.ILibraryReference>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LibraryReferenceReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public LibraryReferenceReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>LibraryReference</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Libraries.ILibraryReference"/></returns>
        public Auriga.Libraries.ILibraryReference Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Libraries.LibraryReference();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            { if (TryParseEnum<Auriga.Libraries.AccessPolicy>(xmlReader.GetAttribute("accessPolicy"), out var parsed)) { poco.AccessPolicy = parsed; } }
            CollectSingleValueReference(poco, "Library", xmlReader.GetAttribute("library"));
            CollectSingleValueReference(poco, "Version", xmlReader.GetAttribute("version"));

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
