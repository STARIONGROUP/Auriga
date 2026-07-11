// ------------------------------------------------------------------------------------------------
// <copyright file="EdgeMappingImportWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Diagram.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>EdgeMappingImport</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class EdgeMappingImportWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.IEdgeMappingImport>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeMappingImportWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EdgeMappingImportWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>EdgeMappingImport</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>EdgeMappingImport</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "EdgeMappingImport";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/1.1.0</c>) of the package that declares
        /// <c>EdgeMappingImport</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>EdgeMappingImport</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.IEdgeMappingImport poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            this.WriteReferenceAttribute(xmlWriter, "importedMapping", poco.ImportedMapping, poco, "ImportedMapping", context);
            WriteBooleanAttribute(xmlWriter, "inheritsAncestorFilters", poco.InheritsAncestorFilters);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteContainedElements(xmlWriter, "conditionnalStyles", poco.ConditionnalStyles, poco, "ConditionnalStyles", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
