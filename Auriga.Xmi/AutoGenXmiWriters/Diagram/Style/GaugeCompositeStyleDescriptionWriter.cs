// ------------------------------------------------------------------------------------------------
// <copyright file="GaugeCompositeStyleDescriptionWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram.Description.Style
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>GaugeCompositeStyleDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class GaugeCompositeStyleDescriptionWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.Style.IGaugeCompositeStyleDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GaugeCompositeStyleDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public GaugeCompositeStyleDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>style</c>) of the package that
        /// declares <c>GaugeCompositeStyleDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "style";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>GaugeCompositeStyleDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "GaugeCompositeStyleDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/style/1.1.0</c>) of the package that declares
        /// <c>GaugeCompositeStyleDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/style/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>GaugeCompositeStyleDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.Style.IGaugeCompositeStyleDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Diagram.Diagram.AlignmentKind>(xmlWriter, "alignment", poco.Alignment, Auriga.Diagram.Diagram.AlignmentKind.SQUARE);
            this.WriteReferenceAttribute(xmlWriter, "borderColor", poco.BorderColor, poco, "BorderColor", context);
            WriteEnumAttribute<Auriga.Diagram.Diagram.LineStyle>(xmlWriter, "borderLineStyle", poco.BorderLineStyle, Auriga.Diagram.Diagram.LineStyle.Solid);
            WriteStringAttribute(xmlWriter, "borderSizeComputationExpression", poco.BorderSizeComputationExpression, "0");
            WriteEnumListAttribute<Auriga.Diagram.Diagram.Description.Style.Side>(xmlWriter, "forbiddenSides", poco.ForbiddenSides);
            WriteBooleanAttribute(xmlWriter, "hideLabelByDefault", poco.HideLabelByDefault, false);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath, "");
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.LabelAlignment>(xmlWriter, "labelAlignment", poco.LabelAlignment);
            this.WriteReferenceAttribute(xmlWriter, "labelColor", poco.LabelColor, poco, "LabelColor", context);
            WriteStringAttribute(xmlWriter, "labelExpression", poco.LabelExpression, "feature:name");
            WriteEnumListAttribute<Auriga.Diagram.Viewpoint.FontFormat>(xmlWriter, "labelFormat", poco.LabelFormat);
            WriteEnumAttribute<Auriga.Diagram.Diagram.LabelPosition>(xmlWriter, "labelPosition", poco.LabelPosition, Auriga.Diagram.Diagram.LabelPosition.Border);
            WriteIntegerAttribute(xmlWriter, "labelSize", poco.LabelSize, 8);
            WriteEnumAttribute<Auriga.Diagram.Diagram.ResizeKind>(xmlWriter, "resizeKind", poco.ResizeKind, Auriga.Diagram.Diagram.ResizeKind.NONE);
            WriteBooleanAttribute(xmlWriter, "showIcon", poco.ShowIcon, true);
            WriteStringAttribute(xmlWriter, "sizeComputationExpression", poco.SizeComputationExpression, "3");
            WriteStringAttribute(xmlWriter, "tooltipExpression", poco.TooltipExpression, "");
            this.WriteContainedElements(xmlWriter, "sections", poco.Sections, poco, "Sections", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
