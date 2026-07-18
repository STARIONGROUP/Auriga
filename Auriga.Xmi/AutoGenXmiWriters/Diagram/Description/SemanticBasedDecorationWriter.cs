// ------------------------------------------------------------------------------------------------
// <copyright file="SemanticBasedDecorationWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Viewpoint.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>SemanticBasedDecoration</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class SemanticBasedDecorationWriter : XmiElementWriter<Auriga.Diagram.Viewpoint.Description.ISemanticBasedDecoration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SemanticBasedDecorationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public SemanticBasedDecorationWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>SemanticBasedDecoration</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>SemanticBasedDecoration</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "SemanticBasedDecoration";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/1.1.0</c>) of the package that declares
        /// <c>SemanticBasedDecoration</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>SemanticBasedDecoration</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Viewpoint.Description.ISemanticBasedDecoration poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.Description.DecorationDistributionDirection>(xmlWriter, "distributionDirection", poco.DistributionDirection);
            WriteStringAttribute(xmlWriter, "domainClass", poco.DomainClass);
            WriteStringAttribute(xmlWriter, "imageExpression", poco.ImageExpression);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.Description.Position>(xmlWriter, "position", poco.Position, Auriga.Diagram.Viewpoint.Description.Position.SOUTH_WEST);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression);
            WriteStringAttribute(xmlWriter, "tooltipExpression", poco.TooltipExpression);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
