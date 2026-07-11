// ------------------------------------------------------------------------------------------------
// <copyright file="CreateCellToolWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Table.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>CreateCellTool</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class CreateCellToolWriter : XmiElementWriter<Auriga.Sirius.Table.Description.ICreateCellTool>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateCellToolWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public CreateCellToolWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>CreateCellTool</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>CreateCellTool</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "CreateCellTool";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/description/1.1.0</c>) of the package that declares
        /// <c>CreateCellTool</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>CreateCellTool</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Table.Description.ICreateCellTool poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect);
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceAttribute(xmlWriter, "mapping", poco.Mapping, poco, "Mapping", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "firstModelOperation", poco.FirstModelOperation, poco, "FirstModelOperation", context);
            this.WriteContainedElement(xmlWriter, "mask", poco.Mask, poco, "Mask", context);
            this.WriteContainedElements(xmlWriter, "variables", poco.Variables, poco, "Variables", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
