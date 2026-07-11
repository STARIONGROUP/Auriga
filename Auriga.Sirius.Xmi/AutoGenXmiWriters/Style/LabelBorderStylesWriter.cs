// ------------------------------------------------------------------------------------------------
// <copyright file="LabelBorderStylesWriter.cs" company="Starion Group S.A.">
//
//   Copyright 2026 Starion Group S.A.
//   SPDX-License-Identifier: Apache-2.0
//
// </copyright>
// ------------------------------------------------------------------------------------------------

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------

namespace Auriga.Sirius.Xmi.AutoGenXmiWriters.Viewpoint.Description.Style
{
    using System.Xml;

    using Auriga.Xmi.Writers;

    using Microsoft.Extensions.Logging;

    /// <summary>
    /// The generated XMI writer that serializes an <c>LabelBorderStyles</c> back to its XMI
    /// representation. Contained elements are written recursively through the facade; cross-references are
    /// written as <c>#id</c> (or cross-document <c>href</c>) attributes.
    /// </summary>
    public class LabelBorderStylesWriter : XmiElementWriter<Auriga.Sirius.Viewpoint.Description.Style.ILabelBorderStyles>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelBorderStylesWriter"/> class.
        /// </summary>
        /// <param name="facade">the writer facade used to write contained elements</param>
        /// <param name="loggerFactory">the logger factory, or <c>null</c> to disable logging</param>
        public LabelBorderStylesWriter(IXmiElementWriterFacade facade, ILoggerFactory? loggerFactory)
            : base(facade, loggerFactory)
        {
        }

        /// <summary>
        /// Gets the Capella <c>xmlns</c> prefix (<c>style</c>) of the package that
        /// declares <c>LabelBorderStyles</c>.
        /// </summary>
        public override string NamespacePrefix => "style";

        /// <summary>
        /// Gets the unqualified XMI type name (<c>LabelBorderStyles</c>) written in the element's
        /// <c>xsi:type</c>.
        /// </summary>
        public override string TypeName => "LabelBorderStyles";

        /// <summary>
        /// Gets the namespace URI (<c>http://www.eclipse.org/sirius/description/style/1.1.0</c>) of the package that declares
        /// <c>LabelBorderStyles</c>.
        /// </summary>
        public override string NamespaceUri => "http://www.eclipse.org/sirius/description/style/1.1.0";

        /// <summary>
        /// Writes the <c>id</c>, attributes and contained children of an <c>LabelBorderStyles</c>.
        /// </summary>
        /// <param name="xmlWriter">the XML writer</param>
        /// <param name="poco">the element whose body to write</param>
        /// <param name="context">the write context</param>
        protected override void WriteBody(XmlWriter xmlWriter, Auriga.Sirius.Viewpoint.Description.Style.ILabelBorderStyles poco, IXmiWriteContext context)
        {
            WriteId(xmlWriter, poco);
            this.WriteContainedElements(xmlWriter, "labelBorderStyleDescriptions", poco.LabelBorderStyleDescriptions, poco, "LabelBorderStyleDescriptions", context);
        }
    }
}

// ------------------------------------------------------------------------------------------------
// --------THIS IS AN AUTOMATICALLY GENERATED FILE. ANY MANUAL CHANGES WILL BE OVERWRITTEN!--------
// ------------------------------------------------------------------------------------------------
