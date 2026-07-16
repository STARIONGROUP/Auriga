// ------------------------------------------------------------------------------------------------
// <copyright file="FlatContainerStyleDescriptionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>FlatContainerStyleDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class FlatContainerStyleDescriptionWriter : XmiElementWriter<Auriga.Sirius.Diagram.Description.Style.IFlatContainerStyleDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlatContainerStyleDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public FlatContainerStyleDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>style</c>) of the package that
        /// declares <c>FlatContainerStyleDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "style";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>FlatContainerStyleDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "FlatContainerStyleDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/style/1.1.0</c>) of the package that declares
        /// <c>FlatContainerStyleDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/style/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>FlatContainerStyleDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.Description.Style.IFlatContainerStyleDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteIntegerAttribute(xmlWriter, "arcHeight", poco.ArcHeight);
            WriteIntegerAttribute(xmlWriter, "arcWidth", poco.ArcWidth);
            this.WriteReferenceAttribute(xmlWriter, "backgroundColor", poco.BackgroundColor, poco, "BackgroundColor", context);
            WriteEnumAttribute<Auriga.Sirius.Diagram.BackgroundStyle>(xmlWriter, "backgroundStyle", poco.BackgroundStyle);
            this.WriteReferenceAttribute(xmlWriter, "borderColor", poco.BorderColor, poco, "BorderColor", context);
            WriteEnumAttribute<Auriga.Sirius.Diagram.LineStyle>(xmlWriter, "borderLineStyle", poco.BorderLineStyle);
            WriteStringAttribute(xmlWriter, "borderSizeComputationExpression", poco.BorderSizeComputationExpression);
            this.WriteReferenceAttribute(xmlWriter, "foregroundColor", poco.ForegroundColor, poco, "ForegroundColor", context);
            WriteStringAttribute(xmlWriter, "heightComputationExpression", poco.HeightComputationExpression);
            WriteBooleanAttribute(xmlWriter, "hideLabelByDefault", poco.HideLabelByDefault);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath);
            WriteEnumAttribute<Auriga.Sirius.Viewpoint.LabelAlignment>(xmlWriter, "labelAlignment", poco.LabelAlignment);
            this.WriteReferenceAttribute(xmlWriter, "labelBorderStyle", poco.LabelBorderStyle, poco, "LabelBorderStyle", context);
            this.WriteReferenceAttribute(xmlWriter, "labelColor", poco.LabelColor, poco, "LabelColor", context);
            WriteStringAttribute(xmlWriter, "labelExpression", poco.LabelExpression);
            WriteEnumListAttribute<Auriga.Sirius.Viewpoint.FontFormat>(xmlWriter, "labelFormat", poco.LabelFormat);
            WriteIntegerAttribute(xmlWriter, "labelSize", poco.LabelSize);
            WriteBooleanAttribute(xmlWriter, "roundedCorner", poco.RoundedCorner);
            WriteBooleanAttribute(xmlWriter, "showIcon", poco.ShowIcon);
            WriteStringAttribute(xmlWriter, "tooltipExpression", poco.TooltipExpression);
            WriteStringAttribute(xmlWriter, "widthComputationExpression", poco.WidthComputationExpression);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
