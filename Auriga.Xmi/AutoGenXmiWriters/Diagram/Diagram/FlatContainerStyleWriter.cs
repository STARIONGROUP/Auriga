// ------------------------------------------------------------------------------------------------
// <copyright file="FlatContainerStyleWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Diagram
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>FlatContainerStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class FlatContainerStyleWriter : XmiElementWriter<Auriga.Diagram.Diagram.IFlatContainerStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FlatContainerStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public FlatContainerStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>diagram</c>) of the package that
        /// declares <c>FlatContainerStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "diagram";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>FlatContainerStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "FlatContainerStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/1.1.0</c>) of the package that declares
        /// <c>FlatContainerStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>FlatContainerStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.IFlatContainerStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "backgroundColor", poco.BackgroundColor, "255,255,255");
            WriteEnumAttribute<Auriga.Diagram.Diagram.BackgroundStyle>(xmlWriter, "backgroundStyle", poco.BackgroundStyle);
            WriteStringAttribute(xmlWriter, "borderColor", poco.BorderColor, "0,0,0");
            WriteEnumAttribute<Auriga.Diagram.Diagram.LineStyle>(xmlWriter, "borderLineStyle", poco.BorderLineStyle);
            WriteIntegerAttribute(xmlWriter, "borderSize", poco.BorderSize, 0);
            WriteStringAttribute(xmlWriter, "borderSizeComputationExpression", poco.BorderSizeComputationExpression, "0");
            WriteStringListAttribute(xmlWriter, "customFeatures", poco.CustomFeatures);
            this.WriteReferenceAttribute(xmlWriter, "description", poco.Description, poco, "Description", context);
            WriteStringAttribute(xmlWriter, "foregroundColor", poco.ForegroundColor, "209,209,209");
            WriteBooleanAttribute(xmlWriter, "hideLabelByDefault", poco.HideLabelByDefault, false);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath, "");
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.LabelAlignment>(xmlWriter, "labelAlignment", poco.LabelAlignment);
            WriteStringAttribute(xmlWriter, "labelColor", poco.LabelColor, "0,0,0");
            WriteEnumListAttribute<Auriga.Diagram.Viewpoint.FontFormat>(xmlWriter, "labelFormat", poco.LabelFormat);
            WriteIntegerAttribute(xmlWriter, "labelSize", poco.LabelSize, 8);
            WriteBooleanAttribute(xmlWriter, "showIcon", poco.ShowIcon, true);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
