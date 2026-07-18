// ------------------------------------------------------------------------------------------------
// <copyright file="DecorationNodeWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Xmi.Diagram.AutoGenXmiWriters.Notation
{
    using System.Xml;

    using Auriga.Xmi.Core.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>DecorationNode</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class DecorationNodeWriter : XmiElementWriter<Auriga.Diagram.Notation.IDecorationNode>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DecorationNodeWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public DecorationNodeWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>notation</c>) of the package that
        /// declares <c>DecorationNode</c>.
        /// </summary>
        public override string NamespacePrefix => "notation";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>DecorationNode</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "DecorationNode";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/gmf/runtime/1.0.3/notation</c>) of the package that declares
        /// <c>DecorationNode</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/gmf/runtime/1.0.3/notation";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>DecorationNode</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Diagram.Notation.IDecorationNode poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteReferenceAttribute(xmlWriter, "element", poco.Element as Auriga.Core.IAurigaElement, poco, "Element", context);
            WriteStringAttribute(xmlWriter, "type", poco.Type, "");
            WriteBooleanAttribute(xmlWriter, "visible", poco.Visible, true);
            this.WriteContainedElement(xmlWriter, "layoutConstraint", poco.LayoutConstraint, poco, "LayoutConstraint", context);
            this.WriteContainedElements(xmlWriter, "children", poco.PersistedChildren, poco, "PersistedChildren", context);
            this.WriteContainedElements(xmlWriter, "styles", poco.Styles, poco, "Styles", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
