// ------------------------------------------------------------------------------------------------
// <copyright file="ElementColumnMappingWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>ElementColumnMapping</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ElementColumnMappingWriter : XmiElementWriter<Auriga.Diagram.Table.Description.IElementColumnMapping>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ElementColumnMappingWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ElementColumnMappingWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>ElementColumnMapping</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ElementColumnMapping</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ElementColumnMapping";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/description/1.1.0</c>) of the package that declares
        /// <c>ElementColumnMapping</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ElementColumnMapping</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Table.Description.IElementColumnMapping poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "detailDescriptions", poco.DetailDescriptions, poco, "DetailDescriptions", context);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "headerLabelExpression", poco.HeaderLabelExpression);
            WriteIntegerAttribute(xmlWriter, "initialWidth", poco.InitialWidth);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceListAttribute(xmlWriter, "navigationDescriptions", poco.NavigationDescriptions, poco, "NavigationDescriptions", context);
            WriteStringAttribute(xmlWriter, "semanticCandidatesExpression", poco.SemanticCandidatesExpression);
            WriteStringAttribute(xmlWriter, "semanticElements", poco.SemanticElements);
            this.WriteContainedElements(xmlWriter, "backgroundConditionalStyle", poco.BackgroundConditionalStyle, poco, "BackgroundConditionalStyle", context);
            this.WriteContainedElements(xmlWriter, "create", poco.Create, poco, "Create", context);
            this.WriteContainedElement(xmlWriter, "defaultBackground", poco.DefaultBackground, poco, "DefaultBackground", context);
            this.WriteContainedElement(xmlWriter, "defaultForeground", poco.DefaultForeground, poco, "DefaultForeground", context);
            this.WriteContainedElement(xmlWriter, "delete", poco.Delete, poco, "Delete", context);
            this.WriteContainedElements(xmlWriter, "foregroundConditionalStyle", poco.ForegroundConditionalStyle, poco, "ForegroundConditionalStyle", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
