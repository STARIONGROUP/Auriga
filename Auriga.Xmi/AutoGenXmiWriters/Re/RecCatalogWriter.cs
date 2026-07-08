// ------------------------------------------------------------------------------------------------
// <copyright file="RecCatalogWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.AutoGenXmiWriters.Re
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>RecCatalog</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class RecCatalogWriter : XmiElementWriter<Auriga.Re.IRecCatalog>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RecCatalogWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public RecCatalogWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>re</c>) of the package that
        /// declares <c>RecCatalog</c>.
        /// </summary>
        public override string NamespacePrefix => "re";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>RecCatalog</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "RecCatalog";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.polarsys.org/capella/common/re/7.0.0</c>) of the package that declares
        /// <c>RecCatalog</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.polarsys.org/capella/common/re/7.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>RecCatalog</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Re.IRecCatalog poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteContainedElement(xmlWriter, "ownedCompliancyDefinitionPkg", poco.OwnedCompliancyDefinitionPkg, poco, "OwnedCompliancyDefinitionPkg", context);
            this.WriteContainedElements(xmlWriter, "ownedElementPkgs", poco.OwnedElementPkgs, poco, "OwnedElementPkgs", context);
            this.WriteContainedElements(xmlWriter, "ownedElements", poco.OwnedElements, poco, "OwnedElements", context);
            this.WriteContainedElements(xmlWriter, "ownedExtensions", poco.OwnedExtensions, poco, "OwnedExtensions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
