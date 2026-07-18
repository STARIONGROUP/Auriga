// ------------------------------------------------------------------------------------------------
// <copyright file="DEdgeWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DEdge</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DEdgeWriter : XmiElementWriter<Auriga.Diagram.Diagram.IDEdge>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DEdgeWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DEdgeWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>diagram</c>) of the package that
        /// declares <c>DEdge</c>.
        /// </summary>
        public override string NamespacePrefix => "diagram";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DEdge</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DEdge";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/1.1.0</c>) of the package that declares
        /// <c>DEdge</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DEdge</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.IDEdge poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "actualMapping", poco.ActualMapping, poco, "ActualMapping", context);
            WriteEnumListAttribute<Auriga.Diagram.Diagram.ArrangeConstraint>(xmlWriter, "arrangeConstraints", poco.ArrangeConstraints);
            WriteStringAttribute(xmlWriter, "beginLabel", poco.BeginLabel, "");
            WriteStringAttribute(xmlWriter, "endLabel", poco.EndLabel, "");
            this.WriteReferenceListAttribute(xmlWriter, "incomingEdges", poco.IncomingEdges, poco, "IncomingEdges", context);
            WriteBooleanAttribute(xmlWriter, "isFold", poco.IsFold);
            WriteBooleanAttribute(xmlWriter, "isMockEdge", poco.IsMockEdge);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            this.WriteReferenceAttribute(xmlWriter, "originalStyle", poco.OriginalStyle, poco, "OriginalStyle", context);
            this.WriteReferenceListAttribute(xmlWriter, "outgoingEdges", poco.OutgoingEdges, poco, "OutgoingEdges", context);
            this.WriteReferenceListAttribute(xmlWriter, "parentLayers", poco.ParentLayers, poco, "ParentLayers", context);
            this.WriteReferenceListAttribute(xmlWriter, "path", poco.Path, poco, "Path", context);
            WriteEnumAttribute<Auriga.Diagram.Diagram.EdgeRouting>(xmlWriter, "routingStyle", poco.RoutingStyle, Auriga.Diagram.Diagram.EdgeRouting.Straight);
            this.WriteReferenceListAttribute(xmlWriter, "semanticElements", poco.SemanticElements, poco, "SemanticElements", context);
            WriteIntegerAttribute(xmlWriter, "size", poco.Size, 1);
            this.WriteReferenceAttribute(xmlWriter, "sourceNode", poco.SourceNode, poco, "SourceNode", context);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target as Auriga.Core.IAurigaElement, poco, "Target", context);
            this.WriteReferenceAttribute(xmlWriter, "targetNode", poco.TargetNode, poco, "TargetNode", context);
            WriteStringAttribute(xmlWriter, "tooltipText", poco.TooltipText);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
            WriteBooleanAttribute(xmlWriter, "visible", poco.Visible, true);
            this.WriteContainedElements(xmlWriter, "decorations", poco.Decorations, poco, "Decorations", context);
            this.WriteContainedElements(xmlWriter, "graphicalFilters", poco.GraphicalFilters, poco, "GraphicalFilters", context);
            this.WriteContainedElement(xmlWriter, "ownedStyle", poco.OwnedStyle, poco, "OwnedStyle", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
