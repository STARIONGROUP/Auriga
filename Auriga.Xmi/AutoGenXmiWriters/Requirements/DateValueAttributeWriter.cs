// ------------------------------------------------------------------------------------------------
// <copyright file="DateValueAttributeWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

#nullable enable

namespace Auriga.Xmi.AutoGenXmiWriters.Requirements
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DateValueAttribute</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DateValueAttributeWriter : XmiElementWriter<Auriga.Requirements.IDateValueAttribute>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DateValueAttributeWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DateValueAttributeWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>Requirements</c>) of the package that
        /// declares <c>DateValueAttribute</c>.
        /// </summary>
        public override string NamespacePrefix => "Requirements";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DateValueAttribute</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DateValueAttribute";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/kitalpha/requirements</c>) of the package that declares
        /// <c>DateValueAttribute</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/kitalpha/requirements";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DateValueAttribute</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Requirements.IDateValueAttribute poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "definition", poco.Definition, poco, "Definition", context);
            WriteStringAttribute(xmlWriter, "definitionProxy", poco.DefinitionProxy);
            WriteDateTimeAttribute(xmlWriter, "value", poco.Value);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
