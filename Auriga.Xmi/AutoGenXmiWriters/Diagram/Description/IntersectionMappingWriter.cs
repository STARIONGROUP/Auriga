// ------------------------------------------------------------------------------------------------
// <copyright file="IntersectionMappingWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Table.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>IntersectionMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class IntersectionMappingWriter : XmiElementWriter<Auriga.Diagram.Table.Description.IIntersectionMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="IntersectionMappingWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public IntersectionMappingWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>IntersectionMapping</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>IntersectionMapping</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "IntersectionMapping";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/description/1.1.0</c>) of the package that declares
        /// <c>IntersectionMapping</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>IntersectionMapping</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Table.Description.IIntersectionMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "canEdit", poco.CanEdit);
            WriteStringAttribute(xmlWriter, "columnFinderExpression", poco.ColumnFinderExpression);
            this.WriteReferenceAttribute(xmlWriter, "columnMapping", poco.ColumnMapping, poco, "ColumnMapping", context);
            this.WriteReferenceListAttribute(xmlWriter, "detailDescriptions", poco.DetailDescriptions, poco, "DetailDescriptions", context);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "labelExpression", poco.LabelExpression);
            WriteStringAttribute(xmlWriter, "lineFinderExpression", poco.LineFinderExpression);
            this.WriteReferenceListAttribute(xmlWriter, "lineMapping", poco.LineMapping, poco, "LineMapping", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name, "");
            this.WriteReferenceListAttribute(xmlWriter, "navigationDescriptions", poco.NavigationDescriptions, poco, "NavigationDescriptions", context);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            WriteStringAttribute(xmlWriter, "semanticElements", poco.SemanticElements);
            WriteBooleanAttribute(xmlWriter, "useDomainClass", poco.UseDomainClass, false);
            this.WriteContainedElements(xmlWriter, "backgroundConditionalStyle", poco.BackgroundConditionalStyle, poco, "BackgroundConditionalStyle", context);
            this.WriteContainedElement(xmlWriter, "cellEditor", poco.CellEditor, poco, "CellEditor", context);
            this.WriteContainedElement(xmlWriter, "create", poco.Create, poco, "Create", context);
            this.WriteContainedElement(xmlWriter, "defaultBackground", poco.DefaultBackground, poco, "DefaultBackground", context);
            this.WriteContainedElement(xmlWriter, "defaultForeground", poco.DefaultForeground, poco, "DefaultForeground", context);
            this.WriteContainedElement(xmlWriter, "directEdit", poco.DirectEdit, poco, "DirectEdit", context);
            this.WriteContainedElements(xmlWriter, "foregroundConditionalStyle", poco.ForegroundConditionalStyle, poco, "ForegroundConditionalStyle", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
