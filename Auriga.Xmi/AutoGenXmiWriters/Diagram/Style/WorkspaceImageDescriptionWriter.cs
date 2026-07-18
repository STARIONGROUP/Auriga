// ------------------------------------------------------------------------------------------------
// <copyright file="WorkspaceImageDescriptionWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>WorkspaceImageDescription</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class WorkspaceImageDescriptionWriter : XmiElementWriter<Auriga.Diagram.Diagram.Description.Style.IWorkspaceImageDescription>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkspaceImageDescriptionWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public WorkspaceImageDescriptionWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>style</c>) of the package that
        /// declares <c>WorkspaceImageDescription</c>.
        /// </summary>
        public override string NamespacePrefix => "style";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>WorkspaceImageDescription</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "WorkspaceImageDescription";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/description/style/1.1.0</c>) of the package that declares
        /// <c>WorkspaceImageDescription</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/description/style/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>WorkspaceImageDescription</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.Description.Style.IWorkspaceImageDescription poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteIntegerAttribute(xmlWriter, "arcHeight", poco.ArcHeight, 10);
            WriteIntegerAttribute(xmlWriter, "arcWidth", poco.ArcWidth, 10);
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
            WriteBooleanAttribute(xmlWriter, "roundedCorner", poco.RoundedCorner);
            WriteBooleanAttribute(xmlWriter, "showIcon", poco.ShowIcon, true);
            WriteStringAttribute(xmlWriter, "sizeComputationExpression", poco.SizeComputationExpression, "3");
            WriteStringAttribute(xmlWriter, "tooltipExpression", poco.TooltipExpression, "");
            WriteStringAttribute(xmlWriter, "workspacePath", poco.WorkspacePath);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
