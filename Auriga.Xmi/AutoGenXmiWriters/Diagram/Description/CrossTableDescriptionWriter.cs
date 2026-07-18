// ------------------------------------------------------------------------------------------------
// <copyright file="CrossTableDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Table.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CrossTableDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CrossTableDescriptionWriter : XmiElementWriter<Auriga.Diagram.Table.Description.ICrossTableDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CrossTableDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CrossTableDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>CrossTableDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CrossTableDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CrossTableDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/description/1.1.0</c>) of the package that declares
        /// <c>CrossTableDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CrossTableDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Table.Description.ICrossTableDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "endUserDocumentation", poco.EndUserDocumentation, "");
            WriteIntegerAttribute(xmlWriter, "initialHeaderColumnWidth", poco.InitialHeaderColumnWidth);
            WriteBooleanAttribute(xmlWriter, "initialisation", poco.Initialisation);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceListAttribute(xmlWriter, "metamodel", poco.Metamodel, poco, "Metamodel", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression, "");
            this.WriteReferenceListAttribute(xmlWriter, "reusedCreateLine", poco.ReusedCreateLine, poco, "ReusedCreateLine", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedLineMappings", poco.ReusedLineMappings, poco, "ReusedLineMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedRepresentationCreationDescriptions", poco.ReusedRepresentationCreationDescriptions, poco, "ReusedRepresentationCreationDescriptions", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedRepresentationNavigationDescriptions", poco.ReusedRepresentationNavigationDescriptions, poco, "ReusedRepresentationNavigationDescriptions", context);
            WriteBooleanAttribute(xmlWriter, "showOnStartup", poco.ShowOnStartup);
            WriteStringAttribute(xmlWriter, "titleExpression", poco.TitleExpression, "");
            this.WriteContainedElements(xmlWriter, "createColumn", poco.CreateColumn, poco, "CreateColumn", context);
            this.WriteContainedElements(xmlWriter, "importedElements", poco.ImportedElements, poco, "ImportedElements", context);
            this.WriteContainedElements(xmlWriter, "intersection", poco.Intersection, poco, "Intersection", context);
            this.WriteContainedElements(xmlWriter, "ownedColumnMappings", poco.OwnedColumnMappings, poco, "OwnedColumnMappings", context);
            this.WriteContainedElements(xmlWriter, "ownedCreateLine", poco.OwnedCreateLine, poco, "OwnedCreateLine", context);
            this.WriteContainedElements(xmlWriter, "ownedLineMappings", poco.OwnedLineMappings, poco, "OwnedLineMappings", context);
            this.WriteContainedElements(xmlWriter, "ownedRepresentationCreationDescriptions", poco.OwnedRepresentationCreationDescriptions, poco, "OwnedRepresentationCreationDescriptions", context);
            this.WriteContainedElements(xmlWriter, "ownedRepresentationNavigationDescriptions", poco.OwnedRepresentationNavigationDescriptions, poco, "OwnedRepresentationNavigationDescriptions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
