// ------------------------------------------------------------------------------------------------
// <copyright file="StringValueAttributeReader.cs" company="Starion Group S.A.">
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
    /// The generated XMI reader that instantiates and populates an <c>StringValueAttribute</c> from its
    /// XMI representation. Contained elements are read recursively; cross-references are collected for the
    /// reference-resolution pass.
    /// </summary>
    public class StringValueAttributeReader : XmiElementReader<Auriga.Requirements.IStringValueAttribute>, IXmiElementReader<Auriga.Requirements.IStringValueAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringValueAttributeReader"/> class.
        /// </summary>
        /// <param name="cache">the element cache</param>
        /// <param name="facade">the reader facade used to read contained elements</param>
        public StringValueAttributeReader(IXmiElementCache cache, IXmiReaderFacade facade)
            : base(cache, facade)
        {
        }

        /// <summary>
        /// Reads an <c>StringValueAttribute</c> from the element at the cursor of the supplied reader.
        /// </summary>
        /// <param name="xmlReader">the reader positioned on the element</param>
        /// <returns>the populated <see cref="Auriga.Requirements.IStringValueAttribute"/></returns>
        public Auriga.Requirements.IStringValueAttribute Read(XmlReader xmlReader)
        {
            var poco = new Auriga.Requirements.StringValueAttribute();

            xmlReader.MoveToContent();

            poco.Id = xmlReader.GetAttribute("id");
            CollectSingleValueReference(poco, "Definition", xmlReader.GetAttribute("definition"));
            poco.DefinitionProxy = xmlReader.GetAttribute("definitionProxy");
            poco.Value = xmlReader.GetAttribute("value");

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
