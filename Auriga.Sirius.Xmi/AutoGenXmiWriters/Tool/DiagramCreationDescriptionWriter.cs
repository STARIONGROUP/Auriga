// ------------------------------------------------------------------------------------------------
// <copyright file="DiagramCreationDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Diagram.Description.Tool
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DiagramCreationDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DiagramCreationDescriptionWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.Tool.IDiagramCreationDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DiagramCreationDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DiagramCreationDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>DiagramCreationDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DiagramCreationDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DiagramCreationDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/tool/1.1.0</c>) of the package that declares
        /// <c>DiagramCreationDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/tool/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DiagramCreationDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.Tool.IDiagramCreationDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "browseExpression", poco.BrowseExpression);
            this.WriteReferenceAttribute(xmlWriter, "diagramDescription", poco.DiagramDescription, poco, "DiagramDescription", context);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect);
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition);
            WriteStringAttribute(xmlWriter, "titleExpression", poco.TitleExpression);
            this.WriteContainedElement(xmlWriter, "containerViewVariable", poco.ContainerViewVariable, poco, "ContainerViewVariable", context);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
            this.WriteContainedElement(xmlWriter, "representationNameVariable", poco.RepresentationNameVariable, poco, "RepresentationNameVariable", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
