// ------------------------------------------------------------------------------------------------
// <copyright file="EllipseNodeDescriptionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>EllipseNodeDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class EllipseNodeDescriptionWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.Style.IEllipseNodeDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EllipseNodeDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public EllipseNodeDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>style</c>) of the package that
        /// declares <c>EllipseNodeDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "style";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>EllipseNodeDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "EllipseNodeDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/style/1.1.0</c>) of the package that declares
        /// <c>EllipseNodeDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/style/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>EllipseNodeDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.Style.IEllipseNodeDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "borderColor", poco.BorderColor, poco, "BorderColor", context);
            WriteEnumAttribute<Auriga.Sirius.Diagram.LineStyle>(xmlWriter, "borderLineStyle", poco.BorderLineStyle);
            WriteStringAttribute(xmlWriter, "borderSizeComputationExpression", poco.BorderSizeComputationExpression);
            this.WriteReferenceAttribute(xmlWriter, "color", poco.Color, poco, "Color", context);
            WriteEnumListAttribute<Auriga.Sirius.Diagram.Description.Style.Side>(xmlWriter, "forbiddenSides", poco.ForbiddenSides);
            WriteBooleanAttribute(xmlWriter, "hideLabelByDefault", poco.HideLabelByDefault);
            WriteStringAttribute(xmlWriter, "horizontalDiameterComputationExpression", poco.HorizontalDiameterComputationExpression);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath);
            WriteEnumAttribute<Auriga.Sirius.Viewpoint.LabelAlignment>(xmlWriter, "labelAlignment", poco.LabelAlignment);
            this.WriteReferenceAttribute(xmlWriter, "labelColor", poco.LabelColor, poco, "LabelColor", context);
            WriteStringAttribute(xmlWriter, "labelExpression", poco.LabelExpression);
            WriteEnumListAttribute<Auriga.Sirius.Viewpoint.FontFormat>(xmlWriter, "labelFormat", poco.LabelFormat);
            WriteEnumAttribute<Auriga.Sirius.Diagram.LabelPosition>(xmlWriter, "labelPosition", poco.LabelPosition);
            WriteIntegerAttribute(xmlWriter, "labelSize", poco.LabelSize);
            WriteEnumAttribute<Auriga.Sirius.Diagram.ResizeKind>(xmlWriter, "resizeKind", poco.ResizeKind);
            WriteBooleanAttribute(xmlWriter, "showIcon", poco.ShowIcon);
            WriteStringAttribute(xmlWriter, "sizeComputationExpression", poco.SizeComputationExpression);
            WriteStringAttribute(xmlWriter, "tooltipExpression", poco.TooltipExpression);
            WriteStringAttribute(xmlWriter, "verticalDiameterComputationExpression", poco.VerticalDiameterComputationExpression);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
