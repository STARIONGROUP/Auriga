// ------------------------------------------------------------------------------------------------
// <copyright file="GateCreationToolWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Sequence.Description.Tool
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>GateCreationTool</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class GateCreationToolWriter : XmiElementWriter<Auriga.Diagram.Sequence.Description.Tool.IGateCreationTool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GateCreationToolWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public GateCreationToolWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>GateCreationTool</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>GateCreationTool</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "GateCreationTool";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/description/tool/2.0.0</c>) of the package that declares
        /// <c>GateCreationTool</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/description/tool/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>GateCreationTool</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Sequence.Description.Tool.IGateCreationTool poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect, "");
            this.WriteReferenceListAttribute(xmlWriter, "extraMappings", poco.ExtraMappings, poco, "ExtraMappings", context);
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh, false);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath, "");
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder, false);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            this.WriteReferenceListAttribute(xmlWriter, "nodeMappings", poco.NodeMappings, poco, "NodeMappings", context);
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition, "");
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "finishingEndPredecessor", poco.FinishingEndPredecessor, poco, "FinishingEndPredecessor", context);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
            this.WriteContainedElement(xmlWriter, "startingEndPredecessor", poco.StartingEndPredecessor, poco, "StartingEndPredecessor", context);
            this.WriteContainedElement(xmlWriter, "variable", poco.Variable, poco, "Variable", context);
            this.WriteContainedElement(xmlWriter, "viewVariable", poco.ViewVariable, poco, "ViewVariable", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
