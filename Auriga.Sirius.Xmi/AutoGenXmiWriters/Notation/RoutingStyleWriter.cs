// ------------------------------------------------------------------------------------------------
// <copyright file="RoutingStyleWriter.cs" company="Starion Group S.A.">
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

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>RoutingStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class RoutingStyleWriter : XmiElementWriter<Auriga.Sirius.Notation.IRoutingStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RoutingStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public RoutingStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>notation</c>) of the package that
        /// declares <c>RoutingStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "notation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>RoutingStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "RoutingStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/gmf/runtime/1.0.3/notation</c>) of the package that declares
        /// <c>RoutingStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/gmf/runtime/1.0.3/notation";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>RoutingStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Notation.IRoutingStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteBooleanAttribute(xmlWriter, "avoidObstructions", poco.AvoidObstructions);
            WriteBooleanAttribute(xmlWriter, "closestDistance", poco.ClosestDistance);
            WriteEnumAttribute<Auriga.Sirius.Notation.JumpLinkStatus>(xmlWriter, "jumpLinkStatus", poco.JumpLinkStatus);
            WriteEnumAttribute<Auriga.Sirius.Notation.JumpLinkType>(xmlWriter, "jumpLinkType", poco.JumpLinkType);
            WriteBooleanAttribute(xmlWriter, "jumpLinksReverse", poco.JumpLinksReverse);
            WriteIntegerAttribute(xmlWriter, "roundedBendpointsRadius", poco.RoundedBendpointsRadius);
            WriteEnumAttribute<Auriga.Sirius.Notation.Routing>(xmlWriter, "routing", poco.Routing);
            WriteEnumAttribute<Auriga.Sirius.Notation.Smoothness>(xmlWriter, "smoothness", poco.Smoothness);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
