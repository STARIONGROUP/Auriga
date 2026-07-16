// ------------------------------------------------------------------------------------------------
// <copyright file="EdgeCreationDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram.Description.Tool
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>EdgeCreationDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class EdgeCreationDescriptionWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.Tool.IEdgeCreationDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EdgeCreationDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EdgeCreationDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>EdgeCreationDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>EdgeCreationDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "EdgeCreationDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/tool/1.1.0</c>) of the package that declares
        /// <c>EdgeCreationDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/tool/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>EdgeCreationDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.Tool.IEdgeCreationDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "connectionStartPrecondition", poco.ConnectionStartPrecondition);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            this.WriteReferenceListAttribute(xmlWriter, "edgeMappings", poco.EdgeMappings, poco, "EdgeMappings", context);
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect);
            this.WriteReferenceListAttribute(xmlWriter, "extraSourceMappings", poco.ExtraSourceMappings, poco, "ExtraSourceMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "extraTargetMappings", poco.ExtraTargetMappings, poco, "ExtraTargetMappings", context);
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
            this.WriteContainedElement(xmlWriter, "sourceVariable", poco.SourceVariable, poco, "SourceVariable", context);
            this.WriteContainedElement(xmlWriter, "sourceViewVariable", poco.SourceViewVariable, poco, "SourceViewVariable", context);
            this.WriteContainedElement(xmlWriter, "targetVariable", poco.TargetVariable, poco, "TargetVariable", context);
            this.WriteContainedElement(xmlWriter, "targetViewVariable", poco.TargetViewVariable, poco, "TargetViewVariable", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
