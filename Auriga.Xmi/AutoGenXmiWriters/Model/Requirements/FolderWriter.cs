// ------------------------------------------------------------------------------------------------
// <copyright file="FolderWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Requirements
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>Folder</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class FolderWriter : XmiElementWriter<Auriga.Model.Requirements.IFolder>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FolderWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public FolderWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>Requirements</c>) of the package that
        /// declares <c>Folder</c>.
        /// </summary>
        public override string NamespacePrefix => "Requirements";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>Folder</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "Folder";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/kitalpha/requirements</c>) of the package that declares
        /// <c>Folder</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/kitalpha/requirements";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>Folder</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Requirements.IFolder poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "ReqIFChapterName", poco.ReqIFChapterName);
            WriteStringAttribute(xmlWriter, "ReqIFDescription", poco.ReqIFDescription);
            WriteBigIntegerAttribute(xmlWriter, "ReqIFForeignID", poco.ReqIFForeignID);
            WriteStringAttribute(xmlWriter, "ReqIFIdentifier", poco.ReqIFIdentifier);
            WriteStringAttribute(xmlWriter, "ReqIFLongName", poco.ReqIFLongName);
            WriteStringAttribute(xmlWriter, "ReqIFName", poco.ReqIFName);
            WriteStringAttribute(xmlWriter, "ReqIFPrefix", poco.ReqIFPrefix);
            WriteStringAttribute(xmlWriter, "ReqIFText", poco.ReqIFText);
            this.WriteReferenceAttribute(xmlWriter, "requirementType", poco.RequirementType, poco, "RequirementType", context);
            WriteStringAttribute(xmlWriter, "requirementTypeProxy", poco.RequirementTypeProxy);
            this.WriteContainedElements(xmlWriter, "ownedAttributes", poco.OwnedAttributes, poco, "OwnedAttributes", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedRelations", poco.OwnedRelations, poco, "OwnedRelations", context);
            this.WriteContainedElements(xmlWriter, "ownedRequirements", poco.OwnedRequirements, poco, "OwnedRequirements", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
