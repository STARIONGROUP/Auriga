// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramLinkStyleWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Notation
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DiagramLinkStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DiagramLinkStyleWriter : XmiElementWriter<Auriga.Sirius.Notation.IDiagramLinkStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramLinkStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DiagramLinkStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>notation</c>) of the package that
        /// declares <c>DiagramLinkStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "notation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DiagramLinkStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DiagramLinkStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/gmf/runtime/1.0.3/notation</c>) of the package that declares
        /// <c>DiagramLinkStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/gmf/runtime/1.0.3/notation";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DiagramLinkStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Notation.IDiagramLinkStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "diagramLink", poco.DiagramLink, poco, "DiagramLink", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
