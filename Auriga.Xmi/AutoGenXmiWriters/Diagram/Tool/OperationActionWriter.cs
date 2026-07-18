// ------------------------------------------------------------------------------------------------
// <copyright file="OperationActionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Viewpoint.Description.Tool
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>OperationAction</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class OperationActionWriter : XmiElementWriter<Auriga.Diagram.Viewpoint.Description.Tool.IOperationAction>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="OperationActionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public OperationActionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>OperationAction</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>OperationAction</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "OperationAction";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/tool/1.1.0</c>) of the package that declares
        /// <c>OperationAction</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/tool/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>OperationAction</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Viewpoint.Description.Tool.IOperationAction poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect, "");
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh, false);
            WriteStringAttribute(xmlWriter, "icon", poco.Icon);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder, false);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition, "");
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
            this.WriteContainedElement(xmlWriter, "view", poco.View, poco, "View", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
