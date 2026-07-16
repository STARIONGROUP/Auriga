// ------------------------------------------------------------------------------------------------
// <copyright file="BracketEdgeStyleDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Diagram.Description.Style
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>BracketEdgeStyleDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class BracketEdgeStyleDescriptionWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.Style.IBracketEdgeStyleDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BracketEdgeStyleDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public BracketEdgeStyleDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>style</c>) of the package that
        /// declares <c>BracketEdgeStyleDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "style";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>BracketEdgeStyleDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "BracketEdgeStyleDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/style/1.1.0</c>) of the package that declares
        /// <c>BracketEdgeStyleDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/style/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>BracketEdgeStyleDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.Style.IBracketEdgeStyleDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "centeredSourceMappings", poco.CenteredSourceMappings, poco, "CenteredSourceMappings", context);
            this.WriteReferenceListAttribute(xmlWriter, "centeredTargetMappings", poco.CenteredTargetMappings, poco, "CenteredTargetMappings", context);
            WriteEnumAttribute<Auriga.Sirius.Diagram.Description.CenteringStyle>(xmlWriter, "endsCentering", poco.EndsCentering);
            WriteEnumAttribute<Auriga.Sirius.Diagram.Description.FoldingStyle>(xmlWriter, "foldingStyle", poco.FoldingStyle);
            WriteEnumAttribute<Auriga.Sirius.Diagram.LineStyle>(xmlWriter, "lineStyle", poco.LineStyle);
            WriteEnumAttribute<Auriga.Sirius.Diagram.EdgeRouting>(xmlWriter, "routingStyle", poco.RoutingStyle);
            WriteStringAttribute(xmlWriter, "sizeComputationExpression", poco.SizeComputationExpression);
            WriteEnumAttribute<Auriga.Sirius.Diagram.EdgeArrows>(xmlWriter, "sourceArrow", poco.SourceArrow);
            this.WriteReferenceAttribute(xmlWriter, "strokeColor", poco.StrokeColor, poco, "StrokeColor", context);
            WriteEnumAttribute<Auriga.Sirius.Diagram.EdgeArrows>(xmlWriter, "targetArrow", poco.TargetArrow);
            this.WriteContainedElement(xmlWriter, "beginLabelStyleDescription", poco.BeginLabelStyleDescription, poco, "BeginLabelStyleDescription", context);
            this.WriteContainedElement(xmlWriter, "centerLabelStyleDescription", poco.CenterLabelStyleDescription, poco, "CenterLabelStyleDescription", context);
            this.WriteContainedElement(xmlWriter, "endLabelStyleDescription", poco.EndLabelStyleDescription, poco, "EndLabelStyleDescription", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
