// ------------------------------------------------------------------------------------------------
// <copyright file="DTargetColumnWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Table
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DTargetColumn</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DTargetColumnWriter : XmiElementWriter<Auriga.Sirius.Table.IDTargetColumn>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTargetColumnWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DTargetColumnWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>table</c>) of the package that
        /// declares <c>DTargetColumn</c>.
        /// </summary>
        public override string NamespacePrefix => "table";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DTargetColumn</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DTargetColumn";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/1.1.0</c>) of the package that declares
        /// <c>DTargetColumn</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DTargetColumn</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Table.IDTargetColumn poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceListAttribute(xmlWriter, "cells", poco.Cells, poco, "Cells", context);
            WriteStringAttribute(xmlWriter, "label", poco.Label);
            WriteStringAttribute(xmlWriter, "name", poco.Name);
            this.WriteReferenceAttribute(xmlWriter, "originMapping", poco.OriginMapping, poco, "OriginMapping", context);
            this.WriteReferenceListAttribute(xmlWriter, "semanticElements", poco.SemanticElements, poco, "SemanticElements", context);
            this.WriteReferenceAttribute(xmlWriter, "table", poco.Table, poco, "Table", context);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target as Auriga.IAurigaElement, poco, "Target", context);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
            WriteBooleanAttribute(xmlWriter, "visible", poco.Visible);
            WriteIntegerAttribute(xmlWriter, "width", poco.Width);
            this.WriteContainedElement(xmlWriter, "currentStyle", poco.CurrentStyle, poco, "CurrentStyle", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
