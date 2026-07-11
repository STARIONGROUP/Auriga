// ------------------------------------------------------------------------------------------------
// <copyright file="StandardDiagramWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Notation
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>StandardDiagram</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class StandardDiagramWriter : XmiElementWriter<Auriga.Sirius.Notation.IStandardDiagram>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StandardDiagramWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public StandardDiagramWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>notation</c>) of the package that
        /// declares <c>StandardDiagram</c>.
        /// </summary>
        public override string NamespacePrefix => "notation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>StandardDiagram</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "StandardDiagram";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/gmf/runtime/1.0.3/notation</c>) of the package that declares
        /// <c>StandardDiagram</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/gmf/runtime/1.0.3/notation";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>StandardDiagram</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Notation.IStandardDiagram poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "description", poco.Description);
            this.WriteReferenceAttribute(xmlWriter, "element", poco.Element as Auriga.IAurigaElement, poco, "Element", context);
            WriteEnumAttribute<Auriga.Sirius.Notation.MeasurementUnit>(xmlWriter, "measurementUnit", poco.MeasurementUnit);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteIntegerAttribute(xmlWriter, "pageHeight", poco.PageHeight);
            WriteIntegerAttribute(xmlWriter, "pageWidth", poco.PageWidth);
            WriteIntegerAttribute(xmlWriter, "pageX", poco.PageX);
            WriteIntegerAttribute(xmlWriter, "pageY", poco.PageY);
            WriteStringAttribute(xmlWriter, "type", poco.Type);
            WriteBooleanAttribute(xmlWriter, "visible", poco.Visible);
            this.WriteContainedElements(xmlWriter, "horizontalGuides", poco.HorizontalGuides, poco, "HorizontalGuides", context);
            this.WriteContainedElements(xmlWriter, "persistedChildren", poco.PersistedChildren, poco, "PersistedChildren", context);
            this.WriteContainedElements(xmlWriter, "persistedEdges", poco.PersistedEdges, poco, "PersistedEdges", context);
            this.WriteContainedElements(xmlWriter, "styles", poco.Styles, poco, "Styles", context);
            this.WriteContainedElements(xmlWriter, "verticalGuides", poco.VerticalGuides, poco, "VerticalGuides", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
