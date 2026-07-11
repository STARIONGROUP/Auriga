// ------------------------------------------------------------------------------------------------
// <copyright file="CapellaModuleWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>CapellaModule</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CapellaModuleWriter : XmiElementWriter<Auriga.CapellaRequirements.ICapellaModule>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CapellaModuleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CapellaModuleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>CapellaRequirements</c>) of the package that
        /// declares <c>CapellaModule</c>.
        /// </summary>
        public override string NamespacePrefix => "CapellaRequirements";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CapellaModule</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CapellaModule";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/requirements</c>) of the package that declares
        /// <c>CapellaModule</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/requirements";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CapellaModule</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.CapellaRequirements.ICapellaModule poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "moduleType", poco.ModuleType, poco, "ModuleType", context);
            WriteStringAttribute(xmlWriter, "ReqIFDescription", poco.ReqIFDescription);
            WriteStringAttribute(xmlWriter, "ReqIFIdentifier", poco.ReqIFIdentifier);
            WriteStringAttribute(xmlWriter, "ReqIFLongName", poco.ReqIFLongName);
            WriteStringAttribute(xmlWriter, "ReqIFName", poco.ReqIFName);
            WriteStringAttribute(xmlWriter, "ReqIFPrefix", poco.ReqIFPrefix);
            this.WriteContainedElements(xmlWriter, "ownedAttributes", poco.OwnedAttributes, poco, "OwnedAttributes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedRequirements", poco.OwnedRequirements, poco, "OwnedRequirements", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
