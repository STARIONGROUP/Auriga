// ------------------------------------------------------------------------------------------------
// <copyright file="ShapeContainerStyleWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>ShapeContainerStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class ShapeContainerStyleWriter : XmiElementWriter<Auriga.Diagram.Diagram.IShapeContainerStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShapeContainerStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public ShapeContainerStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>diagram</c>) of the package that
        /// declares <c>ShapeContainerStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "diagram";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>ShapeContainerStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "ShapeContainerStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/1.1.0</c>) of the package that declares
        /// <c>ShapeContainerStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>ShapeContainerStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Diagram.IShapeContainerStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "backgroundColor", poco.BackgroundColor);
            WriteStringAttribute(xmlWriter, "borderColor", poco.BorderColor);
            WriteEnumAttribute<Auriga.Diagram.Diagram.LineStyle>(xmlWriter, "borderLineStyle", poco.BorderLineStyle);
            WriteIntegerAttribute(xmlWriter, "borderSize", poco.BorderSize);
            WriteStringAttribute(xmlWriter, "borderSizeComputationExpression", poco.BorderSizeComputationExpression);
            WriteStringListAttribute(xmlWriter, "customFeatures", poco.CustomFeatures);
            this.WriteReferenceAttribute(xmlWriter, "description", poco.Description, poco, "Description", context);
            WriteBooleanAttribute(xmlWriter, "hideLabelByDefault", poco.HideLabelByDefault);
            WriteStringAttribute(xmlWriter, "iconPath", poco.IconPath);
            WriteEnumAttribute<Auriga.Diagram.Viewpoint.LabelAlignment>(xmlWriter, "labelAlignment", poco.LabelAlignment);
            WriteStringAttribute(xmlWriter, "labelColor", poco.LabelColor);
            WriteEnumListAttribute<Auriga.Diagram.Viewpoint.FontFormat>(xmlWriter, "labelFormat", poco.LabelFormat);
            WriteIntegerAttribute(xmlWriter, "labelSize", poco.LabelSize);
            WriteEnumAttribute<Auriga.Diagram.Diagram.ContainerShape>(xmlWriter, "shape", poco.Shape);
            WriteBooleanAttribute(xmlWriter, "showIcon", poco.ShowIcon);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
