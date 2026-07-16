// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaIncomingRelationWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.AutoGenXmiWriters.CapellaRequirements
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CapellaIncomingRelation</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CapellaIncomingRelationWriter : XmiElementWriter<Auriga.CapellaRequirements.ICapellaIncomingRelation>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapellaIncomingRelationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CapellaIncomingRelationWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>CapellaRequirements</c>) of the package that
        /// declares <c>CapellaIncomingRelation</c>.
        /// </summary>
        public override string NamespacePrefix => "CapellaRequirements";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CapellaIncomingRelation</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CapellaIncomingRelation";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/requirements</c>) of the package that declares
        /// <c>CapellaIncomingRelation</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/requirements";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CapellaIncomingRelation</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.CapellaRequirements.ICapellaIncomingRelation poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "relationType", poco.RelationType, poco, "RelationType", context);
            WriteStringAttribute(xmlWriter, "relationTypeProxy", poco.RelationTypeProxy);
            WriteStringAttribute(xmlWriter, "ReqIFDescription", poco.ReqIFDescription);
            WriteStringAttribute(xmlWriter, "ReqIFIdentifier", poco.ReqIFIdentifier);
            WriteStringAttribute(xmlWriter, "ReqIFLongName", poco.ReqIFLongName);
            this.WriteReferenceAttribute(xmlWriter, "source", poco.Source, poco, "Source", context);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target, poco, "Target", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
