// ------------------------------------------------------------------------------------------------
// <copyright file="InstanceRoleReorderToolWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>InstanceRoleReorderTool</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class InstanceRoleReorderToolWriter : XmiElementWriter<Auriga.Diagram.Sequence.Description.Tool.IInstanceRoleReorderTool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InstanceRoleReorderToolWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public InstanceRoleReorderToolWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>InstanceRoleReorderTool</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>InstanceRoleReorderTool</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "InstanceRoleReorderTool";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/sequence/description/tool/2.0.0</c>) of the package that declares
        /// <c>InstanceRoleReorderTool</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/sequence/description/tool/2.0.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>InstanceRoleReorderTool</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Sequence.Description.Tool.IInstanceRoleReorderTool poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation, "");
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect, "");
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh, false);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder, false);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceListAttribute(xmlWriter, "mappings", poco.Mappings, poco, "Mappings", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition, "");
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "instanceRoleMoved", poco.InstanceRoleMoved, poco, "InstanceRoleMoved", context);
            this.WriteContainedElement(xmlWriter, "predecessorAfter", poco.PredecessorAfter, poco, "PredecessorAfter", context);
            this.WriteContainedElement(xmlWriter, "predecessorBefore", poco.PredecessorBefore, poco, "PredecessorBefore", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
