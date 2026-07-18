// ------------------------------------------------------------------------------------------------
// <copyright file="CatalogElementWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Model.AutoGenXmiWriters.Re
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CatalogElement</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CatalogElementWriter : XmiElementWriter<Auriga.Model.Re.ICatalogElement>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CatalogElementWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CatalogElementWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>re</c>) of the package that
        /// declares <c>CatalogElement</c>.
        /// </summary>
        public override string NamespacePrefix => "re";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CatalogElement</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CatalogElement";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/common/re/7.0.0</c>) of the package that declares
        /// <c>CatalogElement</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/common/re/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CatalogElement</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Model.Re.ICatalogElement poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "author", poco.Author);
            this.WriteReferenceAttribute(xmlWriter, "currentCompliancy", poco.CurrentCompliancy, poco, "CurrentCompliancy", context);
            this.WriteReferenceAttribute(xmlWriter, "defaultReplicaCompliancy", poco.DefaultReplicaCompliancy, poco, "DefaultReplicaCompliancy", context);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            WriteStringAttribute(xmlWriter, "environment", poco.Environment);
            WriteEnumAttribute<Auriga.Model.Re.CatalogElementKind>(xmlWriter, "kind", poco.Kind, Auriga.Model.Re.CatalogElementKind.REC);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceAttribute(xmlWriter, "origin", poco.Origin, poco, "Origin", context);
            WriteStringAttribute(xmlWriter, "purpose", poco.Purpose);
            WriteBooleanAttribute(xmlWriter, "readOnly", poco.ReadOnly, false);
            WriteStringAttribute(xmlWriter, "suffix", poco.Suffix);
            WriteStringListAttribute(xmlWriter, "tags", poco.Tags);
            WriteStringAttribute(xmlWriter, "version", poco.Version);
            this.WriteContainedElements(xmlWriter, "ownedElements", poco.OwnedElements, poco, "OwnedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
            this.WriteContainedElements(xmlWriter, "ownedLinks", poco.OwnedLinks, poco, "OwnedLinks", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
