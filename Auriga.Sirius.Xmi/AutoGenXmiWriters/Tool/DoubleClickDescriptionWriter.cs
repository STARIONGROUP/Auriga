// ------------------------------------------------------------------------------------------------
// <copyright file="DoubleClickDescriptionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>DoubleClickDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DoubleClickDescriptionWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.Tool.IDoubleClickDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleClickDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DoubleClickDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>tool</c>) of the package that
        /// declares <c>DoubleClickDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "tool";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DoubleClickDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DoubleClickDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/tool/1.1.0</c>) of the package that declares
        /// <c>DoubleClickDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/tool/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DoubleClickDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.Tool.IDoubleClickDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "documentation", poco.Documentation);
            WriteStringAttribute(xmlWriter, "elementsToSelect", poco.ElementsToSelect);
            WriteBooleanAttribute(xmlWriter, "forceRefresh", poco.ForceRefresh);
            WriteBooleanAttribute(xmlWriter, "inverseSelectionOrder", poco.InverseSelectionOrder);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            this.WriteReferenceListAttribute(xmlWriter, "mappings", poco.Mappings, poco, "Mappings", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteStringAttribute(xmlWriter, "precondition", poco.Precondition);
            this.WriteContainedElement(xmlWriter, "element", poco.Element, poco, "Element", context);
            this.WriteContainedElement(xmlWriter, "elementView", poco.ElementView, poco, "ElementView", context);
            this.WriteContainedElements(xmlWriter, "filters", poco.Filters, poco, "Filters", context);
            this.WriteContainedElement(xmlWriter, "initialOperation", poco.InitialOperation, poco, "InitialOperation", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
