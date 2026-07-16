// ------------------------------------------------------------------------------------------------
// <copyright file="DResourceContainerWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Viewpoint
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DResourceContainer</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DResourceContainerWriter : XmiElementWriter<Auriga.Diagram.Viewpoint.IDResourceContainer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DResourceContainerWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DResourceContainerWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>viewpoint</c>) of the package that
        /// declares <c>DResourceContainer</c>.
        /// </summary>
        public override string NamespacePrefix => "viewpoint";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DResourceContainer</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DResourceContainer";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/1.1.0</c>) of the package that declares
        /// <c>DResourceContainer</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DResourceContainer</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Viewpoint.IDResourceContainer poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "path", poco.Path);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
            this.WriteContainedElements(xmlWriter, "members", poco.Members, poco, "Members", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
