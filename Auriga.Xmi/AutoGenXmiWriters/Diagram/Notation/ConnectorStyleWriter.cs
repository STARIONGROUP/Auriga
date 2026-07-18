// ------------------------------------------------------------------------------------------------
// <copyright file="ConnectorStyleWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Notation
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>ConnectorStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ConnectorStyleWriter : XmiElementWriter<Auriga.Diagram.Notation.IConnectorStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConnectorStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ConnectorStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>notation</c>) of the package that
        /// declares <c>ConnectorStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "notation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ConnectorStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ConnectorStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/gmf/runtime/1.0.3/notation</c>) of the package that declares
        /// <c>ConnectorStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/gmf/runtime/1.0.3/notation";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ConnectorStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Notation.IConnectorStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteBooleanAttribute(xmlWriter, "avoidObstructions", poco.AvoidObstructions, false);
            WriteBooleanAttribute(xmlWriter, "closestDistance", poco.ClosestDistance, false);
            WriteEnumAttribute<Auriga.Diagram.Notation.JumpLinkStatus>(xmlWriter, "jumpLinkStatus", poco.JumpLinkStatus, Auriga.Diagram.Notation.JumpLinkStatus.None);
            WriteEnumAttribute<Auriga.Diagram.Notation.JumpLinkType>(xmlWriter, "jumpLinkType", poco.JumpLinkType, Auriga.Diagram.Notation.JumpLinkType.Semicircle);
            WriteBooleanAttribute(xmlWriter, "jumpLinksReverse", poco.JumpLinksReverse, false);
            WriteIntegerAttribute(xmlWriter, "lineColor", poco.LineColor, 11579568);
            WriteIntegerAttribute(xmlWriter, "lineWidth", poco.LineWidth, -1);
            WriteIntegerAttribute(xmlWriter, "roundedBendpointsRadius", poco.RoundedBendpointsRadius, 0);
            WriteEnumAttribute<Auriga.Diagram.Notation.Routing>(xmlWriter, "routing", poco.Routing, Auriga.Diagram.Notation.Routing.Manual);
            WriteEnumAttribute<Auriga.Diagram.Notation.Smoothness>(xmlWriter, "smoothness", poco.Smoothness, Auriga.Diagram.Notation.Smoothness.None);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
