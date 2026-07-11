// ------------------------------------------------------------------------------------------------
// <copyright file="DTableWriter.cs" company="Starion Group S.A.">
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
    /// The generated XMI writer that serializes an <c>DTable</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DTableWriter : XmiElementWriter<Auriga.Sirius.Table.IDTable>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DTableWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DTableWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>table</c>) of the package that
        /// declares <c>DTable</c>.
        /// </summary>
        public override string NamespacePrefix => "table";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DTable</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DTable";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/table/1.1.0</c>) of the package that declares
        /// <c>DTable</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/table/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DTable</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Table.IDTable poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "description", poco.Description, poco, "Description", context);
            WriteIntegerAttribute(xmlWriter, "headerColumnWidth", poco.HeaderColumnWidth);
            this.WriteReferenceAttribute(xmlWriter, "target", poco.Target as Auriga.IAurigaElement, poco, "Target", context);
            WriteStringAttribute(xmlWriter, "uid", poco.Uid);
            this.WriteContainedElements(xmlWriter, "columns", poco.Columns, poco, "Columns", context);
            this.WriteContainedElements(xmlWriter, "eAnnotations", poco.EAnnotations, poco, "EAnnotations", context);
            this.WriteContainedElements(xmlWriter, "lines", poco.Lines, poco, "Lines", context);
            this.WriteContainedElements(xmlWriter, "ownedAnnotationEntries", poco.OwnedAnnotationEntries, poco, "OwnedAnnotationEntries", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
