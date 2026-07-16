// ------------------------------------------------------------------------------------------------
// <copyright file="AdditionalLayerWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>AdditionalLayer</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class AdditionalLayerWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.IAdditionalLayer>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AdditionalLayerWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public AdditionalLayerWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>AdditionalLayer</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>AdditionalLayer</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "AdditionalLayer";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/1.1.0</c>) of the package that declares
        /// <c>AdditionalLayer</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>AdditionalLayer</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.IAdditionalLayer poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteBooleanAttribute(xmlWriter, "activeByDefault", poco.ActiveByDefault);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "endUserDocumentation", poco.EndUserDocumentation);
            WriteStringAttribute(xmlWriter, "icon", poco.Icon);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteBooleanAttribute(xmlWriter, "optional", poco.Optional);
            this.WriteReferenceListAttribute(xmlWriter, "reusedMappings", poco.ReusedMappings, poco, "ReusedMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "reusedTools", poco.ReusedTools, poco, "ReusedTools", context);
            this.WriteContainedElements(xmlWriter, "containerMappings", poco.ContainerMappings, poco, "ContainerMappings", context);
            this.WriteContainedElement(xmlWriter, "customization", poco.Customization, poco, "Customization", context);
            this.WriteContainedElement(xmlWriter, "decorationDescriptionsSet", poco.DecorationDescriptionsSet, poco, "DecorationDescriptionsSet", context);
            this.WriteContainedElements(xmlWriter, "edgeMappingImports", poco.EdgeMappingImports, poco, "EdgeMappingImports", context);
            this.WriteContainedElements(xmlWriter, "edgeMappings", poco.EdgeMappings, poco, "EdgeMappings", context);
            this.WriteContainedElements(xmlWriter, "nodeMappings", poco.NodeMappings, poco, "NodeMappings", context);
            this.WriteContainedElements(xmlWriter, "toolSections", poco.ToolSections, poco, "ToolSections", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
