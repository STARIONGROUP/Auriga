// ------------------------------------------------------------------------------------------------
// <copyright file="ReconnectEdgeDescriptionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>ReconnectEdgeDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ReconnectEdgeDescriptionWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.Tool.IReconnectEdgeDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ReconnectEdgeDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ReconnectEdgeDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>ReconnectEdgeDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ReconnectEdgeDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ReconnectEdgeDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/tool/1.1.0</c>) of the package that declares
        /// <c>ReconnectEdgeDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/tool/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ReconnectEdgeDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.Tool.IReconnectEdgeDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect, "");
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh, false);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder, false);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition, "");
            WriteEnumAttribute<Auriga.Diagram.Diagram.Description.Tool.ReconnectionKind>(xmlWriter, "reconnectionKind", poco.ReconnectionKind, Auriga.Diagram.Diagram.Description.Tool.ReconnectionKind.RECONNECT_TARGET);
            this.WriteContainedElement(xmlWriter, "edgeView", poco.EdgeView, poco, "EdgeView", context);
            this.WriteContainedElement(xmlWriter, "element", poco.Element, poco, "Element", context);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
            this.WriteContainedElement(xmlWriter, "source", poco.Source, poco, "Source", context);
            this.WriteContainedElement(xmlWriter, "sourceView", poco.SourceView, poco, "SourceView", context);
            this.WriteContainedElement(xmlWriter, "target", poco.Target, poco, "Target", context);
            this.WriteContainedElement(xmlWriter, "targetView", poco.TargetView, poco, "TargetView", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
