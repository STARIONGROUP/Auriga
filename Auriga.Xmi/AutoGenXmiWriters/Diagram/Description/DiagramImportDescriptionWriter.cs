// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramImportDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DiagramImportDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DiagramImportDescriptionWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.IDiagramImportDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramImportDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DiagramImportDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>DiagramImportDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DiagramImportDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DiagramImportDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/1.1.0</c>) of the package that declares
        /// <c>DiagramImportDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DiagramImportDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.IDiagramImportDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "backgroundColor", poco.BackgroundColor, poco, "BackgroundColor", context);
            this.WriteReferenceAttribute(xmlWriter, "defaultConcern", poco.DefaultConcern, poco, "DefaultConcern", context);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            this.WriteReferenceListAttribute(xmlWriter, "dropDescriptions", poco.DropDescriptions, poco, "DropDescriptions", context);
            WriteBooleanAttribute(xmlWriter, "enablePopupBars", poco.EnablePopupBars);
            WriteStringAttribute(xmlWriter, "endUserDocumentation", poco.EndUserDocumentation);
            this.WriteReferenceAttribute(xmlWriter, "importedDiagram", poco.ImportedDiagram, poco, "ImportedDiagram", context);
            this.WriteReferenceAttribute(xmlWriter, "init", poco.Init, poco, "Init", context);
            WriteBooleanAttribute(xmlWriter, "initialisation", poco.Initialisation);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceListAttribute(xmlWriter, "metamodel", poco.Metamodel, poco, "Metamodel", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "pasteDescriptions", poco.PasteDescriptions, poco, "PasteDescriptions", context);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression);
            this.WriteReferenceListAttribute(xmlWriter, "reusedMappings", poco.ReusedMappings, poco, "ReusedMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedTools", poco.ReusedTools, poco, "ReusedTools", context);
            WriteStringAttribute(xmlWriter, "rootExpression", poco.RootExpression);
            WriteBooleanAttribute(xmlWriter, "showOnStartup", poco.ShowOnStartup);
            WriteStringAttribute(xmlWriter, "titleExpression", poco.TitleExpression);
            this.WriteContainedElements(xmlWriter, "additionalLayers", poco.AdditionalLayers, poco, "AdditionalLayers", context);
            this.WriteContainedElement(xmlWriter, "concerns", poco.Concerns, poco, "Concerns", context);
            this.WriteContainedElements(xmlWriter, "containerMappings", poco.ContainerMappings, poco, "ContainerMappings", context);
            this.WriteContainedElement(xmlWriter, "defaultLayer", poco.DefaultLayer, poco, "DefaultLayer", context);
            this.WriteContainedElement(xmlWriter, "diagramInitialisation", poco.DiagramInitialisation, poco, "DiagramInitialisation", context);
            this.WriteContainedElements(xmlWriter, "edgeMappingImports", poco.EdgeMappingImports, poco, "EdgeMappingImports", context);
            this.WriteContainedElements(xmlWriter, "edgeMappings", poco.EdgeMappings, poco, "EdgeMappings", context);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "layout", poco.Layout, poco, "Layout", context);
            this.WriteContainedElements(xmlWriter, "nodeMappings", poco.NodeMappings, poco, "NodeMappings", context);
            this.WriteContainedElement(xmlWriter, "toolSection", poco.ToolSection, poco, "ToolSection", context);
            this.WriteContainedElement(xmlWriter, "validationSet", poco.ValidationSet, poco, "ValidationSet", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
