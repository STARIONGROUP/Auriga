// ------------------------------------------------------------------------------------------------
// <copyright file="DCellStyleWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Table
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DCellStyle</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DCellStyleWriter : XmiElementWriter<Auriga.Diagram.Table.IDCellStyle>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DCellStyleWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DCellStyleWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>table</c>) of the package that
        /// declares <c>DCellStyle</c>.
        /// </summary>
        public override string NamespacePrefix => "table";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DCellStyle</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DCellStyle";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/1.1.0</c>) of the package that declares
        /// <c>DCellStyle</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DCellStyle</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Table.IDCellStyle poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            WriteStringAttribute(xmlWriter, "backgroundColor", poco.BackgroundColor, "255,255,255");
            this.WriteReferenceAttribute(xmlWriter, "backgroundStyleOrigin", poco.BackgroundStyleOrigin, poco, "BackgroundStyleOrigin", context);
            WriteBooleanAttribute(xmlWriter, "defaultBackgroundStyle", poco.DefaultBackgroundStyle, false);
            WriteBooleanAttribute(xmlWriter, "defaultForegroundStyle", poco.DefaultForegroundStyle, false);
            WriteStringAttribute(xmlWriter, "foregroundColor", poco.ForegroundColor, "0,0,0");
            this.WriteReferenceAttribute(xmlWriter, "foregroundStyleOrigin", poco.ForegroundStyleOrigin, poco, "ForegroundStyleOrigin", context);
            WriteEnumListAttribute<Auriga.Diagram.Viewpoint.FontFormat>(xmlWriter, "labelFormat", poco.LabelFormat);
            WriteIntegerAttribute(xmlWriter, "labelSize", poco.LabelSize, 8);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
