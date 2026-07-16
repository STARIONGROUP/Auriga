// ------------------------------------------------------------------------------------------------
// <copyright file="MappingBasedDecorationWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram.Description
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>MappingBasedDecoration</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class MappingBasedDecorationWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.IMappingBasedDecoration>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingBasedDecorationWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public MappingBasedDecorationWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>description</c>) of the package that
        /// declares <c>MappingBasedDecoration</c>.
        /// </summary>
        public override string NamespacePrefix => "description";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>MappingBasedDecoration</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "MappingBasedDecoration";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/1.1.0</c>) of the package that declares
        /// <c>MappingBasedDecoration</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>MappingBasedDecoration</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.IMappingBasedDecoration poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.Description.DecorationDistributionDirection>(xmlWriter, "distributionDirection", poco.DistributionDirection);
            WriteStringAttribute(xmlWriter, "imageExpression", poco.ImageExpression);
            this.WriteReferenceListAttribute(xmlWriter, "mappings", poco.Mappings, poco, "Mappings", context);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.Description.Position>(xmlWriter, "position", poco.Position);
            WriteStringAttribute(xmlWriter, "preconditionExpression", poco.PreconditionExpression);
            WriteStringAttribute(xmlWriter, "tooltipExpression", poco.TooltipExpression);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
