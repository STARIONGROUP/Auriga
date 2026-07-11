// ------------------------------------------------------------------------------------------------
// <copyright file="BracketEdgeStyleWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Diagram
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>BracketEdgeStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class BracketEdgeStyleWriter : XmiElementWriter<Auriga.Sirius.Diagram.IBracketEdgeStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BracketEdgeStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public BracketEdgeStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>diagram</c>) of the package that
        /// declares <c>BracketEdgeStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "diagram";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>BracketEdgeStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "BracketEdgeStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/diagram/1.1.0</c>) of the package that declares
        /// <c>BracketEdgeStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/diagram/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>BracketEdgeStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Diagram.IBracketEdgeStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteEnumAttribute<Auriga.Sirius.Diagram.Description.CenteringStyle>(xmlWriter, "centered", poco.Centered);
            WriteStringListAttribute(xmlWriter, "customFeatures", poco.CustomFeatures);
            this.WriteReferenceAttribute(xmlWriter, "description", poco.Description, poco, "Description", context);
            WriteEnumAttribute<Auriga.Sirius.Diagram.Description.FoldingStyle>(xmlWriter, "foldingStyle", poco.FoldingStyle);
            WriteEnumAttribute<Auriga.Sirius.Diagram.LineStyle>(xmlWriter, "lineStyle", poco.LineStyle);
            WriteEnumAttribute<Auriga.Sirius.Diagram.EdgeRouting>(xmlWriter, "routingStyle", poco.RoutingStyle);
            WriteIntegerAttribute(xmlWriter, "size", poco.Size);
            WriteEnumAttribute<Auriga.Sirius.Diagram.EdgeArrows>(xmlWriter, "sourceArrow", poco.SourceArrow);
            WriteStringAttribute(xmlWriter, "strokeColor", poco.StrokeColor);
            WriteEnumAttribute<Auriga.Sirius.Diagram.EdgeArrows>(xmlWriter, "targetArrow", poco.TargetArrow);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
            this.WriteContainedElement(xmlWriter, "beginLabelStyle", poco.BeginLabelStyle, poco, "BeginLabelStyle", context);
            this.WriteContainedElement(xmlWriter, "centerLabelStyle", poco.CenterLabelStyle, poco, "CenterLabelStyle", context);
            this.WriteContainedElement(xmlWriter, "endLabelStyle", poco.EndLabelStyle, poco, "EndLabelStyle", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
